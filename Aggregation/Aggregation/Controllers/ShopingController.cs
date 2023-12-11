using Aggregation.Protos;
using ApiGatewate.Model;
using ApiGatewate.Service.Interface;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace ApiGatewate.Controller
{
    [ApiController]
    [Route("/api/shop")]
    public class ShopingController
    {
        private readonly ICatalogService _catalogService;
        private readonly IOrdersService _ordersService;

        public ShopingController(ICatalogService catalogService, IOrdersService ordersService)
        {
            _catalogService = catalogService;
            _ordersService = ordersService;
        }

        [HttpGet("{id}")]
        public AllEntities Get(int id)
        {
            Cloth cloth = null;
            Customer customer = null;
            Task<Catalog> catalogSearch = _catalogService.GetCatalog(id);
            Catalog catalog= catalogSearch.Result;
            if(catalog == null) {
                Task<Cloth> clothSearch = _catalogService.GetCloth(id);
                cloth = clothSearch.Result;
            }
            else
            {
                Task<Cloth> clothSearch = _catalogService.GetCloth(catalog.cloth_id);
                cloth = clothSearch.Result;
            }
            Task<Orders> ordersSearch = _ordersService.GetOrders(id);
            Orders orders = ordersSearch.Result;
            if(orders == null)
            {
                Task<Customer> customerSearch = _ordersService.GetCustomer(id);
                customer = customerSearch.Result;
            }
            else
            {
                Task<Customer> customerSearch = _ordersService.GetCustomer(orders.customerId);
                customer = customerSearch.Result;
            }
            return new AllEntities(catalog,cloth,customer,orders);
        }
        [HttpGet("Grpc/{id}")]
        public async Task<AllEntities> GetGrpc(int id)
        {
            Cloth cloth = null;
            Customer customer = null;
            var chanelCatalog = GrpcChannel.ForAddress("https://localhost:7236");
            var catalogClient=new CatalogProgram.CatalogProgramClient(chanelCatalog);
            var catalogRequest= new CatalogLookupModel { Id = id };
            var catalogGrpc=await catalogClient.getCatalogAsync(catalogRequest);
            Catalog catalog = new Catalog
            {
                id= catalogGrpc.Id,
                cloth_id=catalogGrpc.ClothId,
                price=(decimal)catalogGrpc.Price
            };
            if(catalog == null)
            {
                var clothRequest=new ClothLookupModel { Id = id };
                var clothGrpc = await catalogClient.getClothAsync(clothRequest);
                cloth = new Cloth
                {
                    id= clothGrpc.Id,
                    name=clothGrpc.Name,
                    size=clothGrpc.Size,
                    type=clothGrpc.Type
                };
            }
            else
            {
                var clothRequest = new ClothLookupModel { Id = catalog.id };
                var clothGrpc = await catalogClient.getClothAsync(clothRequest);
                cloth = new Cloth
                {
                    id = clothGrpc.Id,
                    name = clothGrpc.Name,
                    size = clothGrpc.Size,
                    type = clothGrpc.Type
                };
            }
            var chanelOrder = GrpcChannel.ForAddress("https://localhost:7170");
            var orderClient = new OrderProgram.OrderProgramClient(chanelOrder);
            var orderRequest = new OrderLookupModel { Id = id };
            var orderGrps = await orderClient.getOrderAsync(orderRequest);
            Orders orders = new Orders
            {
                Id = orderGrps.Id,
                Name = orderGrps.Name,
                Count_Product = (decimal)orderGrps.CountProduct,
                Price_Per_One = (decimal)orderGrps.PricePerOne,
                customerId = orderGrps.CustomerId
            };
            if (orders == null)
            {
                var custumerRequest = new CustomerLookupModel { Id = id };
                var customerGrps = await orderClient.getCustomerAsync(custumerRequest);
                customer.Id = customerGrps.Id;
                customer.Name = customerGrps.Name;
                customer.Last_Name = customerGrps.LastName;
            }
            else
            {
                var custumerRequest = new CustomerLookupModel { Id = orders.customerId };
                var customerGrps = await orderClient.getCustomerAsync(custumerRequest);
                customer = new Customer
                {
                    Id = customerGrps.Id,
                    Name = customerGrps.Name,
                    Last_Name = customerGrps.LastName
                };
            }
            return new AllEntities(catalog, cloth, customer, orders);
        }
    }
}

using ApiGatewate.Model;
using ApiGatewate.Service.Interface;
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
            Task<Catalog> catalogSearch = _catalogService.GetCatalog(id);
            Catalog catalog= catalogSearch.Result;
            Task<Cloth> clothSearch = _catalogService.GetCloth(catalog.cloth_id);
            Cloth cloth = clothSearch.Result;
            Task<Orders> ordersSearch = _ordersService.GetOrders(id);
            Orders orders = ordersSearch.Result;
            Task<Customer> customerSearch = _ordersService.GetCustomer(orders.customerId);
            Customer customer = customerSearch.Result;
            return new AllEntities(catalog,cloth,customer,orders);
        }
    }
}

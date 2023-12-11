using Grpc.Core;
using lab1_ado2.Models;
using lab1_ado2.Protos;
using lab1_ado2.Services.Interface;

namespace lab1_ado2.Services
{
    public class CatalogProgramService : CatalogProgram.CatalogProgramBase
    {
        private readonly ICatalogService _catalogSrtvice;
        private readonly IClothService _clothService;
        public CatalogProgramService(ICatalogService catalogSrtvice, IClothService clothService)
        {
            _catalogSrtvice = catalogSrtvice;
            _clothService = clothService;
        }
        public override async Task<CatalogModel> getCatalog(CatalogLookupModel requset, ServerCallContext context)
        {
            CatalogModel orderModel = new CatalogModel();
            Catalog catalog =_catalogSrtvice.getCatalog(requset.Id);
            orderModel.Id = catalog.id;
            orderModel.ClothId = catalog.cloth_id;
            orderModel.Price = (float)catalog.price;
            return orderModel;
        }
        public override async Task<ClothModel> getCloth(ClothLookupModel requset, ServerCallContext context)
        {
            ClothModel clothModel = new ClothModel();
            Cloth cloth =_clothService.getCloth(requset.Id);
            clothModel.Id = cloth.id;
            clothModel.Name = cloth.name;
            clothModel.Size = cloth.size;
            clothModel.Type = cloth.type;
            return clothModel;
        }
    }
}

using lab1_ado2.Models;
using lab1_ado2.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.SqlClient;

namespace lab1_ado2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatlogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public CatlogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        [HttpGet]
        public  List<Catalog> GetAllCatalog()
        {
            return _catalogService.getAllCatalog();
        }

        [HttpPut]
        public int UpdateCatalog(Catalog catalog)
        {
            return _catalogService.updateCatalog(catalog);
        }
        [HttpDelete("{catalogId}")]
        public int DeleteCatalog(int catalogId)
        {
            return _catalogService.deleteCatalog(catalogId);

        }
        [HttpGet("{catalogId}")]
        public Catalog getCatalog(int catalogId)
        {
            return _catalogService.getCatalog(catalogId);

        }
        [HttpPost]
        public int createCatalog(Catalog catalog)
        {
            return _catalogService.createCatalog(catalog);
        }
    }
}

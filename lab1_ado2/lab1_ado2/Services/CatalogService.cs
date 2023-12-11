using lab1_ado2.Models;
using lab1_ado2.Repository.Interface;
using lab1_ado2.Services.Interface;

namespace lab1_ado2.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        public int createCatalog(Catalog catalog)
        {
            return _catalogRepository.createCatalog(catalog);
        }

        public int deleteCatalog(int id)
        {
            return (_catalogRepository.deleteCatalog(id));
        }

        public List<Catalog> getAllCatalog()
        {
            return _catalogRepository.getAllCatalog();
        }

        public Catalog getCatalog(int id)
        {
            return _catalogRepository.getCatalog(id);
        }

        public int updateCatalog(Catalog catalog)
        {
            return _catalogRepository.updateCatalog(catalog);
        }
    }
}

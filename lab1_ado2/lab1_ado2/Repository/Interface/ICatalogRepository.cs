using lab1_ado2.Models;

namespace lab1_ado2.Repository.Interface
{
    public interface ICatalogRepository
    {
        List<Catalog> getAllCatalog();
        Catalog getCatalog(int id);
        int createCatalog(Catalog catalog);
        int updateCatalog(Catalog catalog);
        int deleteCatalog(int id);
    }
}

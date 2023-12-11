using ApiGatewate.Model;

namespace ApiGatewate.Service.Interface
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalog(int id);
        Task<Cloth> GetCloth(int id);
    }
}
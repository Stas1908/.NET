using ApiGatewate.Model;
using ApiGatewate.Service.Interface;
using Newtonsoft.Json;

namespace ApiGatewate.Service
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        public CatalogService(HttpClient client)
        {
            _httpClient = client ?? throw new ArgumentNullException(nameof(client)); ;
        }
        public async Task<Catalog> GetCatalog(int id)
        {
            var response = await _httpClient.GetAsync($"/api/catalog/{id}");
            Console.WriteLine(response.IsSuccessStatusCode + " asdasdasdasd");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var catalog = JsonConvert.DeserializeObject<Catalog>(jsonContent);
                return catalog;
            }

            return null;
        }

        public async Task<Cloth> GetCloth(int id)
        {
            var response = await _httpClient.GetAsync($"/api/cloth/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var cloth = JsonConvert.DeserializeObject<Cloth>(jsonContent);
                return cloth;
            }
            return null;
        }
    }
}

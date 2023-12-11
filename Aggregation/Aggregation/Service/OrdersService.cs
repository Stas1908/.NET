using ApiGatewate.Model;
using ApiGatewate.Service.Interface;
using Newtonsoft.Json;

namespace ApiGatewate.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly HttpClient _httpClient;
        public OrdersService(HttpClient client) {
            _httpClient= client ?? throw new ArgumentNullException(nameof(client)); ;
        }
        public async Task<Customer> GetCustomer(int id)
        {
            var response = await _httpClient.GetAsync($"/api/costumer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<Customer>(jsonContent);
                return customer;
            }

            return null;
        }

        public async Task<Orders> GetOrders(int id)
        {
            var response = await _httpClient.GetAsync($"/api/orders/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<Orders>(jsonContent);
                return orders;
            }

            return null;
        }
    }
}

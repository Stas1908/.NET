using ApiGatewate.Model;

namespace ApiGatewate.Service.Interface
{
    public interface IOrdersService
    {
        Task<Customer> GetCustomer(int id);
        Task<Orders> GetOrders(int id);
    }
}

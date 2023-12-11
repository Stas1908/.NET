using Consumer.Data;
using lab1_efApi.Model;
using lab1_efApi.Services.Interfaces;
using MassTransit;

namespace Consumer
{
    public class OrderConsumer : IConsumer<Orders>
    {
        DataContext _dbContext;
        public OrderConsumer(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<Orders> context)
        {
            Orders orders = new Orders();
            orders.Name = context.Message.Name;
            orders.Count_Product = context.Message.Count_Product;
            orders.Price_Per_One = context.Message.Price_Per_One;
            orders.customerId = context.Message.customerId;
            _dbContext.Orders.Add(orders);
            _dbContext.SaveChangesAsync();
            Console.Out.WriteLineAsync(context.Message.Name + "\n" + context.Message.Count_Product + "\n" + context.Message.Price_Per_One + "\n" + context.Message.customerId);

        }
    }
}

namespace Consumer.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Count_Product { get; set; }
        public decimal Price_Per_One { get; set; }
        public int customerId { get; set; }
    }
}

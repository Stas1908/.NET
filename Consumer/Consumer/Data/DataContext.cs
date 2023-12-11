using lab1_efApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Consumer.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var orders = modelBuilder.Entity<Orders>();
        //    var customer = modelBuilder.Entity<Customer>();

        //    orders.HasKey(b => b.Id);
        //    //orders.HasOne(b => b.customer).WithOne(a => a.Orders).HasForeignKey<Orders>(o=>o.customerId);
        //    orders.Property(b => b.Name).HasMaxLength(255);
        //    orders.Property(o => o.Price_Per_One).HasColumnType("decimal(10,2)");
        //    orders.Property(o => o.Count_Product).HasColumnType("decimal(10,2)");

        //    customer.HasKey(b => b.Id);
        //    customer.Property(c => c.Name).HasMaxLength(255);
        //    customer.Property(c => c.Last_Name).HasMaxLength(255);
        //}
        //public DbSet<Customer> Customer { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}

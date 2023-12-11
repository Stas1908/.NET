namespace ApiGatewate.Model
{
    public class AllEntities
    {
        public Catalog? catalog { get; set; }
        public Cloth? cloth { get; set; }
        public Customer? customer { get; set; }
        public Orders? orders { get; set; }
        public AllEntities(Catalog? catalog, Cloth? cloth, Customer? customer, Orders? orders)
        {
            this.catalog = catalog;
            this.cloth = cloth;
            this.customer = customer;
            this.orders = orders;
        }
    }
}

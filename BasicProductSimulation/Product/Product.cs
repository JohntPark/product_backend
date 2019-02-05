namespace BasicProductSimulation
{
    public class Product : IProduct
    {
        public Product()
        {
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }
    
}

namespace BasicProductSimulation
{
    public interface IProduct
    {
        string Id { get; set; }
        string Name { get; set; }
        string Price { get; set; }
        string Quantity { get; set; }
    }
}

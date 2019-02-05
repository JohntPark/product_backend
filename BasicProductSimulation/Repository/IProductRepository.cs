using System.Collections.Generic;

namespace BasicProductSimulation.Repository
{
    public interface IProductRepository 
    {
        IEnumerable<IProduct> GetAllProducts();
        IProduct GetProductID(string id);
        IEnumerable<IProduct> InsertProduct(IProduct product);
        IEnumerable<IProduct> InsertRandomProduct(IProduct product);
        IProduct UpdateProduct(IProduct product, string id);
        IProduct DeleteProduct(string id);
    }
}

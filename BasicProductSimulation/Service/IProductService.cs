using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BasicProductSimulation
{
    public interface IProductService
    {
        IEnumerable<IProduct> Get();
        IProduct GetProductByID(string id);
        FileStreamResult GetProductFromFile();
        IEnumerable<IProduct> Add(IProduct product);
        IEnumerable<IProduct> AddRandomProduct();
        IProduct UpdateProduct(IProduct product, string id);
        IProduct DeleteProduct(string id);
    }
}

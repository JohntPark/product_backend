using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicProductSimulation.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductDB _productDB;
        public ProductRepository(ProductDB productDB)
        {
            this._productDB = productDB;
        }


        #region Get
        public IEnumerable<IProduct> GetAllProducts()
        {
            return _productDB.Products;
        }

        public IProduct GetProductID(string ID)
        {
            IProduct product = this._productDB.Products.Find(ID);
            return product;
        }
        #endregion

        #region Add
        public IEnumerable<IProduct> InsertProduct(IProduct product)
        {
            product.Id = Guid.NewGuid().ToString();
            _productDB.Products.Add(product as Product);
            _productDB.SaveChanges();
            var result = _productDB.Products.ToList();
            return result;
        }
        public IEnumerable<IProduct> InsertRandomProduct(IProduct product)
        {
            _productDB.Products.Add(product as Product);
            _productDB.SaveChanges();
            var result = _productDB.Products.ToList();
            return result;
        }
        #endregion

        #region Update
        public IProduct UpdateProduct(IProduct product, string id)
        {
              product.Id = id;
            _productDB.Products.Update(product as Product);
            _productDB.SaveChanges();
            return product;
        }
        #endregion

        #region Delete
        public IProduct DeleteProduct(string id)
        {
            var findProduct = _productDB.Products.Find(id);
            _productDB.Products.Remove(findProduct);
            _productDB.SaveChanges();
            return findProduct;
        }
        #endregion

    }
}


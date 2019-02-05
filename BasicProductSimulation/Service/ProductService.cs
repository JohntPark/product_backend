using BasicProductSimulation.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using BasicProductSimulation.Validation;
using FluentValidation;

namespace BasicProductSimulation.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly Random _randomGenerator;
        private ProductValidator _productValidator;
        public ProductService(IProductRepository productRepository, Random randomGenerator = null)
        {
            _productRepository = productRepository;
            _randomGenerator = randomGenerator;
            _productValidator = new ProductValidator();

            if (_randomGenerator == null)
            {
                _randomGenerator = new Random();
            }
        }

        #region ADD
        public IEnumerable<IProduct> Add(IProduct product)
        {
            _productValidator.ValidateAndThrow((Product)product);
            var result = _productRepository.InsertProduct(product);
            return result;
        }
        public IEnumerable<IProduct> AddRandomProduct()
        {
            IProduct product = new Product();
            int rndNumber = _randomGenerator.Next(1, 15);
            if (rndNumber % 7 == 0)
            {
                product.Id = Guid.NewGuid().ToString();
                product.Name = "Jollibee";
                product.Price = "$14.55";
                product.Quantity = "3";
            }
            else if (rndNumber % 5 == 0)
            {
                product.Id = Guid.NewGuid().ToString();
                product.Name = "Donutterie";
                product.Price = "$19.95";
                product.Quantity = "24";
            }
            else if (rndNumber % 3 == 0)
            {
                product.Id = Guid.NewGuid().ToString();
                product.Name = "Shake Shack";
                product.Price = "$11.95";
                product.Quantity = "1";
            }
            else if (rndNumber % 2 == 0)
            {
                product.Id = Guid.NewGuid().ToString();
                product.Name = "McDonald's";
                product.Price = "$15.24";
                product.Quantity = "17";
            }
            else
            {
                throw new System.ArgumentException("This is not a defined ID. Please try again");
            }
            _productValidator.ValidateAndThrow((Product)product);
            var result = _productRepository.InsertRandomProduct(product);
            return result;
        }
        #endregion

        #region GET
        public IEnumerable<IProduct> Get()
        {
            var result = _productRepository.GetAllProducts();
            return result;
        }

        public IProduct GetProductByID(string ID)
        {
            var result = _productRepository.GetProductID(ID);
            if(result == null)
            {
                throw new ArgumentException("Please enter a valid ID");
            }
            return result;
        }

        public FileStreamResult GetProductFromFile()
        {
            var directory = "C:\\Users\\John.TaeHeePark\\Desktop\\ProductList";
            var file = "product.txt";
            var path = Path.Combine(directory, file);
            var byteArr = File.ReadAllBytes(path);

            
            var content = new MemoryStream(byteArr);

            content.Position = 0;
            FileStreamResult result = new FileStreamResult(content, "plain/txt");
            return result;
            
        }
        #endregion

        #region Update

        public IProduct UpdateProduct(IProduct product, string id)
        {
            _productValidator.ValidateAndThrow((Product)product);
            IProduct productDetails = _productRepository.UpdateProduct(product, id);
            return productDetails;
        }
        #endregion

        #region Delete
        public IProduct DeleteProduct(string id)
        {
            IProduct productDetails = _productRepository.DeleteProduct(id);
            return productDetails;
        }
        #endregion
    }
}

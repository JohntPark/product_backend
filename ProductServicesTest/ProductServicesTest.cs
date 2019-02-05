using BasicProductSimulation;
using BasicProductSimulation.Repository;
using BasicProductSimulation.Service;
using BasicProductSimulation.Validation;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProductServicesTest
{
    public class ProductServicesTest
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<Random> _randomGenerator;
        private readonly ProductService _productService;
        private readonly string _testID;
        private readonly ProductValidator _productValidator;
        public ProductServicesTest()
        {
            _randomGenerator = new Mock<Random>();
            _productRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepository.Object, _randomGenerator.Object);
            _testID = "123";
            _productValidator = new ProductValidator();
        }

        [Fact]
        public void ADDRANDOMPRODUCT_RANDOMNUMBER_SUCCESS()
        {
            var product = new List<Product>();
            _randomGenerator.Setup(x => x.Next(1, 15)).Returns(7);
            _productRepository.Setup(x => x.InsertRandomProduct(It.IsAny<IProduct>())).Returns(product);

            var addedRandomProduct = _productService.AddRandomProduct();
            Assert.NotNull(addedRandomProduct);
        }
        [Fact]
        public void ADDRANDOMPRODUCT_RANDOMNUMBERINVALID_FAILED()
        {
            _randomGenerator.Setup(x => x.Next(1, 15)).Returns(1);

            Assert.Throws<ArgumentException>(() => _productService.AddRandomProduct());
        }

        [Fact]
        public void GETPRODUCT_HASALLPROPS_SUCCESS()
        {
            var product = new List<Product>();
            _productRepository.Setup(x => x.GetAllProducts()).Returns(product);
            var getProduct = _productService.Get();
            Assert.NotNull(getProduct);
        }
        [Fact]
        public void GETPRODUCTBYID_SUCCESSFULID_SUCCESS()
        {
            var product = new Product();
            var result = _productRepository.Setup(x => x.GetProductID(_testID)).Returns(product);
            Assert.NotNull(result);
        }
        [Fact]
        public void GETPRODUCTBYFILE_HASFILE_SUCCESS()
        {            
            var getFile = _productService.GetProductFromFile();

            Assert.NotNull(getFile);
        }
        [Fact]
        public void VALIDATEVALIDATOR_HASALLPROPS_SUCCESS()
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Price = "$11",
                Quantity = "5",
                Name = "Sunflowers"
            };
            var result = _productValidator.Validate(product);
            Assert.NotNull(result);
            Assert.True(result.IsValid == true); 

        }
        [Fact]
        public void VALIDATEVALIDATOR_MISSINGSOMEPROPS_FAILED()
        {
            Product product = new Product()
            {
                Price = "$11",
                Quantity = "5"
            };
            var result = _productValidator.Validate(product);
            Assert.True(result.IsValid == false);
        }
    }
}

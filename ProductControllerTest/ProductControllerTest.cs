//using BasicProductSimulation;
//using BasicProductSimulation.Controllers;
//using Moq;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace ProductControllerTest
//{
//    public class ProductControllerTest
//    {
//        private ProductController _productController;
//        private Mock<IProductService> _mockProductService;
//        private Product _testProduct;
//        private string _testProductId = "123";

//        public ProductControllerTest()
//        {
//            _testProduct = CreateTestProduct("Hello");
//            List<IProduct> allProductList = new List<IProduct>();
//            allProductList.Add(_testProduct);

//            _productController = new ProductController(_mock)
//        }
//        private Product CreateTestProduct(string productName)
//        {
//            Product product = new Product();
//            product.Name = productName;
//            product.Id = "123";
//            return product;
//        }

//        [Fact]
//        public void GetProduct_AllMatched_Success()
//        {
//            var actionResult = _productController.Get(string.Empty, _testProductId);

//        }
//    }
//}

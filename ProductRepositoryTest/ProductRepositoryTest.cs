//using BasicProductSimulation;
//using BasicProductSimulation.Repository;
//using Moq;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace ProductRepositoryTest
//{
//    public class ProductRepositoryTest
//    {
//        private IProductRepository _productRepo;
//        private Mock<ProductDB> _productCollection;
//        public ProductRepositoryTest()
//        {
//        }



//        [Fact]
//        public void CanReturnProduct_HASALLPROPERTIES_SUCCESS()
//        {
//            Product product = new Product()
//            {
//                Id = Guid.NewGuid().ToString(),
//                Price = "$100",
//                Name = "Sunflowers",
//                Quantity = "100"
//            };
//            Assert.NotNull(product);
//        }
//    }
//}

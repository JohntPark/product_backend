using BasicProductSimulation.Controllers.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BasicProductSimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandlingFilter]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #region Get
        [HttpGet]
        public ActionResult<IEnumerable<IProduct>> Get()
        {
            var result = _productService.Get();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IProduct GetProductByID(string id)
        {
            var result = _productService.GetProductByID(id);
            return result;
        }
        [HttpGet]
        [Route("readFromFile")]
        public FileStreamResult GetProductFromFile()
        {
            var result = _productService.GetProductFromFile();
            return result;
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult<IEnumerable<IProduct>> Post(Product product)
        {
            var result = _productService.Add(product);
            //var firstResult = result.FirstOrDefault();
            return Created(string.Empty, result);
        }
        [HttpPost]
        [Route("randomVariable")]
        public ActionResult<IProduct> PostRandomVariable()
        {
            var result = _productService.AddRandomProduct();
            return Created(String.Empty, result);
        }
        #endregion

        #region Put
        [ProducesResponseType(200, Type = typeof(IProduct))]
        [HttpPut("{id}")]
        public ActionResult<IProduct> UpdateProduct(Product product, string id)
        {
            var result = _productService.UpdateProduct(product, id);
            return Ok(result);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public ActionResult<IProduct> Delete(string id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
        #endregion

    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supercon.Businnes.Services;

namespace Supercon.Controllers
{

    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("v1/products")]
        public List<string> GetProducts()
        {
            return _productService.GetProductCodes();
        }

        [HttpGet("v1/products/{code}")]
        public IActionResult GetProducts(string code)
        {
            var product = _productService.GetProduct(code);
            return StatusCode(StatusCodes.Status200OK, product);
        }
    }
}

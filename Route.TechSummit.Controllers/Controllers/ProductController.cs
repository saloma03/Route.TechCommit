// Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Route.TechSummit.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return HandleResult(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return HandleResult(product);
        }

        // Implement other endpoints similarly
    }
}
// Controllers/ProductController.cs
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Controllers.Controllers.Base;
using Route.TechSummit.DTOs.ProductDTOs;

namespace Route.TechSummit.Controllers.Controllers.Product
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
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return HandleResult(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productDto)
        {
            var product = await _productService.CreateProductAsync(productDto);
            return HandleResult(product, HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto productDto)
        {
            await _productService.UpdateProductAsync(id, productDto);
            return HandleResult(null, HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return HandleResult(null, HttpStatusCode.NoContent);
        }


    }
}

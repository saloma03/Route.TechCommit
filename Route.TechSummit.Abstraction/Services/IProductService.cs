using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Abstraction.DTOs.ProductDTOs;
namespace Route.TechSummit.Abstraction.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<ProductDto> CreateProductAsync(ProductCreateDto productDto);
        Task UpdateProductAsync(Guid id, ProductUpdateDto productDto);
        Task DeleteProductAsync(Guid id);
    }
}
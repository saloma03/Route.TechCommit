using Route.TechSummit.Application.DTOs.ProductDTOs;

namespace Route.TechSummit.Abstraction.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(ProductCreateDto productDto);
        Task UpdateProductAsync(int id, ProductUpdateDto productDto);
        Task DeleteProductAsync(int id);
    }
}
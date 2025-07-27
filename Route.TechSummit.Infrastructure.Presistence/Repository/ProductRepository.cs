using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.TechSummit.Domain.Contracts;
using Route.TechSummit.Infrastructure.Presistence.Data;

namespace Route.TechSummit.Infrastructure.Presistence.Repository
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        private readonly TechSummitDbContext _dbContext;

        public ProductRepository(TechSummitDbContext dbContext) : base(dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsByIdsAsync(IEnumerable<int> productIds)
        {
            return await _dbContext.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();
        }

        public async Task UpdateStockAsync(int productId, int quantity)
        {
            var product = await GetByIdAsync(productId);
            if (product != null)
            {
                product.Stock -= quantity;
                await UpdateAsync(product);
            }
        }
    }
}

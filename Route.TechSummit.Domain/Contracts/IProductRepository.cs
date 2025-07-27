using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Domain.Entities;

namespace Route.TechSummit.Domain.Contracts
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        Task<IEnumerable<Product>> GetProductsByIdsAsync(IEnumerable<int> productIds);
        Task UpdateStockAsync(int productId, int quantity);
    }
}

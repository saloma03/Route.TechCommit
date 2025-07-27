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
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private readonly TechSummitDbContext _dbContext;

        public UserRepository(TechSummitDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}

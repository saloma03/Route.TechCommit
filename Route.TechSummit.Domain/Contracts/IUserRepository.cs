using Route.TechSummit.Domain.Entities;

namespace Route.TechSummit.Domain.Contracts
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}

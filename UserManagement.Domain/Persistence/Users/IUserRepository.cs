

using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Common;

namespace UserManagement.Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetById(int id);
    }
}

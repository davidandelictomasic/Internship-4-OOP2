using UserManagement.Domain.Entities.Users;

namespace UserManagement.Application.Common.Interfaces
{
    public interface IUserCacheService
    {
        Task<IEnumerable<User>> GetUsersFromCacheOrApiAsync();
    }

}

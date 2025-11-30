

using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Common;

namespace UserManagement.Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetById(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByGeoAsync(double geoLat, double geoLng,int id);
        Task<List<User>> GetAll();


    }
}

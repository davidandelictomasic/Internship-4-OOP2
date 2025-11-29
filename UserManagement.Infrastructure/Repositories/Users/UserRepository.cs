
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Users;
using UserManagement.Infrastructure.Dapper;
using UserManagement.Infrastructure.Database;
using UserManagement.Infrastructure.Repositories.Common;

namespace UserManagement.Infrastructure.Repositories.Users
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDapperManager _dapperManager;
        public UserRepository(DbContext dbContext, IDapperManager dapperManager) : base(dbContext)
        {
            _dapperManager = dapperManager;
        }

        public async Task<User> GetById(int id)
        {
            var sql = "SELECT id as ID, name as Name,username as Username,email as Email,address_street as AddressStreet,address_city as AddressCity,geo_lat as GeoLatitude,geo_lng as GeoLongitude,website as Website,password as Password,is_active as IsActive FROM public.\"Users\" WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dapperManager.QuerySingleAsync<User>(sql, parameters);
        }

        

    }
}

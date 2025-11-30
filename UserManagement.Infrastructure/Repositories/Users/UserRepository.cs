
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Users;
using UserManagement.Infrastructure.Dapper;
using UserManagement.Infrastructure.Dapper.Users;
using UserManagement.Infrastructure.Database;
using UserManagement.Infrastructure.Repositories.Common;

namespace UserManagement.Infrastructure.Repositories.Users
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {

        //private readonly IDapperManager _dapperManager;
        //public UserRepository(DbContext dbContext, IDapperManager dapperManager) : base(dbContext)
        //{
        //    _dapperManager = dapperManager;
        //}
        private readonly UserDbContext _dbContext;
        private readonly IUserDapperManager _dapperManager;

        public UserRepository(UserDbContext dbContext, IUserDapperManager dapperManager)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _dapperManager = dapperManager;
        }

        public async Task<User> GetById(int id)
        {
            var sql = "SELECT id as ID, name as Name,username as Username,email as Email,address_street as AddressStreet,address_city as AddressCity,geo_lat as GeoLatitude,geo_lng as GeoLongitude,website as Website,password as Password,is_active as IsActive FROM public.\"Users\" WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dapperManager.QuerySingleAsync<User>(sql, parameters);
        }
        public async Task<List<User>> GetAll()
        {
            var sql = "SELECT id as ID, name as Name,username as Username,email as Email,address_street as AddressStreet,address_city as AddressCity,geo_lat as GeoLatitude,geo_lng as GeoLongitude,website as Website,password as Password,is_active as IsActive FROM public.\"Users\" ";

            var users = await _dapperManager.QueryAsync<User>(sql);
            return users.ToList();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var sql = "SELECT id as ID, name as Name,username as Username,email as Email,address_street as AddressStreet,address_city as AddressCity,geo_lat as GeoLatitude,geo_lng as GeoLongitude,website as Website,password as Password,is_active as IsActive FROM public.\"Users\" WHERE Username = @Username LIMIT 1";

            var parameters = new { Username = username };
            return await _dapperManager.QuerySingleAsync<User>(sql, parameters);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var sql = "SELECT id as ID, name as Name,username as Username,email as Email,address_street as AddressStreet,address_city as AddressCity,geo_lat as GeoLatitude,geo_lng as GeoLongitude,website as Website,password as Password,is_active as IsActive FROM public.\"Users\" WHERE Email = @Email LIMIT 1";

            var parameters = new { Email = email };
            return await _dapperManager.QuerySingleAsync<User>(sql, parameters);
        }
        public async Task<User?> GetByGeoAsync(double geoLat,double geoLng)
        {
                
            var sql = @"
            SELECT
                id AS ID,
                name AS Name
            FROM
                public.""Users""
            WHERE
                6371 * 2 * ATAN2(
                    SQRT(
                        SIN(RADIANS(@Lat - geo_lat) / 2) * SIN(RADIANS(@Lat - geo_lat) / 2) +
                        COS(RADIANS(geo_lat)) * COS(RADIANS(@Lat)) *
                        SIN(RADIANS(@Lng - geo_lng) / 2) * SIN(RADIANS(@Lng - geo_lng) / 2)
                    ),
                    SQRT(
                        1 - (
                            SIN(RADIANS(@Lat - geo_lat) / 2) * SIN(RADIANS(@Lat - geo_lat) / 2) +
                            COS(RADIANS(geo_lat)) * COS(RADIANS(@Lat)) *
                            SIN(RADIANS(@Lng - geo_lng) / 2) * SIN(RADIANS(@Lng - geo_lng) / 2)
                        )
                    )
                ) < 3
            LIMIT 1;
            ";
            var parameters = new { Lat = geoLat, Lng = geoLng };
            var user = await _dapperManager.QuerySingleAsync<User>(sql, parameters);            
            return user;
        }
        

    }
}

using Microsoft.Extensions.Caching.Memory;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Infrastructure.Service
{
    public class ExternalUserCacheService : IUserCacheService
    {
        private readonly IMemoryCache _cache;
        private readonly IExternalUserApi _externalApi;

        public ExternalUserCacheService(IMemoryCache cache, IExternalUserApi externalApi)
        {
            _cache = cache;
            _externalApi = externalApi;
        }

        public async Task<IEnumerable<User>> GetUsersFromCacheOrApiAsync()
        {
            if (_cache.TryGetValue("external_users_date", out DateTime cachedDate))
            {
                if (cachedDate.Date == DateTime.UtcNow.Date &&
                    _cache.TryGetValue("external_users", out IEnumerable<User>? cachedUsers)) 
                {
                    return cachedUsers ?? Enumerable.Empty<User>(); 
                }
            }
            var externalUsers = await _externalApi.GetUsersAsync();

            var mappedUsers = externalUsers.Select(u => new User
            {
                Name = u.Name,
                Username = u.Username,
                Email = u.Email,
                AddressStreet = u.AddressStreet,
                AddressCity = u.AddressCity,
                Website = u.Website,
                Password = Guid.NewGuid().ToString(),
                GeoLongitude = (double)u.GeoLat,
                GeoLatitude = (double)u.GeoLng
            }).ToList();

            var expiration = DateTime.Today.AddDays(1) - DateTime.UtcNow;

            _cache.Set("external_users", mappedUsers, expiration);
            _cache.Set("external_users_date", DateTime.UtcNow, expiration);

            return mappedUsers;
        }
    }
}
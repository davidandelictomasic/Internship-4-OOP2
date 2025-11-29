using System.Net.Http.Json;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Application.DTOs.Users;

namespace UserManagement.Infrastructure.Service
{
    public class ExternalUserApi : IExternalUserApi
    {
        private readonly HttpClient _httpClient;

        public ExternalUserApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ExternalUserDto>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ExternalUserDto>>(
                "https://jsonplaceholder.typicode.com/users"
            ) ?? new List<ExternalUserDto>();
        }
    }

}

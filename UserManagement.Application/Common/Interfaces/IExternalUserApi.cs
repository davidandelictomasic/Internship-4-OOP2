using UserManagement.Application.DTOs.Users;

namespace UserManagement.Application.Common.Interfaces
{
    public interface IExternalUserApi
    {
        Task<IEnumerable<ExternalUserDto>> GetUsersAsync();
    }

}

using UserManagement.Application.Common.Model;
using UserManagement.Application.DTOs.Users;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class GetAllUsersRequest{ }
    public class GetAllUsersRequestHandler : RequestHandler<GetAllUsersRequest, List<UserDto>>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public GetAllUsersRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<List<UserDto>>> HandleRequest(GetAllUsersRequest request, Result<List<UserDto>> result)
        {

            var users = await _unitOfWork.Repository.GetAll(); 
            

            var dto = users
                .Select(UserDto.FromEntity)
                .ToList();

            result.SetResult(dto);
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

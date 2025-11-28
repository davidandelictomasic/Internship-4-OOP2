
using UserManagement.Application.Common.Model;
using UserManagement.Application.DTOs.Users;
using UserManagement.Domain.Common.Model;
using UserManagement.Domain.Persistence.Common;
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class GetByIdUserRequest
    {
        public int Id { get; init; }
    }
    public class GetByIdUserRequestHandler : RequestHandler<GetByIdUserRequest, UserDto>
    {
        private readonly IUserUnitOfWork _unitOfWork;

        protected async override Task<Common.Model.Result<UserDto>> HandleRequest(GetByIdUserRequest request, Common.Model.Result<UserDto> result)
        {
            var user = await _unitOfWork.Repository.GetById(request.Id);
            UserDto dto = UserDto.FromEntity(user);
            if(dto != null)
                result.SetResult(dto);
            return result;
                    
            
        }

        protected override Task<bool> IsActive()
        {
            throw new NotImplementedException();
        }
    }
}

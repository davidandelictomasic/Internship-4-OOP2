using UserManagement.Application.Common.Model;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class ActivateUserRequest

    {
        public int UserId { get; init; }

    }
    public class ActivateUserRequestHandler : RequestHandler<ActivateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public ActivateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(ActivateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(request.UserId);
            var validationResult = await user.Create(_unitOfWork.Repository);
            if (user.IsActive)
            {
                
                validationResult.ValidationResult.AddValidationItem(UserValidationItems.User.AlreadyActive);                
                result.SetValidationResult(validationResult.ValidationResult);
                return result;
            }

            user.IsActive = true;   
            result.SetValidationResult(validationResult.ValidationResult);      
            
            await _unitOfWork.SaveAsync();
            result.SetResult(new SuccessPostResponse(user.Id));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

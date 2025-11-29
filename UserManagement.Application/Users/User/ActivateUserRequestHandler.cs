using UserManagement.Application.Common.Model;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class ActivateUserRequest {   }
    public class ActivateUserRequestHandler : RequestHandler<ActivateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        private int _userId;
        public ActivateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        public void SetUserId(int id)
        {
            _userId = id;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(ActivateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(_userId);          
            

            user.IsActive = true;
            var validationResult = await user.Update(_unitOfWork.Repository);
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

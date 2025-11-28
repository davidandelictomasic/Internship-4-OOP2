using UserManagement.Application.Common.Model;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class DeactivateUserRequest

    {
        public int UserId { get; init; }

    }
    public class DeactivateUserRequestHandler : RequestHandler<DeactivateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public DeactivateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(DeactivateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(request.UserId);
            var validationResult = await user.Create(_unitOfWork.Repository);
            if (!user.IsActive)
            {

                validationResult.ValidationResult.AddValidationItem(UserValidationItems.User.AlreadyInactive);
                result.SetValidationResult(validationResult.ValidationResult);
                return result;
            }

            user.IsActive = false;
            result.SetValidationResult(validationResult.ValidationResult);

            await _unitOfWork.SaveAsync();
            result.SetResult(new SuccessPostResponse(user.ID));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

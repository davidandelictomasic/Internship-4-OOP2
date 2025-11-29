using UserManagement.Application.Common.Model;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class DeactivateUserRequest

    {
        

    }
    public class DeactivateUserRequestHandler : RequestHandler<DeactivateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        private int _userId;

        public DeactivateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        public void SetUserId(int id)
        {
            _userId = id;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(DeactivateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(_userId);
            user.IsActive = false;

            user.Username = user.Username;
            user.Email = "string";
            user.AddressStreet = "string";
            user.AddressCity = "string";
            user.Website = "string";
            user.Password = "string";
            user.GeoLatitude = 0;
            user.GeoLongitude = 0;
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

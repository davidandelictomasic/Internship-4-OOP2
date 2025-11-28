
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class UpdateUserRequest 

    {
        public int UserId { get; set; }
        public string NewName { get; set; }
        public string NewUsername { get; set; }
        public string NewEmail { get; set; }
        public string NewAddressStreet { get; set; }
        public string NewAddressCity { get; set; }
        public GeoLocation NewGeoLocation { get; set; }
        public string? NewWebsite { get; set; }
        public string NewPassword { get; set; }

    }
    public class UpdateUserRequestHandler : RequestHandler<UpdateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public UpdateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(UpdateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(request.UserId);
            user.Name = request.NewName;
            user.Username = request.NewUsername;
            user.Email = request.NewEmail;
            user.AddressStreet = request.NewAddressStreet;
            user.AddressCity = request.NewAddressCity;
            user.Website = request.NewWebsite;
            user.Password = request.NewPassword;


        
            var validationResult = await user.Create(_unitOfWork.Repository);
            result.SetValidationResult(validationResult.ValidationResult);
            if (result.HasError)
                return result;
            _unitOfWork.Repository.Update(user);
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

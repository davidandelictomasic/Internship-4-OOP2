
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class UpdateUserRequest 

    {
        
        public string NewName { get; set; }
        public string NewUsername { get; set; }
        public string NewEmail { get; set; }
        public string NewAddressStreet { get; set; }
        public string NewAddressCity { get; set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
        public string? NewWebsite { get; set; }
        public string NewPassword { get; set; }

        

    }
    public class UpdateUserRequestHandler : RequestHandler<UpdateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        private int _userId;
        public UpdateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        public void SetUserId(int id)
        {
            _userId = id;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(UpdateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(_userId);
            user.Name = request.NewName;
            user.Username = request.NewUsername;
            user.Email = request.NewEmail;
            user.AddressStreet = request.NewAddressStreet;
            user.AddressCity = request.NewAddressCity;
            user.Website = request.NewWebsite;
            user.Password = request.NewPassword;
            user.GeoLatitude = request.GeoLatitude;
            user.GeoLongitude = request.GeoLongitude;



            var validationResult = await user.Update(_unitOfWork.Repository);
            result.SetValidationResult(validationResult.ValidationResult);
            if (result.HasError)
                return result;
            _unitOfWork.Repository.Update(user);
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

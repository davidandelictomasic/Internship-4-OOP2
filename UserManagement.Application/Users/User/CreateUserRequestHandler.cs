
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Persistence.Users;
using UserManagement.Domain.Entities.Users;
namespace UserManagement.Application.Users.User
{
    public class CreateUserRequest
    {
        public string Name { get;  set; }
        public string Username { get;  set; }
        public string Email { get;  set; }
        public string AddressStreet { get;  set; }
        public string AddressCity { get;  set; }
        public double GeoLatitude { get; set; }
        public double GeoLongitude { get; set; }
        public string? Website { get;  set; }
        public string Password { get;  set; }
        
    }
    public class CreateUserRequestHandler : RequestHandler<CreateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public CreateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(CreateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = new Domain.Entities.Users.User
            {
                Name = request.Name,
                Username = request.Username,
                Email = request.Email,
                AddressStreet = request.AddressStreet,
                AddressCity = request.AddressCity,                
                Website = request.Website,
                Password = Guid.NewGuid().ToString(),
                GeoLongitude = request.GeoLongitude,
                GeoLatitude = request.GeoLatitude


            };
            var validationResult = await user.Create(_unitOfWork.Repository);
            result.SetValidationResult(validationResult.ValidationResult);
            if (result.HasError)
                return result;
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

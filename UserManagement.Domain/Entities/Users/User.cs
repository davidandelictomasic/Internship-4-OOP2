
using UserManagement.Domain.Abstractions;
using UserManagement.Domain.Common.Model;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Users;


namespace UserManagement.Domain.Entities.Users
{
    public class User : Entity
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
        
        public bool IsActive { get;  set; } = true;

        public const int NameMaxLength = 100;
        public const int AddressStreetMaxLength = 150;
        public const int AddressCityMaxLength = 100;
        public const int WebsiteMaxLength = 100;

        public async Task<Result<bool>> Create(IUserRepository userRepository)
        {
            var validationResult = await CreateOrUpdateValidation();
            if(validationResult.HasError)
                return new Result<bool>(false, validationResult);
            await userRepository.InsertAsync(this);
            return new Result<bool>(true, validationResult);


        }
        public async Task<Common.Validation.ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new Common.Validation.ValidationResult();
            if (Name?.Length > NameMaxLength)
                validationResult.AddValidationItem(UserValidationItems.User.NameMaxLength);


            
            return validationResult;
        }
        public async Task<Result<bool>> Update(IUserRepository userRepository)
        {
            var validationResult = await CreateOrUpdateValidation();
            if (validationResult.HasError)
                return new Result<bool>(false, validationResult);

            userRepository.Update(this);
            return new Result<bool>(true, validationResult);
        }
    }
}

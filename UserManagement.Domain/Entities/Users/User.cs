
using UserManagement.Domain.Abstractions;
using UserManagement.Domain.Common.Model;
using UserManagement.Domain.Common.Validation;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Common;
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
            var validationResult = await CreateOrUpdateValidation(userRepository);
            if(validationResult.HasError)
                return new Result<bool>(false, validationResult);
            await userRepository.InsertAsync(this);
            return new Result<bool>(true, validationResult);


        }
        public async Task<ValidationResult> CreateOrUpdateValidation(IUserRepository userRepository)
        {
            var validationResult = new ValidationResult();
            if (Name?.Length > NameMaxLength)
                validationResult.AddValidationItem(UserValidationItems.User.NameMaxLength);
            if (AddressStreet?.Length > AddressStreetMaxLength)
                validationResult.AddValidationItem(UserValidationItems.User.AddressStreetNameMaxLength);
            if (AddressCity?.Length > AddressCityMaxLength)
                validationResult.AddValidationItem(UserValidationItems.User.AddressCityNameMaxLength);
            if(Website?.Length > WebsiteMaxLength)
                validationResult.AddValidationItem(UserValidationItems.User.WebsiteMaxLength);
            if (!EmailValidator.IsValidEmail(Email))
                validationResult.AddValidationItem(UserValidationItems.User.EmailInvalid);
            if (!UrlValidator.IsValidUrl(Website))
                validationResult.AddValidationItem(UserValidationItems.User.WebisteValidUrlPattern);
            var existingUser = await userRepository.GetByUsernameAsync(Username);
            if (existingUser != null)
                validationResult.AddValidationItem(UserValidationItems.User.UsernameUnique);
            existingUser = await userRepository.GetByEmailAsync(Email);
            if (existingUser != null)
                validationResult.AddValidationItem(UserValidationItems.User.EmailUnique);
            return validationResult;
        }
        public async Task<Result<bool>> Update(IUserRepository userRepository)
        {
            var validationResult = await CreateOrUpdateValidation(userRepository);
            if (validationResult.HasError)
                return new Result<bool>(false, validationResult);

            userRepository.Update(this);
            return new Result<bool>(true, validationResult);
        }
    }
}

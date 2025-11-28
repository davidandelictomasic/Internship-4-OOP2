using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Abstractions;
using UserManagement.Domain.Common.Model;
using UserManagement.Domain.Common.Validation;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Users;


namespace UserManagement.Domain.Entities.Users
{
    public class User : Entity
    {
       
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string AddressStreet { get; private set; }
        public string AddressCity { get; private set; }
        public GeoLocation GeoLocation { get; private set; }
        public string? Website { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; } = true;

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
    }
}

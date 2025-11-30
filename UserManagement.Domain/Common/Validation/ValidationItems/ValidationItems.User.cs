using UserManagement.Domain.Enumumerations.Validation;

namespace UserManagement.Domain.Common.Validation.ValidationItems
{
    public static class UserValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem NameMaxLength = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_001",
                Message = $"Name exceeds maximum length({Entities.Users.User.NameMaxLength})."
            };
            public static readonly ValidationItem UsernameUnique = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_002",
                Message = $"Username needs to be unique."
            };
            public static readonly ValidationItem EmailUnique = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_003",
                Message = $"Email needs to be unique."
            };
            public static readonly ValidationItem EmailInvalid = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_004",
                Message = $"Please enter a valid email address (e.g., user@example.com)."
            };
            public static readonly ValidationItem WebsiteMaxLength = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_005",
                Message = $"Name exceeds maximum length({Entities.Users.User.WebsiteMaxLength})."
            };
            public static readonly ValidationItem WebisteValidUrlPattern = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_006",
                Message = $"Please enter a valid URL."
            };
            public static readonly ValidationItem AlreadyActive = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BusinessRule, 
                Code = $"{CodePrefix}_007",
                Message = "User is already active."
            };
            public static readonly ValidationItem AlreadyInactive = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BusinessRule, 
                Code = $"{CodePrefix}_008",
                Message = "User is already inactive."
            };
            public static readonly ValidationItem AddressStreetNameMaxLength = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_009",
                Message = $"Address street name exceeds maximum length({Entities.Users.User.AddressStreetMaxLength})."
            };
            public static readonly ValidationItem AddressCityNameMaxLength = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_010",
                Message = $"Address city name exceeds maximum length({Entities.Users.User.AddressCityMaxLength})."
            };



        }
    }
}

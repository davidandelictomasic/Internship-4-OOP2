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
            public static readonly ValidationItem EmailValid = new ValidationItem
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

        }
    }
}

using UserManagement.Domain.Enumumerations.Validation;

namespace UserManagement.Domain.Common.Validation.ValidationItems
{
    public static class CompanyValidationItems
    {
        public static class Company
        {
            public static string CodePrefix = nameof(Company);

            public static readonly ValidationItem NameMaxLength = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_001",
                Message = $"Name exceeds maximum length({Entities.Companies.Company.NameMaxLength})."
            };
            public static readonly ValidationItem NameUnique = new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.FormalValidation,
                Code = $"{CodePrefix}_002",
                Message = $"Username needs to be unique."
            };


        }
    }
}

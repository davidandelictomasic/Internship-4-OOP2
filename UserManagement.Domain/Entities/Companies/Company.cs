using UserManagement.Domain.Abstractions;
using UserManagement.Domain.Common.Model;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Domain.Entities.Companies
{
    public class Company : Entity
    {
        public const int NameMaxLength = 150;
        public string Name { get;  set; }

        public async Task<Result<bool>> Create(ICompanyRepository companyRepository)
        {
            var validationResult = await CreateOrUpdateValidation();
            if (validationResult.HasError)
                return new Result<bool>(false, validationResult);
            await companyRepository.InsertAsync(this);
            return new Result<bool>(true, validationResult);


        }
        public async Task<Common.Validation.ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new Common.Validation.ValidationResult();
            if (Name?.Length > NameMaxLength)
                validationResult.AddValidationItem(CompanyValidationItems.Company.NameMaxLength);



            return validationResult;
        }
        public async Task<Result<bool>> Update(ICompanyRepository companyRepository)
        {
            var validationResult = await CreateOrUpdateValidation();
            if (validationResult.HasError)
                return new Result<bool>(false, validationResult);

            companyRepository.Update(this);
            return new Result<bool>(true, validationResult);
        }
    }
}

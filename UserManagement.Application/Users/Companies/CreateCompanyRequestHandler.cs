
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.Companies
{
    public class CreateCompanyRequest
    {
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
         
        

    }
    public class CreateCompanyRequestHandler : RequestHandler<CreateCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;
        private readonly IUserUnitOfWork _userUnitOfWork;
        public CreateCompanyRequestHandler(ICompanyUnitOfWork companyUnitOfWork,IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
            _userUnitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(CreateCompanyRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _userUnitOfWork.Repository.GetByUsernameAndPasswordAsync(request.UserUsername, request.UserPassword);
            if (user != null && user.IsActive)
            {
                var company = new Domain.Entities.Companies.Company
                {
                    Name = request.Name
                };
                var validationResult = await company.Create(_unitOfWork.Repository);
                result.SetValidationResult(validationResult.ValidationResult);
                if (result.HasError)
                    return result;
                await _unitOfWork.SaveAsync();
                result.SetResult(new SuccessPostResponse(company.Id));
                return result;
            }
            else
                return result;

                
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

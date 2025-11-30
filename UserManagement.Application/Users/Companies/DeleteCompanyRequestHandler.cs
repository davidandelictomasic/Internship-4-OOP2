using UserManagement.Application.Common.Model;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.Companies
{
    public class DeleteCompanyRequest

    {
        public int CompanyId { get; init; }
        public string UserUsername { get; init; }
        public string UserPassword { get; init; }
        public DeleteCompanyRequest(int companyId, string userName, string userPassword)
        {
            CompanyId = companyId;
            UserUsername = userName;
            UserPassword = userPassword;
        }

    }
    public class DeleteCompanyRequestHandler : RequestHandler<DeleteCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;
        private readonly IUserUnitOfWork _userUnitOfWork;
        public DeleteCompanyRequestHandler(ICompanyUnitOfWork companyUnitOfWork, IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
            _userUnitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(DeleteCompanyRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _userUnitOfWork.Repository.GetByUsernameAndPasswordAsync(request.UserUsername, request.UserPassword);
            if (user != null && user.IsActive)
            {
                var company = await _unitOfWork.Repository.GetById(request.CompanyId);
                if(company == null)
                {
                    return result;
                }
                var validationResult = await company.Update(_unitOfWork.Repository);


                result.SetValidationResult(validationResult.ValidationResult);
                await _unitOfWork.Repository.DeleteAsync(request.CompanyId);
                await _unitOfWork.SaveAsync();

                return result;
            }
            else
            {
                return result;
            }
                
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

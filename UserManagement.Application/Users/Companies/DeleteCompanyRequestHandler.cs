using UserManagement.Application.Common.Model;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.Companies
{
    public class DeleteCompanyRequest

    {
        public int CompanyId { get; init; }
        public string UserName { get; init; }
        public string UserEmail { get; init; }
        public DeleteCompanyRequest(int companyId, string userName, string userEmail)
        {
            CompanyId = companyId;
            UserName = userName;
            UserEmail = userEmail;
        }

    }
    public class DeleteCompanyRequestHandler : RequestHandler<DeleteCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;
        public DeleteCompanyRequestHandler(ICompanyUnitOfWork companyUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(DeleteCompanyRequest request, Result<SuccessPostResponse> result)
        {
            var company = await _unitOfWork.Repository.GetById(request.CompanyId);
            var validationResult = await company.Create(_unitOfWork.Repository);
            // isActive logic

            result.SetValidationResult(validationResult.ValidationResult);
            await _unitOfWork.Repository.DeleteAsync(request.CompanyId);
            await _unitOfWork.SaveAsync();
            result.SetResult(new SuccessPostResponse(company.ID));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

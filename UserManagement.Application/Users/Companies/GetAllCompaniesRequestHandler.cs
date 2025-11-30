using UserManagement.Application.Common.Model;
using UserManagement.Application.DTOs.Companies;
using UserManagement.Application.DTOs.Users;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.Companies
{
    public class GetAllCompaniesRequest { }
    public class GetAllCompaniesRequestHandler : RequestHandler<GetAllCompaniesRequest, List<CompanyDto>>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;
        private string _userUsername;
        private string _userPassword;
        public void SetUserData(string username,string password)
        {
            _userUsername = username;
            _userPassword = password;
        }
        public GetAllCompaniesRequestHandler(ICompanyUnitOfWork companyUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
        }
        protected async override Task<Result<List<CompanyDto>>> HandleRequest(GetAllCompaniesRequest request, Result<List<CompanyDto>> result)
        {

            var company = await _unitOfWork.Repository.Get();


            var dto = company.Values
                .Select(CompanyDto.FromEntity)
                .ToList();

            result.SetResult(dto);
            return result;
        }       

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

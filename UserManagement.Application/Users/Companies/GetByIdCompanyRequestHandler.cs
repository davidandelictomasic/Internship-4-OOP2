using UserManagement.Application.Common.Model;
using UserManagement.Application.DTOs.Companies;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.Companies
{
    public class GetByIdCompanyRequest
    {
        public int Id { get; init; }
        public GetByIdCompanyRequest(int id)
        {
            Id = id;
        }

    }
    public class GetByIdCompanyRequestHandler : RequestHandler<GetByIdCompanyRequest, CompanyDto>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;
        public GetByIdCompanyRequestHandler(ICompanyUnitOfWork companyUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
        }
        private string _userUsername;
        private string _userPassword;
        public void SetUserData(string username, string password)
        {
            _userUsername = username;
            _userPassword = password;
        }
        protected async override Task<Result<CompanyDto>> HandleRequest(GetByIdCompanyRequest request, Result<CompanyDto> result)
        {
            var company = await _unitOfWork.Repository.GetById(request.Id);
            var dto = CompanyDto.FromEntity(company);
            if (dto != null)
                result.SetResult(dto);
            return result;


        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

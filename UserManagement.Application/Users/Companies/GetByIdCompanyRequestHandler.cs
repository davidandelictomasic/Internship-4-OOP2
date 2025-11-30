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
        private readonly IUserUnitOfWork _userUnitOfWork;
        public GetByIdCompanyRequestHandler(ICompanyUnitOfWork companyUnitOfWork,IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
            _userUnitOfWork = userUnitOfWork;
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
            var user = await _userUnitOfWork.Repository.GetByUsernameAndPasswordAsync(_userUsername, _userPassword);
            if (user != null && user.IsActive)
            {
                var company = await _unitOfWork.Repository.GetById(request.Id);
                if(company == null)
                {
                    return result;
                }
                var dto = CompanyDto.FromEntity(company);
                if (dto != null)
                    result.SetResult(dto);
                return result;
            }
            return result;



        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

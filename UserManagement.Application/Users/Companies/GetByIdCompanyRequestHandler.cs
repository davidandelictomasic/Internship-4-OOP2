using UserManagement.Application.Common.Model;
using UserManagement.Application.DTOs.Companies;
using UserManagement.Domain.Persistence.Companies;

namespace UserManagement.Application.Users.Companies
{
    public class GetByIdCompanyRequest
    {
        public int Id { get; init; }
    }
    public class GetByIdCompanyRequestHandler : RequestHandler<GetByIdCompanyRequest, CompanyDto>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;

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
            throw new NotImplementedException();
        }
    }
}

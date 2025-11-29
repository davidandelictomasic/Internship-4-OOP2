using System;
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.Companies
{
    public class UpdateCompanyRequest

    {
        public int UserId { get; set; }
        public string NewName { get; set; }
        public string NewUsername { get; set; }
        public string NewEmail { get; set; }
        public string NewAddressStreet { get; set; }
        public string NewAddressCity { get; set; }
        public GeoLocation NewGeoLocation { get; set; }
        public string? NewWebsite { get; set; }
        public string NewPassword { get; set; }

    }
    public class UpdateCompanyRequestHandler : RequestHandler<UpdateCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;
        public UpdateCompanyRequestHandler(ICompanyUnitOfWork companyUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(UpdateCompanyRequest request, Result<SuccessPostResponse> result)
        {
            var company = await _unitOfWork.Repository.GetById(request.UserId);
            company.Name = request.NewName;        



            var validationResult = await company.Create(_unitOfWork.Repository);
            result.SetValidationResult(validationResult.ValidationResult);
            if (result.HasError)
                return result;
            _unitOfWork.Repository.Update(company);
            await _unitOfWork.SaveAsync();
            result.SetResult(new SuccessPostResponse(company.Id));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

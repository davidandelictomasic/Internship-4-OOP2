using System;
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.Companies
{
    public class UpdateCompanyRequest

    {
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string NewName { get; set; }
       

    }
    public class UpdateCompanyRequestHandler : RequestHandler<UpdateCompanyRequest, SuccessPostResponse>
    {
        private readonly ICompanyUnitOfWork _unitOfWork;
        private readonly IUserUnitOfWork _userUnitOfWork;
        private int _companyId;
        public UpdateCompanyRequestHandler(ICompanyUnitOfWork companyUnitOfWork,IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = companyUnitOfWork;
            _userUnitOfWork = userUnitOfWork;
        }
        public void SetCompanyId(int id)
        {
            _companyId = id;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(UpdateCompanyRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _userUnitOfWork.Repository.GetByUsernameAndPasswordAsync(request.UserUsername, request.UserPassword);
            if (user != null && user.IsActive)
            {
                var company = await _unitOfWork.Repository.GetById(_companyId);
                if(company == null)
                {
                    return result;
                }
                company.Name = request.NewName;
                var validationResult = await company.Update(_unitOfWork.Repository);
                result.SetValidationResult(validationResult.ValidationResult);
                if (result.HasError)
                    return result;
                _unitOfWork.Repository.Update(company);
                await _unitOfWork.SaveAsync();
                result.SetResult(new SuccessPostResponse(company.Id));
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

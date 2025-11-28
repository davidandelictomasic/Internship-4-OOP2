using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Common.Validation;
using UserManagement.Domain.Common.Validation.ValidationItems;
using UserManagement.Domain.Entities.Users;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class ActivateUserRequest

    {
        public int UserId { get; init; }

    }
    public class ActivateUserRequestHandler : RequestHandler<ActivateUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public ActivateUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(ActivateUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(request.UserId);
            var validationResult = await user.Create(_unitOfWork.Repository);
            if (user.IsActive)
            {
                
                validationResult.ValidationResult.AddValidationItem(UserValidationItems.User.AlreadyActive);                
                result.SetValidationResult(validationResult.ValidationResult);
                return result;
            }

            user.IsActive = true;   
            result.SetValidationResult(validationResult.ValidationResult);      
            
            await _unitOfWork.SaveAsync();
            result.SetResult(new SuccessPostResponse(user.ID));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

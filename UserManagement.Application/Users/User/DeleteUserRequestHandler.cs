using UserManagement.Application.Common.Model;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class DeleteUserRequest

    {
        public int UserId { get; init; }

    }
    public class DeleteUserRequestHandler : RequestHandler<DeleteUserRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public DeleteUserRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(DeleteUserRequest request, Result<SuccessPostResponse> result)
        {
            var user = await _unitOfWork.Repository.GetById(request.UserId);
            var validationResult = await user.Create(_unitOfWork.Repository);     

            
            result.SetValidationResult(validationResult.ValidationResult);
            await _unitOfWork.Repository.DeleteAsync(request.UserId);
            await _unitOfWork.SaveAsync();
            result.SetResult(new SuccessPostResponse(user.Id));
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

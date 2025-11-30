using UserManagement.Application.Common.Interfaces;
using UserManagement.Application.Common.Model;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class ImportExternalUsersRequest { }
    public class ImportExternalUsersRequestHandler : RequestHandler<ImportExternalUsersRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        private readonly IUserCacheService _userCacheService;
        public ImportExternalUsersRequestHandler(
           IUserUnitOfWork userUnitOfWork,
           IUserCacheService userCacheService)
        {
            _unitOfWork = userUnitOfWork;
            _userCacheService = userCacheService;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(ImportExternalUsersRequest request, Result<SuccessPostResponse> result)
        {
            var users = await _userCacheService.GetUsersFromCacheOrApiAsync();
            if(users != null)
            {
                foreach (var user in users)
                {
                    var validationResult = await user.Create(_unitOfWork.Repository);
                    await _unitOfWork.SaveAsync();


                }
            }
            

            
            result.SetResult(new SuccessPostResponse());
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

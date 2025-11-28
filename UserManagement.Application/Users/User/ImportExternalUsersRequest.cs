using UserManagement.Application.Common.Model;
using UserManagement.Domain.Persistence.Users;

namespace UserManagement.Application.Users.User
{
    public class ImportExternalUsersRequest {   }
    public class ImportExternalUsersRequestHandler : RequestHandler<ImportExternalUsersRequest, SuccessPostResponse>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public ImportExternalUsersRequestHandler(IUserUnitOfWork userUnitOfWork)
        {
            _unitOfWork = userUnitOfWork;
        }
        protected async override Task<Result<SuccessPostResponse>> HandleRequest(ImportExternalUsersRequest request, Result<SuccessPostResponse> result)
        {

            result.SetResult(new SuccessPostResponse());
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}

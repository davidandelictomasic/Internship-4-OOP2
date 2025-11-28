
using UserManagement.Domain.Persistence.Common;

namespace UserManagement.Domain.Persistence.Users
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IUserRepository Repository { get; }
        
    }
}

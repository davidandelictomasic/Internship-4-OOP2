
namespace UserManagement.Domain.Persistence.Common
{
    public interface IUnitOfWork
    {        
        Task SaveAsync();

    }
}

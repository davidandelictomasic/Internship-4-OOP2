using UserManagement.Domain.Persistence.Common;

namespace UserManagement.Domain.Persistence.Companies
{
    public interface ICompanyUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Repository { get; }
    }
}

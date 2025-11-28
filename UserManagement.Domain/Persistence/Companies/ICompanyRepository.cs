using UserManagement.Domain.Entities.Companies;
using UserManagement.Domain.Persistence.Common;

namespace UserManagement.Domain.Persistence.Companies
{
    public interface ICompanyRepository : IRepository<Company, int>
    {
        Task<Company> GetById(int id);
    }
}

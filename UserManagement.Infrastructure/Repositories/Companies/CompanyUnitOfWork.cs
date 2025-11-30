using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;
using UserManagement.Infrastructure.Database;

namespace UserManagement.Infrastructure.Repositories.Companies
{
    public class CompanyUnitOfWork : ICompanyUnitOfWork
    {
        private readonly CompanyDbContext _dbContext;
        public ICompanyRepository Repository { get; set; }

        public CompanyUnitOfWork(CompanyDbContext dbContext, ICompanyRepository companyRepository)
        {
            _dbContext = dbContext;
            Repository = companyRepository;
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

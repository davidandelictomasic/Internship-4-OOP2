using UserManagement.Domain.Persistence.Common;
using UserManagement.Infrastructure.Database;

namespace UserManagement.Infrastructure.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

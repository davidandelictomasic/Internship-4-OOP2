using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UserManagement.Domain.Persistence.Common;
using UserManagement.Infrastructure.Database;

namespace UserManagement.Infrastructure
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

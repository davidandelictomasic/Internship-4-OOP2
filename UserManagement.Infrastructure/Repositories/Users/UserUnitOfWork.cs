using UserManagement.Domain.Persistence.Users;
using UserManagement.Infrastructure.Database;

namespace UserManagement.Infrastructure.Repositories.Users
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IUserRepository Repository { get; set; }
        public UserUnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            Repository = userRepository;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

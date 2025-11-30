using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Users;

namespace UserManagement.Infrastructure.Database
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
            modelBuilder.HasDefaultSchema("public");
        }
        
    }
}


using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Companies;

namespace UserManagement.Infrastructure.Database
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
           : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyDbContext).Assembly);
            modelBuilder.HasDefaultSchema("public");

        }
    }
}

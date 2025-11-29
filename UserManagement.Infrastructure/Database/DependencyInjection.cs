using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain.Persistence.Common;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;
using UserManagement.Infrastructure.Dapper;
using UserManagement.Infrastructure.Repositories.Common;
using UserManagement.Infrastructure.Repositories.Companies;
using UserManagement.Infrastructure.Repositories.Users;
using UserManagement.Infrastructure.Service;

namespace UserManagement.Infrastructure.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabase(services, configuration);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            services.AddScoped<DbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUnitOfWork, CompanyUnitOfWork>();
            services.AddScoped<IUserCacheService, ExternalUserCacheService>();
            services.AddScoped<IExternalUserApi, ExternalUserApi>();
            

            services.AddMemoryCache();
            services.AddSingleton<IDapperManager>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                string cs = config.GetConnectionString("Database");
                return new DapperManager(cs);
            });

        }
    }
}

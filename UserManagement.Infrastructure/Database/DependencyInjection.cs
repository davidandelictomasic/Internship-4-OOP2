using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain.Persistence.Common;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Domain.Persistence.Users;
using UserManagement.Infrastructure.Dapper;
using UserManagement.Infrastructure.Dapper.Companies;
using UserManagement.Infrastructure.Dapper.Users;
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
            //string? connectionString = configuration.GetConnectionString("Database");
            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    throw new ArgumentNullException(nameof(connectionString));
            //}
            string? userDbConnection = configuration.GetConnectionString("UserDatabase");
            string? companyDbConnection = configuration.GetConnectionString("CompanyDatabase");

            if (string.IsNullOrWhiteSpace(userDbConnection))
                throw new ArgumentNullException(nameof(userDbConnection));
            if (string.IsNullOrWhiteSpace(companyDbConnection))
                throw new ArgumentNullException(nameof(companyDbConnection));
            services.AddScoped<DbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetRequiredService<UserDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetRequiredService<CompanyDbContext>());

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(userDbConnection));
            
            services.AddDbContext<UserDbContext>(options =>
                options.UseNpgsql(userDbConnection));

            services.AddDbContext<CompanyDbContext>(options =>
                options.UseNpgsql(companyDbConnection));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUnitOfWork, CompanyUnitOfWork>();
            services.AddScoped<IUserCacheService, ExternalUserCacheService>();
            services.AddScoped<IExternalUserApi, ExternalUserApi>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddMemoryCache();
            //services.AddSingleton<IDapperManager>(sp =>
            //{
            //    var config = sp.GetRequiredService<IConfiguration>();
            //    string cs = config.GetConnectionString("Database");
            //    return new DapperManager(cs);
            //});
            services.AddSingleton<ICompanyDapperManager>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                string cs = config.GetConnectionString("CompanyDatabase"); 
                return new CompanyDapperManager(cs);
            });

            services.AddSingleton<IUserDapperManager>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                string cs = config.GetConnectionString("UserDatabase");
                return new UserDaperManager(cs);
            });

        }
    }
}

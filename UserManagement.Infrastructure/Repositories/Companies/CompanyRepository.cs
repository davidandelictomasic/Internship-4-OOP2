using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities.Companies;
using UserManagement.Domain.Persistence.Companies;
using UserManagement.Infrastructure.Dapper;
using UserManagement.Infrastructure.Dapper.Companies;
using UserManagement.Infrastructure.Database;
using UserManagement.Infrastructure.Repositories.Common;

namespace UserManagement.Infrastructure.Repositories.Companies
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        //private readonly ApplicationDbContext _dbContext;
        //private readonly IDapperManager _dapperManager;
        //public CompanyRepository(DbContext dbContext, IDapperManager dapperManager) : base(dbContext)
        //{
        //    _dapperManager = dapperManager;
        //}
        private readonly ICompanyDapperManager _dapperManager;

        private readonly CompanyDbContext _dbContext;

        public CompanyRepository(CompanyDbContext dbContext, ICompanyDapperManager dapperManager)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _dapperManager = dapperManager;
        }
        public async Task<Company> GetById(int id)
        {
            var sql = "SELECT id as ID, name as Name FROM public.\"companies\" WHERE Id = @Id";
            var parameters = new { Id = id };
            return await _dapperManager.QuerySingleAsync<Company>(sql, parameters);
        }
    }
}

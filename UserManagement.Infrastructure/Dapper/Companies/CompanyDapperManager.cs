namespace UserManagement.Infrastructure.Dapper.Companies
{
    public class CompanyDapperManager : DapperManager, ICompanyDapperManager
    {
        public CompanyDapperManager(string connectionString) : base(connectionString)
        {
        }
    }
}

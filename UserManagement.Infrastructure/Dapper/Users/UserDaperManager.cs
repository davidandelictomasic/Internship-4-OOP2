namespace UserManagement.Infrastructure.Dapper.Users
{
    public class UserDaperManager : DapperManager, IUserDapperManager
    {
        public UserDaperManager(string connectionString) : base(connectionString)
        {
        }
    }
}

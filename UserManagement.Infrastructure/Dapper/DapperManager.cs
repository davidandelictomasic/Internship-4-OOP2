using Dapper;
using Npgsql;

namespace UserManagement.Infrastructure.Dapper
{
    public class DapperManager : IDapperManager
    {
        private readonly string _connectionString;
        public DapperManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        private NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
        public async Task ExecuteAsync(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();

            await connection.ExecuteAsync(sql, param);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();
            var result = await connection.QueryAsync<T>(sql, param);
            return result.ToList();
        }

        public async Task<T?> QuerySingleAsync<T>(string sql, object? param = null)
        {

            using var connection = CreateConnection();
            await connection.OpenAsync();

            return await connection.QuerySingleOrDefaultAsync<T>(sql, param);

        }
    }
}

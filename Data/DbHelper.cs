using Microsoft.Data.SqlClient;

namespace EchoPOS.Data
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();  // Ensure connection is opened asynchronously
            return connection;
        }
    }
}

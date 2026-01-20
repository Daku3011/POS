using Dapper;
using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace EchoPOS.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int AddUser(Users user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var userId = connection.ExecuteScalar<int>("InsertUser", new
                {
                    user.Name,
                    user.Email,
                    user.Password,
                    PasswordHash = HashPassword(user.Password), // ✅ Hashed password
                    user.Role,
                    user.Phone,
                    // Created_At = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") // ✅ Correct format
                }, commandType: CommandType.StoredProcedure);

                return userId;
            }
        }

        public Users GetUserById(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Users>
                    ("sp_GetUserById", new { User_Id = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Users> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Users>("sp_GetAllUser", commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateUser(Users user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_UpdateUser", new
                {
                    user.User_Id,
                    user.Name,
                    user.Email,
                    Password = HashPassword(user.Password), // ✅ Matches SQL parameter type
                    user.Role,
                    user.Phone
                }, commandType: CommandType.StoredProcedure);
            }
        }


        public void DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_DeleteUser",
                    new { User_Id = userId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        // ✅ Secure Password Hashing (SHA-256)
        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

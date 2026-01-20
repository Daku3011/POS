using Dapper;
using Microsoft.Data.SqlClient;

namespace EchoPOS.Repository
{
    public class Audit_Log
    {
        private readonly string _connectionString;



        public void Log(int userId, string action, string ipAddress = null, string sessionId = null)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"INSERT INTO Audit_Log (User_Id, Action, IpAddress, SessionId) 
                        VALUES (@UserId, @Action, @IpAddress, @SessionId)";
            connection.Execute(sql, new { UserId = userId, Action = action, IpAddress = ipAddress, SessionId = sessionId });
        }

    }
}

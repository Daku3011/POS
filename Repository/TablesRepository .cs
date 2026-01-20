using Dapper;
using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchoPOS.Repository
{
    public class TablesRepository : ITablesRepository
    {
        private readonly string _connectionString;

        public TablesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int AddTable(Tables table)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.ExecuteScalar<int>("sp_InsertTable",
                    new { table.Table_Number, table.Capacity, table.Status, table.Location },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateTable(Tables table)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("sp_UpdateTable",
                    new { table.Table_Id, table.Table_Number, table.Capacity, table.Status, table.Location },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTable(int tableId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("sp_DeleteTable",
                    new { Table_Id = tableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Tables GetTableById(int tableId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.QueryFirstOrDefault<Tables>("sp_GetTableById",
                    new { Table_Id = tableId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Tables> GetAllTables()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Tables>("sp_GetAllTables",
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateTableStatus(int tableId, string status)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("sp_UpdateTable",
                    new { Table_Id = tableId, Status = status },
                    commandType: CommandType.StoredProcedure);
            }
        }

    }

}

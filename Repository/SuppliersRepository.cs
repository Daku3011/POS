using Dapper;

using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchooPays.Repository
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly string _connectionString;

        // ✅ Use IConfiguration to fetch connection string
        public SuppliersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // ✅ Get All Suppliers
        public async Task<IEnumerable<Suppliers>> GetAllSuppliersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Suppliers>("sp_GetAllSuppliers", commandType: CommandType.StoredProcedure);
        }

        // ✅ Get Supplier by ID
        public async Task<Suppliers> GetSupplierByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Suppliers>(
                "sp_GetSupplierById",
                new { Supplier_Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        // ✅ Add Supplier


        // ✅ Update Supplier
        public async Task<bool> UpdateSupplierAsync(Suppliers supplier)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "sp_UpdateSupplier",
                new { supplier.Supplier_Id, supplier.Name, supplier.Contact, supplier.Email, supplier.Address },
                commandType: CommandType.StoredProcedure
            );
            return true;
        }

        // ✅ Delete Supplier
        public async Task<bool> DeleteSupplierAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "sp_DeleteSuppliers",
                new { Supplier_Id = id },
                commandType: CommandType.StoredProcedure
            );
            return true;
        }




        public void sp_DeleteSuppliers(int Supplier_id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteSuppliers", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Supplier_id", Supplier_id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        public void sp_AddSupplier(Suppliers supplier)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddSupplier", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@Contact", supplier.Contact);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public void sp_UpdateSupplier(Suppliers suppliers)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateSupplier", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Supplier_Id", suppliers.Supplier_Id);
                cmd.Parameters.AddWithValue("@Name", suppliers.Name);
                cmd.Parameters.AddWithValue("@Contact", suppliers.Contact);
                cmd.Parameters.AddWithValue("@Email", suppliers.Email);
                cmd.Parameters.AddWithValue("@Address", suppliers.Address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Suppliers> sp_GetSupplierById(int Supplier_Id)
        {
            List<Suppliers> supp = new List<Suppliers>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetSupplierById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Supplier_Id", Supplier_Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    supp.Add(new Suppliers
                    {
                        Supplier_Id = dr.GetInt32(dr.GetOrdinal("Supplier_Id")),
                        Name = dr.GetString(dr.GetOrdinal("Name")),
                        Contact = dr.GetString(dr.GetOrdinal("Contact")),
                        Email = dr.GetString(dr.GetOrdinal("Email")),
                        Address = dr.GetString(dr.GetOrdinal("Address"))
                    });
                }

            }
            return supp;

        }
    }
}

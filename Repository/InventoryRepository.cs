using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchoPOS.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddInventory(Inventory inventory)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertInventory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ensure that the parameters are passed with correct types.
                    cmd.Parameters.AddWithValue("@ProductName", inventory.ProductName);

                    // If Quantity is an integer, ensure it's being passed as an integer and not a string
                    cmd.Parameters.AddWithValue("@Quantity", inventory.Quantity);

                    cmd.Parameters.AddWithValue("@Price", inventory.Price);

                    // Handle Supplier_ID as nullable
                    cmd.Parameters.AddWithValue("@Supplier_ID", inventory.Supplier_ID ?? (object)DBNull.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery(); // Executes the query that does not return a result
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL exception, logging the error, etc.
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }


        public Inventory GetInventoryById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetInventoryById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventoryID", id);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Inventory
                            {
                                InventoryID = (int)reader["InventoryID"],
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = reader["Quantity"].ToString(),
                                Price = (decimal)reader["Price"],
                                Supplier_ID = reader["Supplier_ID"] != DBNull.Value ? (int)reader["Supplier_ID"] : (int?)null,
                                LastUpdated = (DateTime)reader["LastUpdated"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> inventoryList = new List<Inventory>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllInventory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inventoryList.Add(new Inventory
                            {
                                InventoryID = (int)reader["InventoryID"],
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = reader["Quantity"].ToString(), // Could convert to int if needed
                                Price = (decimal)reader["Price"],
                                SupplierName = reader["Name"].ToString(), // FIXED
                                // LastUpdated = (DateTime)reader["LastUpdated"] // Only if available
                            });
                        }
                    }
                }
            }
            return inventoryList;
        }


        public void UpdateInventory(Inventory inventory)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateInventory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@InventoryID", inventory.InventoryID);
                    cmd.Parameters.AddWithValue("@ProductName", inventory.ProductName);
                    cmd.Parameters.AddWithValue("@Quantity", inventory.Quantity ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", inventory.Price);
                    cmd.Parameters.AddWithValue("@Supplier_ID", inventory.Supplier_ID ?? (object)DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Update failed! Check if InventoryID exists.");
                    }
                }
            }
        }


        public void DeleteInventory(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteInventory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventoryID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

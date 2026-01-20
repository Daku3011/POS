using Dapper;
using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EchoPOS.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // ✅ Get all categories
        public IEnumerable<Category> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Category>("sp_GetCategory", commandType: CommandType.StoredProcedure);
        }

        // ✅ Insert a new category
        public void sp_InsertCategory(Category category)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("sp_InsertCategory",
                new { category.Name, category.Description },
                commandType: CommandType.StoredProcedure);
        }

        // ✅ Get category by ID
        public List<Category> sp_GetCategoryByID(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Category>(
                "sp_GetCategoryByID",
                new { Category_Id = id },
                commandType: CommandType.StoredProcedure
            ).AsList();
        }

        // ✅ Update category
        public void sp_UpdateCategory(Category category)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("sp_UpdateCategory",
                new { category.Category_Id, category.Name, category.Description },
                commandType: CommandType.StoredProcedure);
        }

        // ✅ Delete category
        public void sp_DeleteCategory(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("sp_DeleteCategory",
                new { Category_Id = id },
                commandType: CommandType.StoredProcedure);
        }

        public int Add(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByID(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCategoryByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category_Id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new Category
                    {
                        Category_Id = dr.GetInt32(dr.GetOrdinal("Category_Id")),
                        Name = dr.GetString(dr.GetOrdinal("Name")),
                        Description = dr.GetString(dr.GetOrdinal("Description"))
                    };
                }
                return null; // Return null if no category is found
            }
        }

        public Category sp_GetCategory(int Category_Id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category_Id", Category_Id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new Category
                    {
                        Category_Id = dr.GetInt32(dr.GetOrdinal("Category_Id")),
                        Name = dr.GetString(dr.GetOrdinal("Name")),
                        Description = dr.GetString(dr.GetOrdinal("Description"))
                    };
                }
                return null; // Return null if no category is found
            }
        }



        public IEnumerable<Category> sp_GetCategory()
        {
            var categories = new List<Category>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) // Use while loop to read multiple rows
                {
                    categories.Add(new Category
                    {
                        Category_Id = dr.GetInt32(dr.GetOrdinal("Category_Id")),
                        Name = dr.GetString(dr.GetOrdinal("Name"))
                    });
                }
            }
            return categories; // Return the list of categories
        }

        dynamic ICategoryRepository.sp_GetCategory()
        {
            return sp_GetCategory();
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = new List<Category>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var sql = "EXEC GetAllCategories"; // Stored procedure call
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var category = new Category
                                {
                                    Category_Id = reader.GetInt32(reader.GetOrdinal("Category_Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Description = reader.GetString(reader.GetOrdinal("Description"))
                                };
                                categories.Add(category);
                            }
                        }
                    }
                }

                return categories;
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine(ex.Message);
                throw new Exception("An error occurred while fetching categories.");
            }
        }


        public List<Menu> GetAllMenuItems()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var categories = connection.Query<Category>("sp_GetAllCategories", commandType: CommandType.StoredProcedure).ToList();
                return categories;
            }
        }

        public void AddMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}


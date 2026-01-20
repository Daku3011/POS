using Dapper;
using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

public class MenuRepository : IMenuRepository
{
    private readonly string _connectionString;

    public MenuRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // Get all menu items
    public async Task<IEnumerable<Menu>> GetAllAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Menu>("sp_GetMenu", commandType: CommandType.StoredProcedure);
    }

    // Get a menu item by ID
    public async Task<Menu> GetByIdAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Menu>("sp_GetMenuItemById",
            new { Menu_Item_Id = id }, commandType: CommandType.StoredProcedure);
    }

    // Insert a new menu item
    public async Task<int> AddAsync(Menu menu)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>("sp_InsertMenu",
            new
            {
                menu.Name,
                menu.Description,
                menu.Price,
                menu.Category_Id
            }, commandType: CommandType.StoredProcedure);
    }

    // Update an existing menu item
    public async Task<bool> UpdateAsync(Menu menu)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.ExecuteAsync("sp_UpdateMenu", new
            {
                menu.Menu_Item_Id,
                menu.Name,
                menu.Description,
                menu.Price,
                menu.Category_Id,
                menu.Availability,
                menu.Image_Url // Include image URL in the parameters
            }, commandType: CommandType.StoredProcedure);

            return result > 0; // Return true if the update was successful
        }
        catch (Exception ex)
        {
            // Log the error (you could log to a file or a logging framework)
            Console.WriteLine(ex.Message);
            return false; // Return false if there was an error
        }
    }

    // Delete a menu item by ID
    public async Task DeleteAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync("sp_DeleteMenu",
            new { MenuItem_Id = id }, commandType: CommandType.StoredProcedure);
    }



    Task<bool> IMenuRepository.DeleteAsync(int menuItemId)
    {
        throw new NotImplementedException();
    }

    public void sp_DeleteMenu(int MenuItem_Id)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_DeleteMenu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MenuItem_Id", MenuItem_Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

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
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Category_Id = (int)reader["Category_Id"],
                    Name = reader["Name"].ToString()
                });
            }
            con.Close();
        }
        return categories;
    }

    public List<Category> GetCategories()
    {
        return sp_GetCategory().ToList();
    }






    public IEnumerable<Menu> GetMenuItemsByCategory(int categoryId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            return connection.Query<Menu>(
                "sp_GetMenuItemsByCategory",
                new { CategoryId = categoryId },
                commandType: CommandType.StoredProcedure
            );
        }
    }

    public IEnumerable<Menu> GetAllMenuItems()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            return connection.Query<Menu>(
                "sp_GetAllMenuItems", // Ensure this stored procedure exists in your database
                commandType: CommandType.StoredProcedure
            );
        }
    }

    List<Menu> IMenuRepository.GetAllMenuItems()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Menu> GetMenuItems()
    {
        throw new NotImplementedException();
    }

    public object GetMenuByCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Category>("sp_GetAllCategories", commandType: CommandType.StoredProcedure);
    }

    public Task<IEnumerable<Menu>> GetAllMenuItemsAsync()
    {
        throw new NotImplementedException();
    }



    public void sp_GetCategory(int Category_Id)
    {
        throw new NotImplementedException();
    }

}

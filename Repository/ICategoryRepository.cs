using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll(); // Fetch all categories (sp_GetCategory)
        int Add(Category category); // Insert a new category (sp_InsertCategory)
        bool Update(Category category); // Update an existing category (sp_UpdateCategory)
        bool Delete(int categoryId); // Delete a category (sp_DeleteCategory)
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        void sp_InsertCategory(Category category); // Direct stored procedure call for Insert
        Category GetCategoryByID(int id); // Fetch a single category by ID (sp_GetCategoryByID)
        void sp_UpdateCategory(Category category); // Direct stored procedure call for Update
        void sp_DeleteCategory(int id); // Direct stored procedure call for Delete
        List<Category> sp_GetCategoryByID(int id);
        dynamic sp_GetCategory();
        List<Category> GetCategories();
        List<Menu> GetAllMenuItems();
        void AddMenu(Menu menu);
        void UpdateOrderStatus(int orderId, string newStatus);
    }
}

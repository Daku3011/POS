using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllAsync();
        Task<Menu> GetByIdAsync(int menuItemId);
        Task<int> AddAsync(Menu menu);
        Task<bool> UpdateAsync(Menu menu);
        Task<bool> DeleteAsync(int menuItemId);

        public void sp_DeleteMenu(int MenuItem_Id);
        public void sp_GetCategory(int Category_Id);

        List<Category> GetCategories();
        List<Menu> GetAllMenuItems();

        IEnumerable<Menu> GetMenuItems();
        IEnumerable<Menu> GetMenuItemsByCategory(int categoryId);
        object GetMenuByCategory(int categoryId);

        Task<IEnumerable<Menu>> GetAllMenuItemsAsync();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

    }
}

using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IInventoryRepository
    {
        void AddInventory(Inventory inventory);
        Inventory GetInventoryById(int id);
        List<Inventory> GetAllInventory();
        void UpdateInventory(Inventory inventory);
        void DeleteInventory(int id);
    }
}

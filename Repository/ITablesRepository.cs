using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface ITablesRepository
    {
        int AddTable(Tables table);
        void UpdateTable(Tables table);
        void DeleteTable(int tableId);
        Tables GetTableById(int tableId);
        IEnumerable<Tables> GetAllTables();
        void UpdateTableStatus(int tableId, string status);
    }
}

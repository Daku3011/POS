
using EchoPOS.Models;

namespace EchooPays.Repository
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Suppliers>> GetAllSuppliersAsync(); // Index
        Task<Suppliers> GetSupplierByIdAsync(int id); // Details
        public void sp_AddSupplier(Suppliers supplier);
        public void sp_UpdateSupplier(Suppliers suppliers);

        public List<Suppliers> sp_GetSupplierById(int Supplier_Id);

        public void sp_DeleteSuppliers(int Supplier_id);
    }
}

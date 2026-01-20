using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface ITaxesRepository
    {
        object Taxes { get; set; }

        List<Taxes> GetAllTaxes();
        Taxes GetTaxById(int id);
        void AddTax(Taxes taxes);
        void UpdateTax(Taxes taxes);
        void DeleteTax(int id);
        int GetTaxIdByPercentage(float percentage);
    }
}

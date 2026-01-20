using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IDiscountsRepository
    {
        object Discounts { get; set; }

        List<Discounts> GetAllDiscounts();
        Discounts GetDiscountById(int id);
        void AddDiscount(Discounts discounts);
        void UpdateDiscount(Discounts discounts);
        void DeleteDiscount(int id);
        int GetDiscountIdByValue(float value);

    }
}

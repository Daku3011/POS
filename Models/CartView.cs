
namespace EchoPOS.Models
{
    public class CartView
    {
        public int Cart_Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total_Price { get; set; }

        public int Table_Id { get; set; }
        public int User_Id { get; set; }
        public int orderId { get; set; }
        public int taxId { get; set; }
        public int discountId { get; set; }
        public int totalAmount { get; set; }

        internal List<Cart> ToList()
        {
            throw new NotImplementedException();
        }
    }
}

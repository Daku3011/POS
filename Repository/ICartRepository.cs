using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface ICartRepository
    {
        IEnumerable<object> Carts { get; }

        void AddToCart(int table_id, int menu_item_id, decimal price, int quantity, decimal totalPrice);
        IEnumerable<CartView> GetCartItems(int tableId);
        List<CartView> GetCartItemsByTable(int tableId);
        int UpdateCartQuantity(int cartId, int change);
        void RemoveCartItem(int cart_id);
        void ConvertCartToOrder(int table_id, int user_id);
        void SubmitOrder(int tableId);
        void SubmitOrderKeepCart(int tableId);
        void sp_SubmitOrder_NoUser(int tableId);
        void sp_ClearCart_NoUser(int tableId);
        void UpdateTablesStatus(int tableId, string status);
        void AddToCart(Cart model);
        CartView GetCartItem(int cartId);
        void UpdateCartItem(CartView cartItem);
        CartView GetCartItemById(int cartId);
        /* Bill mate*/
        int InsertBill(int orderId, int taxId, int discountId, decimal total);


    }
}

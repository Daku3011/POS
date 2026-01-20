using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IOrdersRepository
    {
        void AddItemToCart(int userId, int tableId, int menuItemId, int quantity, decimal price, string specialInstructions);
        public int SubmitOrder(int tableId);
        void MarkOrderReady(int orderId);
        void SubmitOrderFromCart(int tableId);
        IEnumerable<Models.Orders> GetPendingKitchenOrders();
        IEnumerable<Orders> GetReadyOrders();
        bool UpdateOrderStatus(int orderId, string newStatus);
        void AddToCart(Cart cart);
        object GetCartByTable(int table_id);
        object GetCartItemById(int cartId);
        int UpdateCartQuantity(int cartId, int change);
        void UpdateCartItem(CartView cartItem);
        Order_Items UpdateOrderItemStatuss(int orderItemId, string orderitemstatus);
        IEnumerable<Order_Items> GetReadyOrderItems();
        void MarkOrderCompleted(int orderItemId);
        IEnumerable<OrderHistoryViewModel> GetOrderHistory();
        int GetLatestOrderIdByTable(int tableId);


    }

}

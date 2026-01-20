using Dapper;
using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchoPOS.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly string _connectionString;

        public OrdersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Add item to the cart
        public void AddItemToCart(int userId, int tableId, int menuItemId, int quantity, decimal price, string specialInstructions)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("AddItemToCart", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User_Id", userId);
                    cmd.Parameters.AddWithValue("@Table_Id", tableId);
                    cmd.Parameters.AddWithValue("@Menu_Item_Id", menuItemId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Special_Instructions", specialInstructions);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Submit an order
        public void SubmitOrder(int tableId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SubmitOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Table_Id", tableId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Submit order from cart (corrected)
        public void SubmitOrderFromCart(int tableId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                con.Execute(
                    "sp_InsertOrderFromCart",  // Ensure this SP is created in your database
                    new { TableId = tableId },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        // Get pending orders for kitchen
        public IEnumerable<Orders> GetPendingKitchenOrders()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                var orderDictionary = new Dictionary<int, Orders>();

                var orders = con.Query<Orders, Order_Items, Orders>(
                    "sp_GetKitchenPendingOrders", // Ensure this SP is created in your database
                    (order, item) =>
                    {
                        if (!orderDictionary.TryGetValue(order.Order_Id, out var currentOrder))
                        {
                            currentOrder = order;
                            currentOrder.OrderItems = new List<Order_Items>();
                            orderDictionary.Add(currentOrder.Order_Id, currentOrder);
                        }

                        if (item != null)
                        {
                            currentOrder.OrderItems.Add(item);
                        }

                        return currentOrder;
                    },
                    splitOn: "Quantity",  // Correctly defining where the split occurs
                    commandType: CommandType.StoredProcedure
                ).Distinct().ToList();

                return orders;
            }
        }

        public IEnumerable<Orders> GetReadyOrders()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Orders>(
                    "GetReadyOrders",
                    commandType: CommandType.StoredProcedure
                ).ToList();
            }
        }
        // update order item status 
        public Order_Items UpdateOrderItemStatuss(int orderItemId, string orderitemstatus)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var parameters = new { Order_Item_Id = orderItemId, Order_Item_Status = orderitemstatus };

                // Update the order item status
                var updatedItem = con.QueryFirstOrDefault<Order_Items>("UpdateOrderItemStatuss", parameters, commandType: CommandType.StoredProcedure);

                return updatedItem;
            }
        }


        // Update order status
        public bool UpdateOrderStatus(int orderId, string newStatus)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var parameters = new { Order_Id = orderId, NewStatus = newStatus };
                int rowsAffected = con.Execute("sp_UpdateOrderStatus", parameters, commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }


        // Mark order as ready
        public void MarkOrderReady(int orderId)
        {
            // Implement the logic to mark the order as ready in your database.
            throw new NotImplementedException();
        }


        public CartView GetCartItemById(int cartId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cartItem = connection.QueryFirstOrDefault<CartView>(
                    "dbo.GetCartItemById", // Ensure schema prefix matches the actual DB schema
                    new { CartId = cartId },
                    commandType: CommandType.StoredProcedure
                );
                return cartItem;
            }
        }

        public void UpdateCartItem(CartView cartItem)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "dbo.UpdateCartItem", // include 'dbo.' if your stored proc is under that schema
                    new
                    {
                        CartId = cartItem.Cart_Id,
                        Quantity = cartItem.Quantity
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void AddToCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public object GetCartByTable(int table_id)
        {
            throw new NotImplementedException();
        }

        object IOrdersRepository.GetCartItemById(int cartId)
        {
            return GetCartItemById(cartId);
        }

        public int UpdateCartQuantity(int cartId, int change)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order_Items> GetReadyOrderItems()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                return con.Query<Order_Items>("sp_GetReadyOrderItems", commandType: CommandType.StoredProcedure);
            }
        }

        public void MarkOrderCompleted(int orderItemId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("MarkOrderCompleted",
                    new { Order_Item_Id = orderItemId }, // <- Correct parameter name
                    commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<OrderHistoryViewModel> GetOrderHistory()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string procedureName = "sp_GetOrderHistory";
                return connection.Query<OrderHistoryViewModel>(
                    procedureName,
                    commandType: CommandType.StoredProcedure
                );
            }
        }


        int IOrdersRepository.SubmitOrder(int tableId)
        {
            throw new NotImplementedException();
        }

        public int GetLatestOrderIdByTable(int tableId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Table_Id", tableId);

                return connection.QueryFirstOrDefault<int>(
                    "GetLatestOrderIdByTable", // make sure this SP returns Order_Id
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

    }
}

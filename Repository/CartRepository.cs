using Dapper;
using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchoPOS.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly string _connectionString;

        public CartRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<object> Carts => throw new NotImplementedException();

        public void AddToCart(int table_id, int menu_item_id, decimal price, int quantity, decimal total_price)
        {
            using (var conn = Connection)
            {
                conn.Execute("sp_AddToCart",
                    new { Table_Id = table_id, Menu_Item_Id = menu_item_id, Price = price, Quantity = quantity },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<CartView> GetCartItems(int table_id)
        {
            using (var conn = Connection)
            {
                return conn.Query<CartView>("sp_GetCartItems", new { Table_Id = table_id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<CartView> GetCartItemsByTable(int tableId)
        {
            using (var conn = Connection)
            {
                return conn.Query<CartView>("sp_GetCartItems", new { Table_Id = tableId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int UpdateCartQuantity(int cartId, int change)
        {
            using (var conn = Connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Cart_Id", cartId);
                parameters.Add("@Change", change);

                return conn.QuerySingle<int>("sp_UpdateCartQuantity", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveCartItem(int cartId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "RemoveCartItem",
                    new { CartId = cartId },
                    commandType: CommandType.StoredProcedure
                );
            }
        }
        public void ConvertCartToOrder(int table_id, int user_id)
        {
            using (var conn = Connection)
            {
                conn.Execute("sp_ConvertCartToOrder", new { Table_Id = table_id, User_Id = user_id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void SubmitOrder(int tableId)
        {
            using (var conn = Connection)
            {
                conn.Execute("SubmitOrder", new { Table_Id = tableId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void SubmitOrderKeepCart(int tableId)
        {
            using (var conn = Connection)
            {
                conn.Execute("SubmitOrder_KeepCart", new { Table_Id = tableId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void sp_SubmitOrder_NoUser(int tableId)
        {
            using (var conn = Connection)
            {
                conn.Execute("sp_SubmitOrder_NoUser", new { TableId = tableId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void sp_ClearCart_NoUser(int tableId)
        {
            using (var conn = Connection)
            {
                conn.Execute("sp_ClearCart_NoUser", new { TableId = tableId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateTablesStatus(int tableId, string status)
        {
            using (var conn = Connection)
            {
                conn.Execute("sp_UpdateTablesStatus", new { Table_Id = tableId, Status = status }, commandType: CommandType.StoredProcedure);
            }
        }

        // This method fetches the cart item by Cart_Id using Dapper, not EF
        public CartView GetCartItem(int cartId)
        {
            using (var conn = Connection)
            {
                return conn.QuerySingleOrDefault<CartView>("sp_GetCartItem", new { Cart_Id = cartId }, commandType: CommandType.StoredProcedure);
            }
        }

        // This method updates the cart item using Dapper
        public CartView GetCartItemById(int cartId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cartItem = connection.QueryFirstOrDefault<CartView>(
                    "GetCartItemById",
                    new { CartId = cartId },
                    commandType: CommandType.StoredProcedure
                );

                return cartItem;
            }
        }



        public void AddToCart(int table_id, int menu_item_id, decimal price)
        {
            throw new NotImplementedException();
        }

        public void AddToCart(Cart model)
        {
            throw new NotImplementedException();
        }

        public void UpdateCartItem(CartView cartItem)
        {
            throw new NotImplementedException();
        }

        /*Bill*/

        public int InsertBill(int orderId, int taxId, int discountId, decimal total)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Order_Id", orderId);
                parameters.Add("@Tax_Id", taxId);
                parameters.Add("@Discount_Id", discountId);
                parameters.Add("@Total", total);

                return connection.ExecuteScalar<int>("InsertBill", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}

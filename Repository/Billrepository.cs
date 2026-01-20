using Dapper;
using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchoPOS.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly string _connectionString;

        public BillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<BillViewModel> GetBillByOrderId(int orderId)
        {
            throw new NotImplementedException(); // Implement if needed
        }

        public BillViewModel GetBillDetailsByOrderId(int orderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple("sp_GetBillDetailsByOrderId",
                    new { Order_Id = orderId }, commandType: CommandType.StoredProcedure))
                {
                    var bill = multi.Read<Bill>().FirstOrDefault();
                    var orderDetail = multi.Read<OrderDetail>().FirstOrDefault();
                    var orderItems = multi.Read<OrderItemSummary>().ToList();

                    return new BillViewModel
                    {
                        Bill = bill,
                        OrderDetail = orderDetail,
                        OrderItemSummaries = orderItems
                    };
                }
            }
        }

        public List<BillViewModel> GetAllBills()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<BillViewModel>("sp_GetBillDisplay", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void ProcessPayment(int orderId, string methodName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new { Order_Id = orderId, Method_Name = methodName };
                connection.Execute("sp_ProcessPayment", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public PaymentSummaryViewModel GetPaymentSummary()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GetPaymentSummary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PaymentSummaryViewModel
                            {
                                CashTotal = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0),
                                UPITotal = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1),
                                CardTotal = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                                GrandTotal = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3)
                            };
                        }
                    }
                }
            }

            return new PaymentSummaryViewModel(); // return default if no data
        }



        public PaymentSummaryViewModel GetFilteredPaymentSummary(DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GetFilteredPaymentSummary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PaymentSummaryViewModel
                            {
                                CashTotal = reader["CashTotal"] != DBNull.Value ? Convert.ToDecimal(reader["CashTotal"]) : 0,
                                UPITotal = reader["UPITotal"] != DBNull.Value ? Convert.ToDecimal(reader["UPITotal"]) : 0,
                                CardTotal = reader["CardTotal"] != DBNull.Value ? Convert.ToDecimal(reader["CardTotal"]) : 0,
                                GrandTotal = reader["GrandTotal"] != DBNull.Value ? Convert.ToDecimal(reader["GrandTotal"]) : 0
                            };
                        }
                    }
                }
            }

            return new PaymentSummaryViewModel();
        }


        public void ClearDailyPaymentSummary()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("ClearPaymentSummary", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.ExecuteNonQuery();
            }
        }



    }
}

using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IBillRepository
    {
        List<BillViewModel> GetBillByOrderId(int orderId);

        BillViewModel GetBillDetailsByOrderId(int orderId);
        List<BillViewModel> GetAllBills();
        void ProcessPayment(int orderId, string methodName);
        PaymentSummaryViewModel GetPaymentSummary();
        PaymentSummaryViewModel GetFilteredPaymentSummary(DateTime startDate, DateTime endDate);
        void ClearDailyPaymentSummary();



    };



}

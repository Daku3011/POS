namespace EchoPOS.Models
{
    public class PaymentSummaryViewModel
    {
        public decimal CashTotal { get; set; }
        public decimal UPITotal { get; set; }
        public decimal CardTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}

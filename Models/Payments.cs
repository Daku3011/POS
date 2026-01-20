namespace EchoPOS.Models
{
    public class Payments
    {
        public int Payment_Id { get; set; }
        public int Transaction_Id { get; set; }
        public decimal Total_Amount { get; set; }
        public DateTime Paid_At { get; set; }

        // Optional navigation property
        public Transactions Transactions { get; set; }
    }
}

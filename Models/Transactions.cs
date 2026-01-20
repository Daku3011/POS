namespace EchoPOS.Models
{
    public class Transactions
    {
        public int Transaction_Id { get; set; }
        public int Order_Id { get; set; }
        public int Payment_Method_Id { get; set; }
        public int Payment_Status_Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Transaction_Date { get; set; }

        // Optional navigation properties (useful if using EF Core)
        public Payment_Methods PaymentMethods { get; set; }
        public Payment_Status PaymentStatus { get; set; }
    }
}

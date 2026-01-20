namespace EchoPOS.Models
{
    public class Bill
    {
        public int Bill_Id { get; set; }
        public int Order_Id { get; set; }
        public int Tax_Id { get; set; }
        public int Discount_Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Created_At { get; set; }

        public decimal Percentage { get; set; }
        public decimal Value { get; set; }
        // From JOIN
        public decimal Tax_Percentage { get; set; }
        public decimal Discount_Value { get; set; }


    }
}

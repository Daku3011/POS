namespace EchoPOS.Models
{
    public class Discounts
    {
        public int Discount_Id { get; set; }
        public string Name { get; set; }
        public string Discount_Type { get; set; } // Either 'percentage' or 'fixed'
        public decimal Value { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
    }
}

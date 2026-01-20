namespace EchoPOS.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}

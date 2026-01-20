namespace EchoPOS.Models
{
    public class Orders
    {
        public int Order_Id { get; set; }
        public int Table_Id { get; set; }
        public string Order_Status { get; set; }
        public string Payment_Status_Id { get; set; }
        public string Status_Name { get; set; }
        public DateTime Created_At { get; set; }
        public decimal Total_Amount { get; set; }
        public List<Order_Items> OrderItems { get; set; }
        public int Table_Number { get; set; }
        public decimal Sub_Total { get; set; }
        public string Payment_Status_Name { get; set; }
    }
}



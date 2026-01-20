namespace EchoPOS.Models
{
    public class OrderHistoryViewModel
    {
        public int Order_Id { get; set; }
        public string Order_Status { get; set; }
        public decimal Total_Amount { get; set; }
        public int Menu_Item_Id { get; set; }
        public string Menu_Item_Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Order_Item_Status { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }

}

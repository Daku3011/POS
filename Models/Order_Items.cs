namespace EchoPOS.Models
{
    public class Order_Items
    {
        public int Order_Item_Id { get; set; }
        public int Order_Id { get; set; }
        public int Menu_Item_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Special_Instructions { get; set; }
        public string Name { get; set; }
        public string Menu_Item_Name { get; set; }  // Menu name from Menu table    
        public string Order_Item_Status { get; set; }
        public DateTime? Updated_At { get; set; }
        public int Table_Number { get; set; }

        // ✅ Add menu list
        public List<Menu> MenuList { get; set; } = new List<Menu>();
        public string Menu_Name { get; set; }
    }
}

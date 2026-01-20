namespace EchoPOS.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }  // Changed to string to match nvarchar in DB
        public decimal Price { get; set; }
        public int? Supplier_ID { get; set; }
        public string SupplierName { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Name { get; set; }

        // Optional: A computed property to get Quantity as an integer
        public int QuantityAsInt => int.TryParse(Quantity, out int qty) ? qty : 0;
    }
}

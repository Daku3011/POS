namespace EchoPOS.Models
{
    public class BillViewModel
    {
        // Order Information
        public int Order_Id { get; set; }
        public int Table_Id { get; set; }
        public string Order_Status { get; set; } // Changed to string for clarity

        // Item Information (if you’re loading line items directly in a flat view)
        public string Menu_Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal => Quantity * Price;

        // Tax & Discount (nullable to support optional)
        public decimal? Tax_Rate { get; set; }         // e.g., 10 for 10%
        public decimal? Discount_Rate { get; set; }    // e.g., 5 for 5%
        public int Percentage { get; set; }         // e.g., 10 for 10%
        public int Value { get; set; }
        // Bill Summary
        public decimal Total { get; set; }
        public DateTime Created_At { get; set; }

        // These fields (Percentage & Value) are unclear — renamed for clarity:
        public int? Tax_Percentage { get; set; }
        public int? Discount_Value { get; set; }

        // Full objects (optional but useful for view)
        public Bill Bill { get; set; }
        public Orders Orders { get; set; }


        // Collection of Items for the Order
        public List<Order_Items> OrderItems { get; set; } = new List<Order_Items>();
        public OrderDetail OrderDetail { get; set; }
        public List<OrderItemSummary> OrderItemSummaries { get; set; } = new List<OrderItemSummary>();


        public int Bill_Id { get; set; }
        public string Payment_Status_Id { get; set; }
        public string Payment_Status_Name { get; set; }
        public string Method_Name { get; set; }


        /**/

        public decimal CashTotal { get; set; }
        public decimal UPITotal { get; set; }
        public decimal CardTotal { get; set; }
    }
}

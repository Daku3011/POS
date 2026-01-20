namespace EchoPOS.Models
{
    public class Cart
    {
        public int Cart_Id { get; set; }
        public int Table_Id { get; set; }
        public int User_Id { get; set; }
        public int Menu_Item_Id { get; set; }
        public int Quantity { get; set; } = 1; // Default value as per DB schema
        public decimal Price { get; set; }

        // Computed column, no need for [Column] attribute as it's calculated in the database
        public decimal Total_Price => Quantity * Price;

        public DateTime Created_At { get; set; } = DateTime.Now; // Default value

    }

}



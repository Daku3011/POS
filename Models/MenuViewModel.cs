namespace EchoPOS.Models
{
    public class MenuListViewModel
    {
        public List<Menu> MenuItems { get; set; } = new List<Menu>();
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Cart> CartItems { get; set; } = new List<Cart>();
        public int TableId { get; set; }
        public decimal CartTotal => CartItems.Sum(item => item.Total_Price);
    }
}

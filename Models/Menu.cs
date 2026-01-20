using System.ComponentModel.DataAnnotations;

namespace EchoPOS.Models
{
    public class Menu
    {
        [Key]
        public int Menu_Item_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string? Image_Url { get; set; }

        public bool Availability { get; set; } = true;

        public IFormFile? ImagePath { get; set; } // No [Required] attribute

        public int Category_Id { get; set; }
        public Category Category { get; set; }
    }
}

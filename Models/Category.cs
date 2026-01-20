using System.ComponentModel.DataAnnotations;

namespace EchoPOS.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}

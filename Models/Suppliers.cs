using System.ComponentModel.DataAnnotations;

namespace EchoPOS.Models
{
    public class Suppliers
    {
        [Key]
        public int Supplier_Id { get; set; }  // Matches Supplier_Id in DB

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Contact { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }
    }
}

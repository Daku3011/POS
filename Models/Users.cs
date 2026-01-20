using System.ComponentModel.DataAnnotations;

namespace EchoPOS.Models
{
    public class Users
    {
        [Key]
        public int User_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } // Consider using an enum for role-based access

        [StringLength(20)]
        public string Phone { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public DateTime Created_At { get; set; } = DateTime.UtcNow; // Default to current time
    }
}

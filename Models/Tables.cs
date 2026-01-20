using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EchoPOS.Models
{
    public class Tables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Table_Id { get; set; }

        [Required]
        public int Table_Number { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Location { get; set; }
    }
}

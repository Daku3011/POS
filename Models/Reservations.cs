using System.ComponentModel.DataAnnotations;

namespace EchoPOS.Models
{
    public class Reservations
    {
        public int Reservation_Id { get; set; } // Primary key for the reservation

        [Required]
        public int User_Id { get; set; }  // Foreign key referencing the User

        [Required]
        public int Table_Id { get; set; } // Foreign key referencing the Table

        [Required]
        public DateTime Reservation_Date { get; set; } // Date and time of the reservation

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // Status of the reservation (e.g., "confirmed", "canceled")

        // These properties will be populated based on the User and Table data.
        public string? Name { get; set; }  // User Name (populated from User table)
        public int? Table_Number { get; set; }  // Table Number (populated from Table table)
    }
}

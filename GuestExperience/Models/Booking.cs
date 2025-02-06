using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestExperience.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime CheckIn { get; set; }
        
        [Required]
        public DateTime CheckOut { get; set; }

        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
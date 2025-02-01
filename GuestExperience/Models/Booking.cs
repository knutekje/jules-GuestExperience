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
        public int ReservationId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int GuestId { get; set; }

        private DateTime _checkInDate;
        [Required]
        public DateTime CheckInDate
        {
            get => _checkInDate;
            set => _checkInDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        private DateTime _checkOutDate;
        [Required]
        public DateTime CheckOutDate
        {
            get => _checkOutDate;
            set => _checkOutDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public bool CheckedIn { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }


        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }
    }
}
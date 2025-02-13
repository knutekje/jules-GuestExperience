using System;

namespace GuestExperience.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        public DateTime CheckIn { get; set; }
        
        public DateTime CheckOut { get; set; }
        
        // Foreign key to the Reservation.
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        
        // Foreign key to the Room.
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
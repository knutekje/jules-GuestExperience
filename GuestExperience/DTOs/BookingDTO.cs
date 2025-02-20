using System;

namespace GuestExperience.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        
        public DateTime CheckIn { get; set; }
        
        public DateTime CheckOut { get; set; }
        
        // Only the foreign key values are exposed.
        public int ReservationId { get; set; }
        
        public int RoomId { get; set; }
    }
}
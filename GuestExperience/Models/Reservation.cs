
    
    
using System.Collections.Generic;

namespace GuestExperience.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        
        // Foreign key to the Guest who made the reservation.
        public int GuestId { get; set; }
        
        // Navigation property to the Guest.
        public Guest Guest { get; set; }
        
        // One Reservation can have many Bookings.
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        
        // Optionally, add additional properties (e.g. reservation date, total price, etc.)
    }
}

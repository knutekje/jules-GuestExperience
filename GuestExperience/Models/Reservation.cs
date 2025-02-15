
    
    
using System.Collections.Generic;

namespace GuestExperience.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        
        public int GuestId { get; set; }
        
        public Guest Guest { get; set; }
        
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        
    }
}

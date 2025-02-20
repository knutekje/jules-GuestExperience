using System.Collections.Generic;

namespace GuestExperience.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        
        public List<int> BookingIds { get; set; } = [];
    }
}
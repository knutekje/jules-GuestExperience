using System;
using System.Collections.Generic;

namespace GuestExperience.Models
{
    public class Guest
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string Nationality { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
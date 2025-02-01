using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuestExperience.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Address { get; set; } = null;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}


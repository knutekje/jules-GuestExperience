using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestExperience.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public string InvoiceId { get; set; } = string.Empty;

        [Required]
        public ReservationStatus Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for Bookings (one Reservation can have many Bookings)
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        // Navigation property for Guest
        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }
    }

    public enum ReservationStatus
    {
        Active,
        Canceled,
        Completed
    }
}
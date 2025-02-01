using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestExperience.Models
{
    public enum RoomStatus
    {
        Clean,
        Dirty,
        OutOfService
    }

    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; } = string.Empty;

        [Required]
        public string RoomType { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public RoomStatus Status { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool ExtraBed { get; set; }

        public DateTime? LastMaintenance { get; set; } 

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
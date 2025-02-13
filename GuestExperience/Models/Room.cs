using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GuestExperience.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public RoomStatus Status { get; set; }
        public int PriceId { get; set; }
        public int Floor { get; set; }
        public bool ExtraBed { get; set; }
        public DateTime? LastMaintained { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }

    public enum RoomStatus
    {
        Clean,
        Dirty,
        OutOfService
    }

    public enum RoomType
    {
        Standard,
        Double,
        Suite,
        Family
    }
}
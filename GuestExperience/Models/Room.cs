using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Models;

[Table("room")]
public class Room
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("room_number")]
    public int RoomNumber { get; set; }
    
    [Column("room_type")]
    public RoomType RoomType { get; set; }
    
    [Column("capacity")]
    public int Capacity { get; set; }
    
    [Column("status")]
    public RoomStatus Status { get; set; }
    
    [Column("price_id")]
    public int PriceId {get; set;}
    
    [Column("floor")]
    public int Floor { get; set; }
    
    [Column("extra_bed")]
    public Boolean ExtraBed { get; set; }
    
    [Column("last_maintained")]
    public DateTime? LastMaintained { get; set; }
    
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
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
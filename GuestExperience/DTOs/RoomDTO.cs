using GuestExperience.Models;

namespace GuestExperience.DTOs;

public class RoomDTO
{
    public int RoomNumber { get; set; }
    public RoomType RoomType { get; set; }
    public int Capacity { get; set; }
    public RoomStatus Status { get; set; }
    public int PriceId { get; set; }
    public int Floor { get; set; }
    public bool ExtraBed { get; set; }
    
}
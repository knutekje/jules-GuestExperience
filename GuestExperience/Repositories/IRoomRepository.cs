using System.Collections.Generic;
using System.Threading.Tasks;
using GuestExperience.Data;
using GuestExperience.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(Room room);
        Task<Room> DeleteRoomAsync(Room room);
        Task<List<Room>> GetRoomsByRoomType(RoomType roomType);
        Task<List<Room>> GetRoomsByStatus(RoomStatus status);
        Task<List<Room>> GetRoomsByFloor(int floor);
    }
}
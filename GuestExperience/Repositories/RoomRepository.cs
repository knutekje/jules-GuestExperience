using GuestExperience.Data;
using GuestExperience.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly GuestExperienceDbContext _context; 
    
    public RoomRepository(GuestExperienceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        if (_context.Rooms == null)
        {
            throw new InvalidOperationException("No rooms have been retrieved.");
        }
        return await _context.Rooms.ToListAsync();
    }
    
    public async Task<Room?> GetRoomAsync(int id){
        return await _context.Rooms.FindAsync(id);
        }
    
    public async Task<Room?> AddRoomAsync(Room room){
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
        return room;
        }

    public async Task<Room> UpdateRoomAsync(Room room)
    {
        _context.Entry(room).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<Room?> DeleteRoomAsync(Room room)
    {
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return room;
        
    }

    public async Task<List<Room>> GetRoomsByRoomType(RoomType roomType)
    {
        var result = await _context.Rooms.Where(room => room.RoomType == roomType).ToListAsync();
        return result;
    }

    public async Task<List<Room>> GetRoomsByStatus(RoomStatus status)
    {
        var result = await _context.Rooms.Where(room => room.Status == status).ToListAsync();
        return result;
    }

    public async Task<List<Room>> GetRoomsByFloor(int floor)
    {
        var result = await _context.Rooms.Where(room => room.Floor == floor).ToListAsync();
        return result;
    }
}
using GuestExperience.Data;
using GuestExperience.Exception;
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
            throw new RoomNotFoundException("No rooms not found");
        }
        return await _context.Rooms.ToListAsync();
    }
    
    public async Task<Room> GetRoomByIdAsync(int id){
      
        
        return await _context.Rooms.FindAsync(id) ?? throw new RoomNotFoundException("Room not found.");
        
        }
    
    public async Task<Room> AddRoomAsync(Room room){
        try
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            throw new RoomCreateFailedException("Unable to create room {room} with exception", ex);
        }

        return room;
        }

    public async Task<Room> UpdateRoomAsync(Room room)
    {
        try
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        catch(System.Exception ex)
        {
            throw new RoomCreateFailedException("Unable to create room with exception", ex);
        }
    }

    public async Task<Room> DeleteRoomAsync(Room room)
    {
        try
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }
        catch(System.Exception ex)
        {
            throw new RoomNotFoundException("Room couldnt be found",ex);
        }
    }

    public async Task<List<Room>> GetRoomsByRoomType(RoomType roomType)
    {
        if (_context.Rooms == null)
        {
            throw new RoomNotFoundException("No rooms not found");
        }
        var result = await _context.Rooms.Where(room => room.RoomType == roomType).ToListAsync();
        return result;
    }

    public async Task<List<Room>> GetRoomsByStatus(RoomStatus status)
    {
        if (_context.Rooms == null)
        {
            throw new RoomNotFoundException("No rooms have been retrieved.");
        }
        var result = await _context.Rooms.Where(room => room.Status == status).ToListAsync();
        return result;
    }

    public async Task<List<Room>> GetRoomsByFloor(int floor)
    {
        if (_context.Rooms == null)
        {
            throw new RoomNotFoundException("No rooms have been retrieved.");
        }
        var result = await _context.Rooms.Where(room => room.Floor == floor).ToListAsync();
        return result;
    }
}
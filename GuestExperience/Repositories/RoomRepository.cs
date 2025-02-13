using GuestExperience.Data;
using GuestExperience.Exception;
using GuestExperience.Models;
using Microsoft.EntityFrameworkCore;


namespace GuestExperience.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly GuestExperienceDbContext _context; 
    private readonly ILogger<RoomRepository> _logger;
    
    public RoomRepository(GuestExperienceDbContext context, ILogger<RoomRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        try
        {
            return await _context.Rooms.ToListAsync();
        }
        catch (System.Exception ex)
        {
            
            throw new RepositoryException($"Failed to fetch all rooms {ex}");        }
    }
    
    
    
    
    public async Task<Room> GetRoomByIdAsync(int id){
        if (id == 0)
        {
            throw new RepositoryException("No id provided");
        }
        try
        {
            
            var foundRoom = await _context.Rooms.FindAsync(id);
            if (foundRoom == null)
            {
                throw new RepositoryException("Room not found");
            }
            return foundRoom;
        }
        catch (System.Exception e)
        { 
          throw new RepositoryException($"Error while fetching room with {id} : {e.Message} ");
        }
        
        
    }
    
    public async Task<Room> AddRoomAsync(Room room){
        if (room == null)
        {
            throw new RoomCreateFailedException("Room is null"); 
        }
        try
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();            
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Unable to create room {room} with exception {ex}");
        }

        return room;
        }

    public async Task<Room> UpdateRoomAsync(Room room)
    {
        try
        {
           _context.Rooms.Update(room);
           await _context.SaveChangesAsync();
           return room;

        }
        catch(System.Exception ex)
        {
            //_logger.LogError($"Error updating room: {ex.Message}");
            throw new RepositoryException($"Unable to create room {ex}");
        }
    }

    public async Task<bool> DeleteRoomAsync(int id)
    {
        try
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return false;
            }
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (System.Exception ex)
        {
            throw new RepositoryException($"Unable to delete room {id} : {ex.Message}");
            
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
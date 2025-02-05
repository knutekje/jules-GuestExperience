using GuestExperience.Data;
using GuestExperience.Models;
using GuestExperience.Repositories;
using GuestExperience.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit.Abstractions;

namespace GuestExperienceTests.Services;

public class GuestServiceTest
{
    private readonly Mock<IGuestRepository> _guestRepository;
    private readonly GuestService _guestService;

    private readonly List<Guest> _guest = [];
    Guest guestToSave = new Guest
    {
        // Id = 0,
        FirstName = "John",
        LastName = "Smith",
        Email = "john@smith.com",
        PhoneNumber = null,
        Address = "homestreet 12",
        City = "gotham",
        Nationality = "astonian",
        createdAt = DateTime.UtcNow,
        updatedAt = DateTime.UtcNow + TimeSpan.FromDays(5),
    };

    public GuestServiceTest()
    {
        _guestRepository = new Mock<IGuestRepository>();
        _guestService = new GuestService(_guestRepository.Object);
    }
    
    private GuestExperienceDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<GuestExperienceDbContext>()
            .UseInMemoryDatabase(databaseName: "GuestTestDb")
            .Options;
        var context = new GuestExperienceDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }
    
    [Fact]
    public async Task CreateAsync_Guest_ShouldCreate()
    {
        _guestRepository
            .Setup(repo => repo.AddGuestAsync(It.IsAny<Guest>()))
            .ReturnsAsync((Guest guest) =>
            {
                _guest.Add(guest);
                return guest;
            });
        
      
        
        var guest = await _guestService.AddGuestAsync(guestToSave);
        Assert.Equal(guestToSave.Email, guest.Email);
    }

    [Fact]
    public async Task GetAllAsync_Guests_ShouldReturnAllGuests()
    {
        using var context = GetInMemoryDbContext();
        context.Guests.AddRange(new List<Guest>
        {
            new Guest { FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", Address = "Street", City = "Fisk", PhoneNumber = "2121212", Nationality = "Dworak"},
            new Guest { FirstName = "Bob", LastName = "Johnson", Email = "bob@example.com", Address = "Street", City = "Truls",PhoneNumber = "2342", Nationality = "Dworak"},
            new Guest { FirstName = "Charlie", LastName = "Brown", Email = "charlie@example.com", Address = "Street", City = "Roggy",PhoneNumber = "2sdf", Nationality = "Dworak"}
        });
        await context.SaveChangesAsync();

        var repository = new GuestRepository(context);
        var guestService = new GuestService(repository);

        var guests = await guestService.GetAllGuestAsync();

        Assert.Equal(3, guests.Count);
    }

}
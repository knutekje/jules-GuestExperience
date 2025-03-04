using GuestExperience.Data;
using GuestExperience.Exception;
using GuestExperience.Models;
using GuestExperience.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GuestExperience.Tests.Repositories;

public class GuestRepositoryTest
{
    private GuestExperienceDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<GuestExperienceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new GuestExperienceDbContext(options);
    }

    [Fact]
    public async Task Add_Guest_Success()
    {
        using var context = GetInMemoryDbContext();
        var repository = new GuestRepository(context);
        
        Guest guest = new Guest
        {
            Id = 0,
            FirstName = "John",
            LastName = "Smith",
            Email = "john@gmail.com",
            PhoneNumber = "98sass3",
            Address = "HomeStreet 12",
            City = "CityHights",
            Nationality = "Yankee",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now + TimeSpan.FromDays(7),
        };
        
        var addedGuest = await repository.CreateAsync(guest);
        
        Assert.NotNull(addedGuest);
        Assert.Equal(addedGuest.FirstName, guest.FirstName);
        
        var fetchedGuest = await repository.GetByIdAsync(addedGuest.Id);
        Assert.Equal(addedGuest.FirstName, fetchedGuest.FirstName);
        
        
    }

    [Fact]
    public async Task Fetch_non_existing_guest_ThrowsCreateGuestException()
    {
        using var context = GetInMemoryDbContext();
        var repository = new GuestRepository(context);
    
        await Assert.ThrowsAsync<RepositoryException>(() => repository.GetByIdAsync(123));
    }


    [Fact]
    public async Task GetAllGuests_Success()
    {
        using var context = GetInMemoryDbContext();
        var repository = new GuestRepository(context);
         await repository.CreateAsync(new Guest
        {
            FirstName = "Alice",
            LastName = "Smith",
            Email = "alice.smith@example.com",
            PhoneNumber = "555-0101",
            Address = "123 Main St",
            City = "New York",
            Nationality = "American",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });

        await repository.CreateAsync(new Guest
        {
            FirstName = "Bob",
            LastName = "Johnson",
            Email = "bob.johnson@example.com",
            PhoneNumber = "555-0202",
            Address = "456 Elm St",
            City = "Los Angeles",
            Nationality = "American",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });

        await repository.CreateAsync(new Guest
        {
            FirstName = "Carol",
            LastName = "Williams",
            Email = "carol.williams@example.com",
            PhoneNumber = "555-0303",
            Address = "789 Oak St",
            City = "Chicago",
            Nationality = "American",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });

        await repository.CreateAsync(new Guest
        {
            FirstName = "David",
            LastName = "Brown",
            Email = "david.brown@example.com",
            PhoneNumber = "555-0404",
            Address = "321 Pine St",
            City = "Houston",
            Nationality = "American",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        });
    

    var guests = await repository.GetAllAsync();
    Assert.NotNull(guests);
    //Assert.Equal(4, guests.Count);
    }

    [Fact]
    public async Task FetchGuest_byId_Success()
    {
        Guest guest = new Guest
        {
            FirstName = "David",
            LastName = "Brown",
            Email = "david.brown@example.com",
            PhoneNumber = "555-0404",
            Address = "321 Pine St",
            City = "Houston",
            Nationality = "American",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        using var context = GetInMemoryDbContext();
        var repository = new GuestRepository(context);
        var result =await repository.CreateAsync(guest);
        var fetchedGuest = await repository.GetByIdAsync(result.Id);
        Assert.NotNull(fetchedGuest);
        Assert.Equal(fetchedGuest.Id, result.Id);
    }
}
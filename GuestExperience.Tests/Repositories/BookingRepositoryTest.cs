/*
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using GuestExperience.Data;
using GuestExperience.Models;

namespace GuestExperience.Tests.Repositories
{
    public class RelationshipTests
    {
        private GuestExperienceDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<GuestExperienceDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // use a unique DB for isolation
                .Options;
            var context = new GuestExperienceDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task CanRetrieveGuestWithBookings()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            
            // Create a guest.
            var guest = new Guest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Address = "123 Main Street",
                Nationality = "US",
                City = "London",
                PhoneNumber = "08888888888",
            };

            // Create two bookings and associate them with the guest.
            var booking1 = new Booking
            {
                CheckIn = DateTime.UtcNow,
                CheckOut = DateTime.UtcNow.AddDays(1),
                Guest = guest  // Set navigation property
            };

            var booking2 = new Booking
            {
                CheckIn = DateTime.UtcNow.AddDays(2),
                CheckOut = DateTime.UtcNow.AddDays(3),
                Guest = guest
            };

            // Add the guest and bookings to the context.
            context.Guests.Add(guest);
            context.Bookings.AddRange(booking1, booking2);
            await context.SaveChangesAsync();

            // Act
            // Retrieve the guest including its bookings.
            var retrievedGuest = await context.Guests
                .Include(g => g.Bookings)
                .FirstOrDefaultAsync(g => g.Id == guest.Id);

            // Assert
            Assert.NotNull(retrievedGuest);
            Assert.Equal(2, retrievedGuest.Bookings.Count);
        }
        [Fact]
        public async Task CanRetrieveBookingWithRoom()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            
            // Create a room.
            var room = new Room
            {
                RoomNumber = 101,
                Capacity = 2,
                RoomType = RoomType.Standard,  // Assuming RoomType enum is defined
                Status = RoomStatus.Clean      // Assuming RoomStatus enum is defined
            };

            // Create a guest for the booking (if needed).
            var guest = new Guest
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                Address = "123 Main Street",
                Nationality = "US",
                City = "London",
                PhoneNumber = "08888888888",
            };

            // Create a booking that references the room and the guest.
            var booking = new Booking
            {
                CheckIn = DateTime.UtcNow,
                CheckOut = DateTime.UtcNow.AddDays(1),
                Room = room,  // Set the navigation property
                Guest = guest
            };

            // Add the room, guest, and booking to the context.
            context.Rooms.Add(room);
            context.Guests.Add(guest);
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();

            // Act
            // Retrieve the booking including the associated room.
            var retrievedBooking = await context.Bookings
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.Id == booking.Id);

            // Assert
            Assert.NotNull(retrievedBooking);
            Assert.NotNull(retrievedBooking.Room);
            Assert.Equal(101, retrievedBooking.Room.RoomNumber);
        }
    }
    
}
*/

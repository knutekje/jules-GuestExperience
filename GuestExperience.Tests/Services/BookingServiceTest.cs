using GuestExperience.Models;
using GuestExperience.Repositories;
using Moq;
using NSubstitute;

namespace GuestExperienceTests.Services;

public class BookingServiceTest
{
    private readonly IBookingService _bookingService;
    private readonly IBookingRepository _bookingRepository;

    private List<Booking> testBookings; 
    
    
    
    public BookingServiceTest()
    {
        _bookingRepository = Substitute.For<IBookingRepository>();
        
        testBookings = new List<Booking>
        {
            new Booking
            {
                Id = 2,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today.AddDays(3),
                /*GuestId = 3,
                Guest = new Guest
                {
                    
                    Id = 1,
                    Nationality = "Nationality",
                    FirstName = "First",
                    LastName = "Last",
                    Email = "email@email.com",
                    Address = "Address",
                },*/
                RoomId = 2,
                Room = new Room
                {
                    Id = 1,
                    RoomNumber = 2,
                    RoomType = RoomType.Standard,
                    Floor = 2,
                    Capacity = 2,
                    Status = RoomStatus.Clean
                }
                
            },
            new Booking
            {
                Id = 1,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(7),
             //   GuestId = 1,
                RoomId = 1,
                Room = new Room
                {
                    Id = 1,
                    RoomNumber = 1,
                    RoomType = RoomType.Double,
                    Capacity = 1,
                    Floor = 2,


                },
                /*
                Guest = new Guest
                {
                    Id = 1,
                    Email = "test@test.com",
                    FirstName = "Test",
                    LastName = "Test",

                },
                */
                


            }
        };
        _bookingRepository.GetAllBookingsAsync().Returns((testBookings));
        _bookingRepository
            .DeleteBookingAsync(Arg.Any<Booking>())
            .Returns(Task.CompletedTask)
            .AndDoes(callInfo =>
            {
                var bookingToDelete = callInfo.Arg<Booking>();
                testBookings.Remove(bookingToDelete);
            });
        _bookingService = new BookingService(_bookingRepository);
        _bookingRepository
            .GetBookingByIdAsync(Arg.Any<int>())!
            .Returns(
                callInfo =>
                {
                    var passedId = callInfo.Arg<int>();
                    return testBookings.FirstOrDefault(x => x.Id == passedId);
                });
    }

    [Fact]
    public async Task Create_Booking()
    {
        Booking bookingToCreate = new Booking
        {
            Id = 0,
            CheckIn = default,
            CheckOut = default,
            //GuestId = 0,
           // Guest = null,
            RoomId = 0,
            Room = null
        };
        var result = _bookingService.CreateBookingAsync(bookingToCreate);
        Assert.Equal(bookingToCreate.Id, result.Result.Id);
    }
    
    [Fact]
    public async Task Update_Booking()
    {
        Booking bookingToCreate = new Booking
        {
            Id = 2,
            CheckIn = default,
            CheckOut = default,
           // GuestId = 4,
            //Guest = null,
            RoomId = 0,
            Room = null
        };
        await _bookingService.CreateBookingAsync(bookingToCreate);
        Booking bookingToUpdate = new Booking
        {
            Id = 2,
            CheckIn = default,
            CheckOut = default,
            //GuestId = 2,
            //Guest = null,
            RoomId = 0,
            Room = null
        };
        
        var result = _bookingService.UpdateBookingAsync(bookingToUpdate);
       // Assert.Equal(bookingToUpdate.GuestId, result.Result.GuestId);
    }
    [Fact]
    public async Task Delete_Booking(){
       
        await _bookingService.DeleteBookingAsync(testBookings[0]);
        var result = await _bookingService.GetAllBookingsAsync(); 
        Assert.Single(result);
        
    }
    [Fact]
    public async Task Get_Booking()
    {
        int passedId = 2;
        Booking returnedBooking = await _bookingService.GetBookingById(passedId);        
        Assert.Equal(passedId, returnedBooking.Id);
    }
    [Fact]
    public async Task Get_Bookings()
    {
        var result = await _bookingService.GetAllBookingsAsync();
        Assert.Equal(2, result.Count());
    }
    /*[Fact]
    public async Task Get_Bookings_By_UserId(){
        throw new NotImplementedException();
        
    }*/
    
}

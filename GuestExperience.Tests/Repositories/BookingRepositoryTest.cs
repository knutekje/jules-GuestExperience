using GuestExperience.Models;
using GuestExperience.Repositories;
using NSubstitute;

namespace GuestExperienceTests.Repositories
{
    public class BookingRepositoryTests
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly List<Booking> _testBookings;

        public BookingRepositoryTests()
        {
          
            _bookingRepository = Substitute.For<IBookingRepository>();

          
            _testBookings = new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    CheckIn = DateTime.UtcNow,
                    CheckOut = DateTime.UtcNow.AddDays(1),
                    ReservationId = 10,
                    RoomId = 101
                },
                new Booking
                {
                    Id = 2,
                    CheckIn = DateTime.UtcNow.AddDays(2),
                    CheckOut = DateTime.UtcNow.AddDays(3),
                    ReservationId = 11,
                    RoomId = 102
                }
            };

      

      
            _bookingRepository
                .GetAllAsync()
                .Returns(Task.FromResult<IEnumerable<Booking>>(_testBookings));

      
            _bookingRepository
                .GetByIdAsync(Arg.Any<int>())
                .Returns(callInfo =>
                {
                    int id = callInfo.Arg<int>();
                    return Task.FromResult(_testBookings.FirstOrDefault(b => b.Id == id));
                });

           
            _bookingRepository
                .CreateAsync(Arg.Any<Booking>())
                .Returns(callInfo =>
                {
                    var booking = callInfo.Arg<Booking>();
                    booking.Id = _testBookings.Count + 1;
                    _testBookings.Add(booking);
                    return Task.FromResult(booking);
                });

           
        }

        [Fact]
        public async Task CreateBookingAsync_AddsNewBookingAndAssignsId()
        {
           
            var newBooking = new Booking
            {
                Id = 0,
                CheckIn = DateTime.UtcNow.AddDays(4),
                CheckOut = DateTime.UtcNow.AddDays(5),
                ReservationId = 12, 
                RoomId = 103
            };

           
            var createdBooking = await _bookingRepository.CreateAsync(newBooking);

           
            Assert.NotEqual(0, createdBooking.Id);
            Assert.Equal(3, createdBooking.Id);
            Assert.Contains(_testBookings, b => b.Id == createdBooking.Id);
        }

        [Fact]
        public async Task GetBookingByIdAsync_ReturnsBooking_WhenIdExists()
        {
           
            var booking = await _bookingRepository.GetByIdAsync(1);

           
            Assert.NotNull(booking);
            Assert.Equal(1, booking.Id);
        }
    }
}

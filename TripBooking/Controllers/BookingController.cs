using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TripBooking.Models;
using TripBooking.Services;

namespace TripBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public class BookingRequest
        {
            public int RoomId { get; set; }
            public string Email { get; set; }
        }
        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingRequest request)
        {

            var booking = new Booking
            {
                RoomId = request.RoomId,
                CustomerEmail = request.Email,
                CheckIn = DateTime.Now,  // Adjust according to your business logic
                CheckOut = DateTime.Now.AddDays(1)  // Adjust according to your business logic
            };

            _bookingService.CreateBooking(booking);

            return Ok(booking);
        }
    }
}

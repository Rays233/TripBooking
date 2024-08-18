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

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking data is required.");
            }

            var result = _bookingService.CreateBooking(booking);
            if (result == null)
            {
                return BadRequest("Unable to create booking.");
            }

            return Ok(result);  // Return the created booking or relevant data
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
    }
}

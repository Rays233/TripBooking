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
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {

            if (booking == null || !ModelState.IsValid)
            {
                _logger.LogWarning("Invalid booking data.");
                return BadRequest("Invalid booking data.");
            }

            try
            {
                _bookingService.CreateBooking(booking);

                _logger.LogInformation($"Booking created successfully for customer: {booking.CustomerEmail}");
                return Ok(new { BookingId = booking.BookingId, Message = "Booking created successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating the booking: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

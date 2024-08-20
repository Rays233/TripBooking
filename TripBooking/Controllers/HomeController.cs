using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TripBooking.ViewModels;
using TripBooking.Services;


namespace TripBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IHotelService hotelService)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string location, [FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
        {
            
            // Validate the input
            if (string.IsNullOrEmpty(location) || checkIn == default || checkOut == default)
            {
                return BadRequest("Location, check-in, and check-out dates are required.");
            }

            // Call the service to get the list of hotels matching the criteria
            var hotels = _hotelService.SearchAvailableHotels(location, checkIn, checkOut);

            _logger.LogInformation($"Search results for location '{location}': {hotels.Count} hotels found");

            // Return the search results as JSON
            return Ok(hotels);
        }
    }
}

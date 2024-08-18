using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripBooking.DAL;
using TripBooking.Models;
using TripBooking.Services;

namespace TripBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult GetHotelDetails(int id, [FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            if (checkIn == default(DateTime) || checkOut == default(DateTime))
            {
                return BadRequest("Check-in and check-out dates are required.");
            }

            // Pass check-in and check-out dates as part of the response
            var result = new
            {
                Hotel = hotel,
                CheckIn = checkIn,
                CheckOut = checkOut
            };

            return Ok(result);
        }
                    
    }
}

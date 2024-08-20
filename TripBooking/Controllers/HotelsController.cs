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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Text.Json;

namespace TripBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(ILogger<HotelsController> logger, IHotelService hotelService)
        {
            _hotelService = hotelService;
            _logger = logger ;
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelDetails(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                _logger.LogWarning($"Hotel with id {id} not found");
                return NotFound();
            }
            _logger.LogInformation($"Returning hotel details for id {id}: {JsonSerializer.Serialize(hotel)}");
            return Ok(hotel);
        }
                    
    }
}

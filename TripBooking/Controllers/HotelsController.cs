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
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult Details(int id, DateTime checkIn, DateTime checkOut)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            if (TempData["CheckIn"] != null && TempData["CheckOut"] != null)
            {
                ViewBag.CheckIn = TempData["CheckIn"];
                ViewBag.CheckOut = TempData["CheckOut"];
                TempData.Keep("CheckIn");
                TempData.Keep("CheckOut");
            }
            else
            {
                // Handle the case where check-in and check-out dates are not available
                return BadRequest("Check-in and check-out dates are required.");
            }
            return View(hotel);
        }
                    
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TripBooking.ViewModels;
using TripBooking.Services;

namespace TripBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;

        public HomeController(ILogger<HomeController> logger, IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string location, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                ModelState.AddModelError("", "Check-out date must be after check-in date.");
                return View("Index");
            }

            var availableHotels = _hotelService.SearchAvailableHotels(location, checkIn, checkOut);
            TempData["CheckIn"] = checkIn;
            TempData["CheckOut"] = checkOut;
            return View("SearchResults", availableHotels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TripBooking.Models;
using TripBooking.Services;

namespace TripBooking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult Reserve(int RoomId, DateTime CheckIn, DateTime CheckOut, string CustomerName, string CustomerEmail)
        {
            var booking = new Booking
            {
                RoomId = RoomId,
                CheckIn = CheckIn,
                CheckOut = CheckOut,
                CustomerName = CustomerName,
                CustomerEmail = CustomerEmail
            };

            _bookingService.CreateBooking(booking);

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}

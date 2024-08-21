using Microsoft.EntityFrameworkCore;
using TripBooking.DAL;
using TripBooking.Models;
namespace TripBooking.Services
{
    public interface IBookingService
    {
        Booking GetBookingById(int id);
        Booking CreateBooking(Booking booking);
    }
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public Booking CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings
                           .FirstOrDefault(b => b.BookingId == id);
        }
    }

}

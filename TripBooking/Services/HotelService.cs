using TripBooking.Services;
using TripBooking.Models;
using TripBooking.DAL;

namespace TripBooking.Services
{
    public interface IHotelService
    {
        List<Hotel> SearchAvailableHotels(string location, DateTime checkIn, DateTime checkOut);
    }

    public class HotelService : IHotelService
    {
        private readonly AppDbContext _context;

        public HotelService(AppDbContext context)
        {
            _context = context;
        }

        public List<Hotel> SearchAvailableHotels(string searchTerm, DateTime checkIn, DateTime checkOut)
        {

            var bookedRoomIds = _context.Bookings
            .Where(b => (b.CheckIn < checkOut && b.CheckOut > checkIn))
            .Select(b => b.RoomId)
            .Distinct()
            .ToList();

            // G    et all hotel IDs that have available rooms
            var availableHotelIds = _context.Rooms
                .Where(r => !bookedRoomIds.Contains(r.RoomId))
                .Select(r => r.HotelId)
                .Distinct()
                .ToList();
            return _context.Hotels
                .Where(h => (h.City.Contains(searchTerm) || h.Country.Contains(searchTerm)) &&
                                availableHotelIds.Contains(h.HotelId))
                .ToList();
        }
    }
}

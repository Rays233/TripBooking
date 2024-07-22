using TripBooking.DAL;
using TripBooking.Models;

namespace TripBooking.Services
{
     public interface IRoomService
    {
        List<Room> GetAvailableRooms(int hotelId, DateTime checkIn, DateTime checkOut);
    }
    public class RoomService:IRoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public List<Room> GetAvailableRooms(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            // Get all rooms for the hotel
            var hotelRooms = _context.Rooms.Where(r => r.HotelId == hotelId).ToList();

            // Get bookings that overlap with the desired date range
            var overlappingBookings = _context.Bookings
                .Where(b => b.CheckIn < checkOut && b.CheckOut > checkIn)
                .Select(b => b.RoomId)
                .Distinct()
                .ToList();

            // Return rooms that are not in the overlapping bookings
            return hotelRooms.Where(r => !overlappingBookings.Contains(r.RoomId)).ToList();
        }
    }   
}

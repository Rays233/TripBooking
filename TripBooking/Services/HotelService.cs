using TripBooking.Services;
using TripBooking.Models;
using TripBooking.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TripBooking.Services
{
    public interface IHotelService
    {
        List<Hotel> SearchAvailableHotels(string location, DateTime checkIn, DateTime checkOut);
        Hotel GetHotelById(int hotelId);
        Task<List<Hotel>> GetAllHotelsAsync();
    }

    public class HotelService : IHotelService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HotelService> _logger;
    

        public HotelService(AppDbContext context, ILogger<HotelService> logger)
        {   
            _context = context;
            _logger = logger;
        }
        public Hotel GetHotelById(int hotelId)
        {

            var hotel = _context.Hotels
            .Include(h => h.Rooms)
            .FirstOrDefault(h => h.HotelId == hotelId);

            if (hotel == null)
            {
                _logger.LogWarning($"Hotel with id {hotelId} not found in database");
            }
            else
            {
                _logger.LogInformation($"Found hotel with id {hotelId}: {hotel.Name}, Rooms: {hotel.Rooms.Count}");
            }

            return hotel;
        }

        public List<Hotel> SearchAvailableHotels(string searchTerm, DateTime checkIn, DateTime checkOut)
        {

            var bookedRoomIds = _context.Bookings
            .Where(b => (b.CheckIn < checkOut && b.CheckOut > checkIn))
            .Select(b => b.RoomId)
            .Distinct()
            .ToList();

            // Get all hotel IDs that have available rooms
            var availableHotelIds = _context.Rooms
                .Where(r => !bookedRoomIds.Contains(r.RoomId))
                .Select(r => r.HotelId)
                .Distinct()
                .ToList();

            var hotels = _context.Hotels
            .Where(h => (h.City.Contains(searchTerm) || h.Country.Contains(searchTerm)) &&
                    availableHotelIds.Contains(h.HotelId))

            .ToList();
            _logger.LogInformation($"Found {hotels.Count} hotels matching search term '{searchTerm}'");
            return hotels;
        }
        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        
    }
}

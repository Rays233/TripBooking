using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}

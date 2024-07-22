namespace TripBooking.Models
{
    public class HotelInfoViewModel
    {
        public Hotel Hotel { get; set; }
        public List<Room> AvailableRooms { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}

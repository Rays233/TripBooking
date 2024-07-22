namespace TripBooking.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;



    public class Room
    {
        //Constructor ensures hotel is provided when booking is made
        /*public Room(Hotel hotel)
        {
            Hotel = hotel ?? throw new ArgumentNullException(nameof(hotel));
            HotelId = hotel.HotelId;
        }*/
        public int RoomId { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Room type is required.")]
        public string Type { get; set; }

        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $1000.")]
        public decimal Price { get; set; }
        public virtual Hotel Hotel { get; set; }
    }


}

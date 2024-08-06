namespace TripBooking.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;



    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Room type is required.")]
        public string Description {get; set;}

        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $1000.")]
        public decimal Price { get; set; }
        [Required]

        public Hotel Hotel { get; set; }
    }


}

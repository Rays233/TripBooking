namespace TripBooking.Models
{   using System.ComponentModel.DataAnnotations;
    public class Booking
    {
        //Constructor ensures a booking has a room and customer associated with it
        /*public Booking(Room room, Customer customer)
        {
            Room = room ?? throw new ArgumentNullException(nameof(room));
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }*/

        public int BookingId { get; set; }


        [Required]
        public int RoomId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [Required]
        public virtual Room Room { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-in Date")]
        public DateTime CheckIn { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-out Date")]
        [GreaterThan("CheckIn", ErrorMessage = "Check-out date must be after check-in date.")]
        public DateTime CheckOut { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
    }
}

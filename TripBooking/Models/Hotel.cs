using System.ComponentModel.DataAnnotations;

namespace TripBooking.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Hotel name is required.")]
        [Display(Name = "Hotel Name")]
        [StringLength(200, ErrorMessage = "Hotel name must not exceed 200 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "City name must not exceed 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [Display(Name = "Country")]
        [StringLength(100, ErrorMessage = "Country name must not exceed 100 characters.")]
        public string Country { get; set; }
    }
}

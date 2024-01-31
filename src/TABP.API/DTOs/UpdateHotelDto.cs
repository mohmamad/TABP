using System.ComponentModel.DataAnnotations;

namespace TABP.API.DTOs
{
    public class UpdateHotelDto
    {
        [Required]
        public string HotelName { get; set;}
        [Required]
        public string HotelDescription { get; set;}
        [Required]
        public double Rating { get; set;}
        [Required]
        public string Amenities { get; set;}
    }
}

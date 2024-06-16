using System.ComponentModel.DataAnnotations;

namespace TABP.API.DTOs.UserDtos
{
    public class UpdateUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastBame { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

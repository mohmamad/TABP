using System.ComponentModel.DataAnnotations;

namespace TABP.API.DTOs
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserLevel { get; set; }
    }
}

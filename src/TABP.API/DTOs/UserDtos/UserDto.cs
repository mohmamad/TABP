using TABP.Domain.Enums;

namespace TABP.API.DTOs.UserDtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserLevel UserLevel { get; set; }
        public string BookingUrl { get; set; }
    }
}

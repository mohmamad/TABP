using TABP.Domain.Enums;

namespace TABP.Application.Models
{
    public class UserModel
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

using TABP.Domain.Enums;

namespace TABP.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserLevel UserLevel { get; set; }
        public string Password { get; set; }
        public List<Booking> bookings { get; set; }
        public List<Review> Reviews { get; set; }
    }
}

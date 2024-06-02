namespace TABP.Domain.Entities
{
    public class ResetPasswordCode
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public Guid UserId { get; set; }
        public User user { get; set; }
    }
}

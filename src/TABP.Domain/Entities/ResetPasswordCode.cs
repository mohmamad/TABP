namespace TABP.Domain.Entities
{
    public class ResetPasswordCode
    {
        public int Id { get; set; }
        public string code { get; set; }
        public Guid UserId { get; set; }
        public User user { get; set; }
    }
}

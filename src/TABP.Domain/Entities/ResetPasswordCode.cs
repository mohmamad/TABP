namespace TABP.Domain.Entities
{
    public class ResetPasswordCode
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User user { get; set; }
    }
}

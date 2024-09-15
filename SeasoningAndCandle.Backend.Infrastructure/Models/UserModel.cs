namespace SeasoningAndCandle.Backend.Infrastructure.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Phone { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int IsActive { get; set; } = 1;
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

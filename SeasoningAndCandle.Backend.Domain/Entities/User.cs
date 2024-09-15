namespace SeasoningAndCandle.Backend.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Phone { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required bool IsActive { get; set; } = true;
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

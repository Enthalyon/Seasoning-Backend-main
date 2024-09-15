namespace SeasoningAndCandle.Backend.Application.ViewModels
{
    public class TokenViewModel
    {
        public required string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

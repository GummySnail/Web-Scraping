namespace Web.Scraping.Core.Entities;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string RefreshTokenValue { get; set; }
    public DateTime ExpiryTime { get; set; }
}
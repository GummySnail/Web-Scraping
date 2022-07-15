using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Scraping.Infrastructure.Entities;

[Table("AspNetUserRefreshTokens")]
public class AppUserRefreshTokens
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiryTime { get; set; }
}
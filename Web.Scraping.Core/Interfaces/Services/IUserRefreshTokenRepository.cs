using Web.Scraping.Core.Entities;

namespace Web.Scraping.Core.Interfaces.Services;

public interface IUserRefreshTokenRepository
{
    Task AddRefreshTokenAsync(string userId, string refreshToken, DateTime expiryTime);
    Task<RefreshToken> GetRefreshTokenAsync(string userId, string refreshToken);
    Task UpdateRefreshTokenAsync(string userId, string oldRefreshToken, string newRefreshToken);
    Task DeleteRefreshTokenAsync(string userId, string refreshToken);
    void DeleteAllRefreshTokensAsync(string userId);
    Task SaveChangesAsync();
}
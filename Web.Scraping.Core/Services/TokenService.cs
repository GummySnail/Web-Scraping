using System.Security.Claims;
using Web.Scraping.Core.Dtos.Response;
using Web.Scraping.Core.Interfaces.Data.Repositories;
using Web.Scraping.Core.Interfaces.Services;

namespace Web.Scraping.Core.Services;

public class TokenService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IUserRefreshTokenRepository _refreshTokenRepository;

    public TokenService(IUserRefreshTokenRepository refreshTokenRepository, ITokenService tokenService, IUserRepository userRepository)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    public async Task<RefreshTokenResponseDto> RefreshTokenAsync(string accessToken, string refreshToken)
    {
        var principal = _tokenService.GetPrincipalFromAccessToken(accessToken);
        var userId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
        var user = await _userRepository.GetUserByIdAsync(userId);
        var userRefreshToken = await _refreshTokenRepository.GetRefreshTokenAsync(userId, refreshToken);

        if (user is null || userRefreshToken is null || userRefreshToken.ExpiryTime <= DateTime.UtcNow)
        {
            throw new Exception("Unable to refresh token");
        }

        var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        await _refreshTokenRepository.UpdateRefreshTokenAsync(userId, refreshToken, newRefreshToken);
        await _refreshTokenRepository.SaveChangesAsync();

        return new RefreshTokenResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }

    public async Task RevokeTokenAsync(string userId, string refreshToken)
    {
        await _refreshTokenRepository.DeleteRefreshTokenAsync(userId, refreshToken);
        await _refreshTokenRepository.SaveChangesAsync();
    }

    public async Task RevokeAllTokensAsync(string userId)
    {
        _refreshTokenRepository.DeleteAllRefreshTokensAsync(userId);
        await _refreshTokenRepository.SaveChangesAsync();
    }
}
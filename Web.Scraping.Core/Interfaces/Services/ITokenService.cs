using System.Security.Claims;

namespace Web.Scraping.Core.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    ClaimsPrincipal GetPrincipalFromAccessToken(string accessToken);
}
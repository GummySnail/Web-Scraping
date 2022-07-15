using System.Security.Claims;

namespace Web.Scraping.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.NameIdentifier).Value;
}
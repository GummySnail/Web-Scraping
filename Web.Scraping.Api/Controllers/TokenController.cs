using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Scraping.Api.Extensions;
using Web.Scraping.Core.Dtos.Request;
using Web.Scraping.Core.Dtos.Response;
using Web.Scraping.Core.Services;

namespace Web.Scraping.Api.Controllers;

public class TokenController : BaseApiController
{
    private readonly TokenService _tokenService;

    public TokenController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route(nameof(RefreshToken))]
    public async Task<ActionResult<RefreshTokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
    {
        return Ok(await _tokenService.RefreshTokenAsync(request.AccessToken, request.RefreshToken));
    }

    [HttpPost, Authorize]
    [Route(nameof(RevokeToken))]
    public async Task<ActionResult> RevokeToken(RevokeTokenRequestDto request)
    {
        await _tokenService.RevokeTokenAsync(User.GetUserId(), request.RefreshToken);
        return NoContent();
    }
}
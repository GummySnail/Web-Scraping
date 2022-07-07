using Microsoft.AspNetCore.Mvc;
using Web.Scraping.Core.Dtos.Request;
using Web.Scraping.Core.Dtos.Response;
using Web.Scraping.Core.Interfaces.Data.Repositories;
using Web.Scraping.Core.Services;

namespace Web.Scraping.Api.Controllers;

public class AuthController : BaseApiController
{
    private readonly UserService _userService;
    private readonly IUserRepository _userRepository;
    
    public AuthController(IUserRepository userRepository, UserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }
    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult<RegisterResponseDto>> Register(RegisterRequestDto request)
    {
        return Ok(await _userService.RegisterUserAsync(request.UserName, request.Email, request.Password,
            request.ConfirmPassword));
    }
}
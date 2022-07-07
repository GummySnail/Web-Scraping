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

    [HttpPost]
    [Route(nameof(LoginByEmail))]
    public async Task<ActionResult<LoginResponseDto>> LoginByEmail(LoginByEmailDto request)
    {
        return Ok(await _userService.LoginByEmailAsync(request.Email, request.Password));
    }

    [HttpPost]
    [Route(nameof(LoginByUserName))]
    public async Task<ActionResult<LoginResponseDto>> LoginByUserName(LoginByUserNameDto request)
    {
        return Ok(await _userService.LoginByUserNameAsync(request.UserName, request.Password));
    }
}
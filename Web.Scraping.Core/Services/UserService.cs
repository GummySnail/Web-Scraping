using System.Security.Claims;
using Web.Scraping.Core.Dtos.Response;
using Web.Scraping.Core.Entities;
using Web.Scraping.Core.Interfaces;
using Web.Scraping.Core.Interfaces.Data.Repositories;
using Web.Scraping.Core.Interfaces.Services;

namespace Web.Scraping.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    
    public UserService(
        IUserRepository userRepository,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    
    public async Task<RegisterResponseDto> RegisterUserAsync(string userName, string email, string password, string confirmPassword)
    {
        if (await _userRepository.IsUserExistByEmailAsync(email))
        {
            throw new Exception("Email is taken");
        }

        if (await _userRepository.IsUserExistByUsernameAsync(userName))
        {
            throw new Exception("userName is taken");
        }

        if (_userRepository.IsPasswordsEquals(password, confirmPassword))
        {
            throw new Exception("Passwords aren't equals");
        }

        var user = new User().CreateUserByEmail(email, userName);

        await _userRepository.CreateUserAsync(user, password);

        var accessToken = _tokenService.GenerateAccessToken(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, "User")
        });

        return new RegisterResponseDto
        {
            Email = user.Email,
            UserName = user.UserName,
            AccessToken = accessToken,
            RefreshToken = "Refresh Token"
        };
    }

    public async Task<LoginResponseDto> LoginByEmailAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);

        if (user is null)
        {
            throw new Exception("User with this email does not exist");
        }

        if (!await _userRepository.CheckPasswordAsync(user, password))
        {
            throw new Exception("Invalid Password");
        }

        var accessToken = _tokenService.GenerateAccessToken(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, "User")
        });

        return new LoginResponseDto
        {
            Email = user.Email,
            UserName = user.UserName,
            AccessToken = accessToken,
            Refreshtoken = "Refresh Token"
        };
    }

    public async Task<LoginResponseDto> LoginByUserNameAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUserNameAsync(username);

        if (user is null)
        {
            throw new Exception("User with this username does not exist");
        }

        if (!await _userRepository.CheckPasswordAsync(user, password))
        {
            throw new Exception("Invalid Password");
        }

        var accessToken = _tokenService.GenerateAccessToken(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, "User")
        });
        
        return new LoginResponseDto
        {
            Email = user.Email,
            UserName = user.UserName,
            AccessToken = accessToken,
            Refreshtoken = "Refresh Token"
        };
    }
}
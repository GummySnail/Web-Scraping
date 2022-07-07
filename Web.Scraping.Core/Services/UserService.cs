using Web.Scraping.Core.Dtos.Request;
using Web.Scraping.Core.Dtos.Response;
using Web.Scraping.Core.Entities;
using Web.Scraping.Core.Interfaces;
using Web.Scraping.Core.Interfaces.Data.Repositories;

namespace Web.Scraping.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        return new RegisterResponseDto
        {
            Email = user.Email,
            UserName = user.UserName,
            AccessToken = "access Token",
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

        return new LoginResponseDto
        {
            Email = user.Email,
            UserName = user.UserName,
            AccessToken = "Accesss Token",
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

        return new LoginResponseDto
        {
            Email = user.Email,
            UserName = user.UserName,
            AccessToken = "Accesss Token",
            Refreshtoken = "Refresh Token"
        };
    }
}
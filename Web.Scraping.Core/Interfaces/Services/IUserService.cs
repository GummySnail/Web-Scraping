using Web.Scraping.Core.Dtos.Response;

namespace Web.Scraping.Core.Interfaces.Services;

public interface IUserService
{
    Task<RegisterResponseDto> RegisterUserAsync(string userName, string email, string password, string confirmPassword);
    Task<LoginResponseDto> LoginByEmailAsync(string email, string password);
    Task<LoginResponseDto> LoginByUserNameAsync(string username, string password);
}
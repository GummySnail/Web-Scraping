using Web.Scraping.Core.Dtos.Request;
using Web.Scraping.Core.Dtos.Response;

namespace Web.Scraping.Core.Interfaces;

public interface IUserService
{
    Task<RegisterResponseDto> RegisterUserAsync(string userName, string email, string password, string confirmPassword);
    
}
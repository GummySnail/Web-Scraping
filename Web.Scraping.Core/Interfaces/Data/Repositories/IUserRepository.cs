using Web.Scraping.Core.Entities;

namespace Web.Scraping.Core.Interfaces.Data.Repositories;

public interface IUserRepository
{
    Task<bool> IsUserExistByEmailAsync(string email);
    Task<bool> IsUserExistByUsernameAsync(string username);
    bool IsPasswordsEquals(string password, string confirmPassword);
    Task CreateUserAsync(User user, string password);
    Task<User> GetUserByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task<User> GetUserByIdAsync(string id);
    Task<User> GetUserByUserNameAsync(string username);
}
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Scraping.Core.Entities;
using Web.Scraping.Core.Interfaces.Data.Repositories;
using Web.Scraping.Infrastructure.Entities;

namespace Web.Scraping.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    
    public UserRepository(
        UserManager<AppUser> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    
    public async Task<bool> IsUserExistByEmailAsync(string email)
    {
        return await _userManager.Users.AnyAsync(x => x.NormalizedEmail == email.ToUpper());
    }

    public async Task<bool> IsUserExistByUsernameAsync(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.NormalizedUserName == username.ToUpper());
    }

    public bool IsPasswordsEquals(string password, string confirmPassword)
    {
        return !(confirmPassword.Equals(password));
    }

    public async Task CreateUserAsync(User user , string password)
    {
        var appUser = _mapper.Map<AppUser>(user);
        await _userManager.CreateAsync(appUser, password);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return _mapper.Map<User>(await _userManager.FindByEmailAsync(email.ToUpper()));
    }

    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        return _mapper.Map<User>(await _userManager.FindByIdAsync(id));
    }

    public async Task<User> GetUserByUserNameAsync(string username)
    {
        return _mapper.Map<User>(await _userManager.FindByNameAsync(username.ToUpper()));
    }
}
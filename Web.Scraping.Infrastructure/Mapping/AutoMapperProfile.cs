using AutoMapper;
using Web.Scraping.Core.Entities;
using Web.Scraping.Infrastructure.Entities;

namespace Web.Scraping.Infrastructure.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AppUser>();
        CreateMap<AppUser, User>();
    }
}
using AutoMapper;
using DatingApp.DTO;
using DatingApp.Entities;

namespace DatingApp.AutoMapper
{
    public class DatingAppProfile : Profile
    {
        public DatingAppProfile()
        {
            CreateMap<AppUser, AppUserDto>();
        }
    }
}

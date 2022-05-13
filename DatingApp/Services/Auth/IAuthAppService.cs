using DatingApp.DTO;
using DatingApp.DTO.Input;

namespace DatingApp.Services.Auth
{
    public interface IAuthAppService : IDatingAppAppService
    {
        Task<AppUserDto> Register(RegisterUser inputUser);
        Task<LoggedUserDto> Login(LoginUser inputUser);
    }
}

using DatingApp.Entities;

namespace DatingApp.Services.BearerToken
{
    public interface IBearerTokenAppService : IDatingAppAppService
    {
        string CreateToken(AppUser user);
    }
}

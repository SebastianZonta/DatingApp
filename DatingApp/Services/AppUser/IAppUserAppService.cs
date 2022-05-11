using DatingApp.DTO;

namespace DatingApp.Services
{
    public interface IAppUserAppService : IDatingAppAppService
    {
        Task<List<AppUserDto>> GetAll(CancellationToken token=default);
    }
}

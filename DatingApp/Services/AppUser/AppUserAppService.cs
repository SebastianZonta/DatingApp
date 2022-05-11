using AutoMapper;
using DatingApp.Data.Context;
using DatingApp.DTO;
using Microsoft.EntityFrameworkCore;
using DatingApp.Entities;

namespace DatingApp.Services;

public class AppUserAppService : IAppUserAppService
{
    private readonly DatingAppContext _context;
    private readonly IMapper _mapper;

    public AppUserAppService(DatingAppContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<AppUserDto>> GetAll(CancellationToken token=default)
    {
        var users=await _context.Users.ToListAsync();
        return _mapper.Map<List<AppUser>,List<AppUserDto>>(users);


    }
}

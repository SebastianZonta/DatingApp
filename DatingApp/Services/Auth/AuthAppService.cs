using AutoMapper;
using DatingApp.Data.Context;
using DatingApp.DTO;
using DatingApp.DTO.Input;
using DatingApp.Entities;
using DatingApp.Services.BearerToken;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Services.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly DatingAppContext _context;
        private readonly IMapper _mapper;
        private readonly IBearerTokenAppService _tokenAppService;

        public AuthAppService(DatingAppContext context,IMapper mapper,IBearerTokenAppService tokenAppService)
        {
            _context = context;
            _mapper = mapper;
            _tokenAppService = tokenAppService;
        }

        public async Task<LoggedUserDto> Login(LoginUser inputUser)
        {
            var user=await _context.Users.FirstOrDefaultAsync(e=>e.UserName==inputUser.UserName.ToLower());
            if (user is null) throw new Exception("Invalid credentials");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(inputUser.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) throw new Exception("Invalid credentials");

            }
            return new LoggedUserDto {UserName=user.UserName,Token=_tokenAppService.CreateToken(user)};

        }

        public async Task<LoggedUserDto> Register(RegisterUser inputUser)
        {
            var existsUser = await _context.Users.FirstOrDefaultAsync(e => e.UserName == inputUser.UserName.ToLower());
            if (existsUser is not null) throw new Exception("The user already exists");
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = inputUser.UserName.ToLower(),
                PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(inputUser.Password)),
                PasswordSalt= hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            //return _mapper.Map<AppUser,AppUserDto>(user);
            return new LoggedUserDto { UserName = user.UserName, Token = _tokenAppService.CreateToken(user) };
        }
    }
}

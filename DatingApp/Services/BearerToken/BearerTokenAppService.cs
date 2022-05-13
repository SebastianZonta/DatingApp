using DatingApp.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingApp.Services.BearerToken
{
    public class BearerTokenAppService : IBearerTokenAppService
    {
        private readonly IConfiguration _config;
        private SymmetricSecurityKey _key;

        public BearerTokenAppService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["tokenKey"]));
            _config = config;
        }
        public string CreateToken(AppUser user)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddDays(1),
                SigningCredentials=credentials

            };
            var tokenHandler=new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

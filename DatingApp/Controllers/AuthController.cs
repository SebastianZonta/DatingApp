using DatingApp.DTO.Input;
using DatingApp.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    public class AuthController : DatingAppController
    {
        private readonly IAuthAppService _service;

        public AuthController(IAuthAppService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUser input)
        {
            try
            {
                return Ok(await _service.Register(input));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUser input)
        {
            try
            {
                return Ok(await _service.Login(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

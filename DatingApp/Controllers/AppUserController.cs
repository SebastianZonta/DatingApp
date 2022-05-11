
using DatingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    public class AppUserController : DatingAppController
    {
        private readonly IAppUserAppService _service;

        public AppUserController(IAppUserAppService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("getAll")]
        public async  Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}

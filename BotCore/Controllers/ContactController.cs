using BotCoreApplication.ApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public ContactsController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet]
        [Authorize]
        [Route("contact")]
        public IActionResult GetContact()
        {
            return Ok("ta autenticado paizao");
        }
    }

}

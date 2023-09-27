using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BotCore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CEPController : ControllerBase
    {
        private readonly ICep _cep;
        public CEPController(ICep cep)
        {
            _cep = cep;
        }

        [HttpGet("{cep}")]
        [Authorize]
        public async Task<IActionResult> GetCep(string cep)
        {
            var endereco = await _cep.ObterEnderecoPorCep(cep);

            if (endereco != null)
                return Ok(endereco);

            return BadRequest(endereco);

        }
    }
}

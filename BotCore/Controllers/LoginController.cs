using Application.Interface;
using Domain.Entidades.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] User credenciais)
        {
            var resposta = await _login.BuscarLoginCliente(credenciais);

            if (resposta != null)
                return Ok(new AuthenticationResponse { Message = resposta });

            return BadRequest(new AuthenticationResponse { Message = "Credenciais inválidas. Verifique seu e-mail e senha." });
        }


    }
}

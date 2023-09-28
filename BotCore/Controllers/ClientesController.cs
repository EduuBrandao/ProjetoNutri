using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _clientes;
        public ClientesController(IClientes clientes)
        {
            _clientes = clientes;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var Clientes = await _clientes.ObterClientes();

            if (Clientes != null)
                return Ok(Clientes);

            return BadRequest(Clientes);

        }
    }
}

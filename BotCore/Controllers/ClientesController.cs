using Application.Interface;
using Domain.Entidades.Nutricionista.Clientes;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        public async Task<IActionResult> PostClientes([FromBody] Clientes cliente)
        {
            try
            {
                _clientes.AdicionarClientes(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar cliente: {ex.Message}, InnerException: {ex.InnerException?.Message}");
            }

        }
    }
}

using Application.Interface;
using Domain.Entidades.Nutricionista.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> PostClientes([FromBody] ClienteInfo cliente)
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

        [HttpPut]
        public async Task<IActionResult> PutClientes([FromBody] ClientesRequestDTO cliente)
        {
            try
            {
                var document = await _clientes.AtualizarClientes(cliente);
                return Ok(document);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar cliente: {ex.Message}, InnerException: {ex.InnerException?.Message}");
            }
        }

        [HttpDelete]
        [SwaggerOperation(
          Summary = "Cancelar um cliente pelo CPF",
          Description = "Cancela um cliente com base no CPF informado.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cliente cancelado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro ao excluir o cliente.")]
        public async Task<IActionResult> CancelarClientes(
          [FromBody][Required] string cpf)
        {
            try
            {
                var message = await _clientes.DeletarCliente(cpf);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Excluir cliente: {ex.Message}, InnerException: {ex.InnerException?.Message}");
            }
        }
    }
}

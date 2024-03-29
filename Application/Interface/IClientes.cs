﻿using Domain.Entidades.Nutricionista.Clientes;

namespace Application.Interface
{
    public interface IClientes
    {
        Task<List<ClienteInfo>> ObterClientes();

        void AdicionarClientes(ClienteInfo cliente);

        Task<ClientesResponseDTO> AtualizarClientes(ClientesRequestDTO cliente);

        Task<string> DeletarCliente(string cpf);
    }
}

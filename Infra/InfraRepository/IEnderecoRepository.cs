using Domain.Entidades.Nutricionista.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.InfraRepository
{
    public interface IEnderecoRepository
    {
        Task<List<EnderecoDTO>> Get();

        void Post(List<EnderecoDTO> enderecos);

        void Delete(int clientId);
    }
}

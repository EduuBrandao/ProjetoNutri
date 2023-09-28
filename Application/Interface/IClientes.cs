using Domain.Entidades.Nutricionista.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IClientes
    {
        Task<List<Clientes>> ObterClientes();
    }
}

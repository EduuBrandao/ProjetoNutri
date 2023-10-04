using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Nutricionista.Clientes
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Pais { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }

    }
}

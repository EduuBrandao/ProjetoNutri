using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Nutricionista.Clientes
{
    public class ClienteInfo
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }

        public List<EnderecoResponseDTO> Endereco { get; set; }
    }
}

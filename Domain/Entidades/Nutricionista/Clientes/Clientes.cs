using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Nutricionista.Clientes
{
    public class Clientes
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
    }
}

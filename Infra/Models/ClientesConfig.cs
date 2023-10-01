using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Models
{
    public partial class ClientesConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
    }
}

using Application.Interface;
using Domain.Entidades.Nutricionista.Clientes;
using Infra.InfraRepository;

namespace Application.Business
{
    public class ClienteBusiness : IClientes
    {
        private readonly INutriRepository _Nutri;
        private readonly IEnderecoRepository _endereco;
        public ClienteBusiness(INutriRepository nutri, IEnderecoRepository endereco)
        {
            _Nutri = nutri;
            _endereco = endereco;
        }
        public async Task<List<ClienteInfo>> ObterClientes()
        {
            var endereco = await _endereco.Get();
            var clientes = await _Nutri.Get();

            return ClientAdapter(endereco, clientes);
        }
        public void AdicionarClientes(ClienteInfo cliente)
        {
            var informacoesCliente = _Nutri.Post(PostClientAdapter(cliente));

            _endereco.Post(PostAdressAdapter(informacoesCliente, cliente.Endereco));
        }

        public async Task<ClientesResponseDTO> AtualizarClientes(ClientesRequestDTO cliente)
        {
            return await _Nutri.Put(cliente);
        }

        public async Task<string> DeletarCliente(string cpf)
        {
            return await _Nutri.Delete(cpf);
        }


        private List<ClienteInfo> ClientAdapter(List<EnderecoDTO> endereco, List<ClientesResponseDTO> clientes)
        {
            var clientesInfos = new List<ClienteInfo>();


            foreach (var cliente in clientes)
            {
                var clienteInfo = new ClienteInfo
                {
                    Altura = cliente.altura,
                    Cpf = cliente.cpf,
                    Peso = cliente.peso,
                    Idade = cliente.idade,
                    Nome = cliente.nome,
                    Sexo = cliente.sexo,
                    Endereco = endereco.Where(x => x.ClientId == cliente.Id).ToList()
                };

                clientesInfos.Add(clienteInfo);
            }
            return clientesInfos;
        }

        private ClientesRequestDTO PostClientAdapter(ClienteInfo cliente)
        {
            return new ClientesRequestDTO
            {
                nome = cliente.Nome,
                cpf = cliente.Cpf,
                idade = cliente.Idade,
                altura = cliente.Altura,
                sexo = cliente.Sexo
            };
        }


        private List<EnderecoDTO> PostAdressAdapter(ClientesResponseDTO informacoesCliente, List<EnderecoDTO> informacoesEnderecos)
        {
            var enderecos = new List<EnderecoDTO>();
            foreach (var enderecoInfo in informacoesEnderecos)
            {
                var endereco = new EnderecoDTO
                {
                    ClientId = informacoesCliente.Id,
                    Pais = enderecoInfo.Pais,
                    Cidade = enderecoInfo.Cidade,
                    Bairro = enderecoInfo.Bairro,
                    Endereco = enderecoInfo.Endereco,
                    Estado = enderecoInfo.Estado,
                    Numero = enderecoInfo.Numero,
                    Complemento = enderecoInfo.Complemento
                };

                enderecos.Add(endereco);
            }

            return enderecos;
        }
    }
}

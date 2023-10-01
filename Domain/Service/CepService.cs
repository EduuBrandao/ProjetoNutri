using Domain.Entidades;
using Domain.Entidades.Correio;
using Domain.Interfaces;
using System.Net.Http.Json;

namespace Domain.Service
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        
        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> ObterEnderecoPorCEPAsync(string cep)
        {
            try
            {
                // Formate o CEP para remover caracteres não numéricos
                cep = new string(cep.Where(char.IsDigit).ToArray());

                // Verifique se o CEP tem o tamanho correto (8 dígitos)
                if (cep.Length != 8)
                {
                    throw new ArgumentException("CEP inválido");
                }

                // Faça a chamada à API dos Correios
                var response = await _httpClient.GetFromJsonAsync<CEPRespondeDTO>($"https://viacep.com.br/ws/{cep}/json/");

                if (response != null)
                {
                    // Mapeie a resposta da API dos Correios para o objeto Endereco do seu domínio
                    var endereco = new Endereco
                    {
                        Logradouro = response.Logradouro,
                        Bairro = response.Bairro,
                        Cidade = response.Localidade,
                        Estado = response.Uf,
                        // Adicione outras propriedades conforme necessário
                    };

                    return endereco;
                }
                else
                {
                    throw new Exception("Não foi possível obter os dados do endereço.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter endereço: {ex.Message}");
            }
        }
        public void GetAddress(string cep)
        {
            throw new NotImplementedException();
        }
    }
}

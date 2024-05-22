using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoMyRh.ClienteAPI.Models;
using System.Net.Http.Headers;
using System.Text;

namespace ProjetoMyRh.ClienteAPI.Services
{    public class CandidatosService
    {
        private readonly HttpClient httpClient;

        public CandidatosService(IHttpClientFactory client)
        {
            httpClient = client.CreateClient();

            // p onde eu vou mandar as minhas requisições
            httpClient.BaseAddress = new Uri("http://localhost:5179/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Candidato>> ListarCAndidatosAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/candidatosapi");
                if (response.IsSuccessStatusCode) {
                    var lista = await response.Content.ReadFromJsonAsync<Candidato[]>();
                    return lista!.ToList();
                } else {
                    throw new Exception("Não foi possível obter a lista de candidatos");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task IncluirCandidatoAsync(Candidato candidato) 
        {
            try
            {
                //gerar json a partir do obj fornecido como parametro
                string? json = JsonConvert.SerializeObject(candidato);

                //gerar objeto para o fluxo de bytes para a API
                HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

                //enviar obj para API
                var response = await httpClient.PostAsync("api/candidatosapi", content);

                // se NÃO for bem secudido
                if (!response.IsSuccessStatusCode)
                {
                    string erro = $"Erro: {response.StatusCode} - {response.ReasonPhrase}";
                    throw new Exception (erro);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

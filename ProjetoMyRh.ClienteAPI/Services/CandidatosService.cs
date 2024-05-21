using System.Net.Http.Headers;

namespace ProjetoMyRh.ClienteAPI.Services
{    public class CandidatosService
    {
        private readonly HttpClient httpClient;

        public CandidatosService(IHttpClientFactory client)
        {
            httpClient = client.CreateClient();

            httpClient.BaseAddress = new Uri("http://localhost:5179/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



    }
}

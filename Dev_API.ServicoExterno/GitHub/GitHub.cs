using Dev_API.Dominio.Entidade.GitHub;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dev_API.ServicoExterno.GitHub
{
    public class GitHub : IGitHub
    {

        private string _endPoint;
        private HttpClient _httpClient;


        public GitHub(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _endPoint = configuration.GetSection("GitHub:endpoint").Value;

            _httpClient = httpClientFactory.CreateClient("HttpClient");
        }

        public async Task<GithubApi.GitHub> ConsultarGitHub(string usuario)
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
            string.Format(_endPoint, usuario));
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var result = await _httpClient.SendAsync(request);

            if (result.IsSuccessStatusCode
                && result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await result.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<GithubApi.GitHub>(json);
            }
            return new GithubApi.GitHub();
        }
    }
}

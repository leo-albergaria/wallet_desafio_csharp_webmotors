using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TesteWebMotors.Dominio.Models;

namespace TesteWebMotors.Dominio.Services
{
    public class AnuncioAPIMakeService
    {

        private HttpClient _httpClient;
        private readonly string _urlDaAPI;

        public AnuncioAPIMakeService(IConfiguration configuration)
        {
            _urlDaAPI = "https://desafioonline.webmotors.com.br/api/OnlineChallenge/"; //configuration["API:URL"].ToString();
            _httpClient = new HttpClient();
        }

        public async Task<List<AnuncioAPIMakes>> ObterListaMarca()
        {
            var resposta = await _httpClient.GetAsync(_urlDaAPI + "Make");

            if (resposta.IsSuccessStatusCode)
            {
                var conteudoDaResposta = await resposta.Content.ReadAsStringAsync();
                var conversaoDoJson = JsonConvert.DeserializeObject<List<AnuncioAPIMakes>>(conteudoDaResposta);
                return conversaoDoJson;
            }
            return new List<AnuncioAPIMakes>();
        }
    }
}
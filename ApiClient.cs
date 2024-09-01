using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AgentSqlMonitor
{
    internal class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task SendServerInfoAsync(ServerInfo serverInfo)
        {
            string json = JsonSerializer.Serialize(new { serverInfo.ServerName });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:5285/api/Server/", content);

            if (response.IsSuccessStatusCode)
            {
                Console.Write("Requisição enviada com sucesso");
            }
            else
            {
                Console.WriteLine("Falha ao enviar requisição");
            }
        }
    }
}

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;

namespace PlatformsService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformCreateDto platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                System.Text.Encoding.UTF8,
                "application/json");

            string urlPath = _configuration["CommandService:Url"] + "/api/commands/platforms";
            var result = await _httpClient.PostAsync(urlPath, httpContent);

            System.Console.WriteLine($"HttpCall to {urlPath} was {(result.IsSuccessStatusCode ? "OK" : "not OK")}");
        }
    }
}
using Microsoft.Extensions.Logging.Abstractions;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class LoggingService : ILoggingService
    {
        private readonly HttpClient _httpClient;
        private const string _ControllerEndpoint = "api/ErrorLogs/send-error-logg";

        public LoggingService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task LogErrorAsync(string message)
        {
            await _httpClient.PostAsJsonAsync(_ControllerEndpoint, message);
        }
    }
}

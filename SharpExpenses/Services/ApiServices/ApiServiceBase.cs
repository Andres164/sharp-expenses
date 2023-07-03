using SharpExpenses.Services.ApiServices.Contracts;

namespace SharpExpenses.Services.ApiServices
{
    public abstract class ApiServiceBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILoggingService _loggingService;
        protected abstract string ControllerEndpoint { get; }

        public ApiServiceBase(IHttpClientFactory clientFactory, ILoggingService loggingService)
        {
            this._httpClient = clientFactory.CreateClient("API"); ;
            this._loggingService = loggingService;
        }
    }
}

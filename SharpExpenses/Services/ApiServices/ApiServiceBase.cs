namespace SharpExpenses.Services.ApiServices
{
    public abstract class ApiServiceBase
    {
        protected readonly HttpClient _httpClient;
        protected abstract string ControllerEndpoint { get; }

        public ApiServiceBase(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("API"); ;
        }
    }
}

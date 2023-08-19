using SharpExpenses.Services.ApiServices.Contracts;

namespace SharpExpenses.Services.ApiServices
{
    public abstract class ApiServiceBase
    {
        protected readonly HttpClient _httpClient;
        protected abstract string ControllerEndpoint { get; }

        public ApiServiceBase(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
    }
}

using libre_pensador_api.Models.RequestModels;
using SharpExpenses.Services.ApiServices.Contracts;

namespace SharpExpenses.Services.ApiServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(IHttpClientFactory httpClientFactory) 
        { 

        }

        public Task Authenticate(UserCredentials userCredentials)
        {
            
        }

        public Task<bool> IsSessionAuthenticated()
        {
            throw new NotImplementedException();
        }
    }
}

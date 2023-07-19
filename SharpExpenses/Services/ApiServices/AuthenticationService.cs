using libre_pensador_api.Models.RequestModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class AuthenticationService : ApiServiceBase, IAuthenticationService
    {
        protected override string ControllerEndpoint => "api/Authentication";
        private readonly CustomAuthStateProvider _authenticationStateProvider;

        public AuthenticationService(IHttpClientFactory httpClientFactory, CustomAuthStateProvider authenticationStateProvider) 
            : base(httpClientFactory)
        {
            this._authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Authenticate(UserCredentials userCredentials)
        {
            var response = await this._httpClient.PostAsJsonAsync<UserCredentials>($"{this.ControllerEndpoint}/authenticate", userCredentials);
            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return false;
            response.EnsureSuccessStatusCode();
            await this._authenticationStateProvider.StateChanged();
            return true;
        }

        public async Task<bool> IsSessionAuthenticated()
        {
            var response = await this._httpClient.GetAsync($"{this.ControllerEndpoint}/checkIfAuthenticated");
            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return false;
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}

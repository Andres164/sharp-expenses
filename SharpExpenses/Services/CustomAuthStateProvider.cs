using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Security.Claims;

namespace SharpExpenses.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly NavigationManager _navigationManager;

        public CustomAuthStateProvider(IAuthenticationService authenticationService, NavigationManager navigationManager)
        {
            this._authenticationService = authenticationService;
            this._navigationManager = navigationManager;
        }

        public async Task StateChanged()
        {
            var state = await this.GetAuthenticationStateAsync();
            this.NotifyAuthenticationStateChanged(Task.FromResult(state));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            bool isSessionAuthenticated = await this._authenticationService.IsSessionAuthenticated();
            ClaimsIdentity identity = new ClaimsIdentity();
            if (isSessionAuthenticated)
            {
                identity = new ClaimsIdentity("Custom Authentication");
            }
            else
            {
                this._navigationManager.NavigateTo("/logIn");
            }
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            return state;
        }
    }
}

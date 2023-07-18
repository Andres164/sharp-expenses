using Microsoft.AspNetCore.Components.Authorization;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Security.Claims;

namespace SharpExpenses.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationService _authenticationService;

        public CustomAuthStateProvider(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            bool isSessionAuthenticated = await this._authenticationService.IsSessionAuthenticated();
            ClaimsIdentity identity = new ClaimsIdentity();
            if (isSessionAuthenticated)
                identity.AddClaim(new Claim("IsAuthenticated", "true"));

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }
    }
}

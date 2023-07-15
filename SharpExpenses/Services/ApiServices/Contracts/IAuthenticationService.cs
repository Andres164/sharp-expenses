using libre_pensador_api.Models.RequestModels;

namespace SharpExpenses.Services.ApiServices.Contracts
{
    public interface IAuthenticationService
    {
        Task Authenticate(UserCredentials userCredentials);
        Task<bool> IsSessionAuthenticated();
    }
}

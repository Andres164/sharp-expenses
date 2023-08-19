using SharpExpenses.Services.ApiServices;
using SharpExpenses.Services.ApiServices.Contracts;
using SharpExpenses.Services.ApiServices.OflineMode;

namespace SharpExpenses.Services.Factories
{
    public class ExpensesServiceFactory
    {
        public static IExpensesService CreateExpensesService(IHttpClientFactory clientFactory)
        {
            HttpClient httpClient = clientFactory.CreateClient("API");

            bool isConnectionToApiSuccesful = true; 
            if(isConnectionToApiSuccesful)
                return new ExpensesService(httpClient);

            return new LocalExpenseService();
        }
    }
}

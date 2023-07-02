using SharedModels.Models;
using SharedModels.RequestModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SharpExpenses.Services.ApiServices
{
    public class ProfitPerPeriodsService : ApiServiceBase, IProfitPerPeriodsService
    {
        protected override string ControllerEndpoint => "api/Profits";

        public ProfitPerPeriodsService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }


        public async Task Read(ProfitOfPeriodRequest period)
        {
            var httpResponse = await this._httpClient.GetFromJsonAsync<ProfitOfPeriod>(this.ControllerEndpoint);
        }
    }
}

using SharedModels.Models;
using SharedModels.RequestModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class ProfitPerPeriodsService : ApiServiceBase, IProfitPerPeriodsService
    {
        protected override string ControllerEndpoint => "api/Profits";

        public ProfitPerPeriodsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }


        public async Task<List<ProfitOfPeriod>> Read(ProfitOfPeriodRequest profitsOfPeriodRequest)
        {
            string periodStart = profitsOfPeriodRequest.PeriodStart.ToShortDateString(),
                   periodEnd = profitsOfPeriodRequest.PeriodEnd.ToShortDateString();
            string uri = $"{this.ControllerEndpoint}?PeriodStart={periodStart}Z&PeriodEnd={periodEnd}Z&PeriodDivision={profitsOfPeriodRequest.PeriodDivision}";

            var httpResponse = await this._httpClient.GetAsync(uri);
            httpResponse.EnsureSuccessStatusCode();

            var profitsOfPeriod = await httpResponse.Content.ReadFromJsonAsync<List<ProfitOfPeriod>>();
            return profitsOfPeriod!; // profitsOfPeriod cannot be null, as the API always returns a value
        }
    }
}

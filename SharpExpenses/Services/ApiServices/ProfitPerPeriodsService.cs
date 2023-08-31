using SharedModels.Models;
using SharedModels.RequestModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class ProfitPerPeriodsService : ApiServiceBase, IProfitPerPeriodsService
    {
        protected override string ControllerEndpoint => "api/Profits";

        public ProfitPerPeriodsService(HttpClient httpClient) : base(httpClient)
        {

        }


        public async Task<List<ProfitOfPeriod>> Read(ProfitOfPeriodRequest profitsOfPeriodRequest)
        {
            string periodStart = profitsOfPeriodRequest.PeriodStart.ToString("yyyy-MM-dd hh:mm:ss"),
                   periodEnd = profitsOfPeriodRequest.PeriodEnd.ToString("yyyy-MM-dd hh:mm:ss");
            string uri = $"{this.ControllerEndpoint}?PeriodStart={periodStart}Z&PeriodEnd={periodEnd}Z&PeriodDivision={profitsOfPeriodRequest.PeriodDivision}";

            var httpResponse = await this._httpClient.GetAsync(uri);
            httpResponse.EnsureSuccessStatusCode();

            var profitsOfPeriod = await httpResponse.Content.ReadFromJsonAsync<List<ProfitOfPeriod>>();
            return profitsOfPeriod!; // profitsOfPeriod cannot be null, as the API always returns a value
        }
    }
}

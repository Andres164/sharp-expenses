using SharedModels.Models;
using SharedModels.RequestModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class ProfitPerPeriodsService : ApiServiceBase, IProfitPerPeriodsService
    {
        protected override string ControllerEndpoint => "api/Profits";

        public ProfitPerPeriodsService(IHttpClientFactory httpClientFactory, ILoggingService loggingService)
            : base(httpClientFactory, loggingService)
        {

        }


        public async Task<ProfitOfPeriod> Read(ProfitOfPeriodRequest period)
        {
            try
            {
                string periodStart = period.PeriodStart.ToString("yyyy-MM-dd"),
                   periodEnd = period.PeriodEnd.ToString("yyyy-MM-dd");

                string uri = $"{this.ControllerEndpoint}?periodStart={periodStart}&periodEnd={periodEnd}";

                var httpResponse = await this._httpClient.GetAsync(uri);
                httpResponse.EnsureSuccessStatusCode();
                var profitsOfPeriod = await httpResponse.Content.ReadFromJsonAsync<ProfitOfPeriod>();
                return profitsOfPeriod!; // categories cannot be null, as the API always returns a value
            }
            catch (Exception ex)
            {
                await this._loggingService.LogErrorAsync($"Unexpected exception when trying to Read profits of a period: {ex}");
                throw;
            }
        }
    }
}

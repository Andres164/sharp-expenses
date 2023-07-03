using SharedModels.Models;
using SharedModels.RequestModels;

namespace SharpExpenses.Services.ApiServices.Contracts
{
    public interface IProfitPerPeriodsService
    {
        public Task<ProfitOfPeriod> Read(ProfitOfPeriodRequest period);
    }
}

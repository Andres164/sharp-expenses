using SharedModels.Models;
using SharedModels.RequestModels;

namespace SharpExpenses.Services.ApiServices.Contracts
{
    public interface IProfitPerPeriodsService
    {
        Task<List<ProfitOfPeriod>> Read(ProfitOfPeriodRequest profitsOfPeriodRequest);
    }
}

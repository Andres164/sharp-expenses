using SharedModels.RequestModels;

namespace SharpExpenses.Services.ApiServices.Contracts
{
    public interface IProfitPerPeriodsService
    {
        public Task Read(ProfitOfPeriodRequest period);
    }
}

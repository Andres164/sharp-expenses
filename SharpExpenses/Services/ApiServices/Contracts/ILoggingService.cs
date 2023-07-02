namespace SharpExpenses.Services.ApiServices.Contracts
{
    public interface ILoggingService
    {
        Task LogErrorAsync(string message);
    }
}

namespace SharpExpenses.Services.Contracts
{
    public interface ILoggingService
    {
        Task LogErrorAsync(string message);
    }
}

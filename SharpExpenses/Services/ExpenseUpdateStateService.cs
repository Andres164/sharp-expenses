using SharedModels.Models.RequestModels;

namespace SharpExpenses.Services
{
    public class ExpenseUpdateStateService
    {
        public int? ExpenseId { get; set; }
        public ExpenseRequest? CurrentExpenseRequest { get; set; }
    }
}

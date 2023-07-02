using SharedModels.Models.RequestModels;
using SharedModels.Models.ViewModels;
using SharedModels.Models;

namespace SharpExpenses.Services.ApiServices.Contracts
{
    public interface IExpensesService
    {
        Task<List<ExpenseViewModel>> ReadAll();
        Task<ExpenseViewModel?> Read(int expenseId);
        Task Create(ExpenseRequest newExpense);
        Task<Expense?> Delete(int expenseId);
        Task Update(int expenseId, ExpenseRequest updatedExpense);
    }
}

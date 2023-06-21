using SharedModels.Models.RequestModels;
using SharedModels.Models.ViewModels;
using SharedModels.Models;

namespace SharpExpenses.Services.Contracts
{
    public interface IExpensesService
    {
        Task<List<ExpenseViewModel>> ReadAll();
        Task<ExpenseViewModel?> Read(int expenseId);
        void Create(ExpenseRequest newExpense);
        Task<Expense?> Delete(int expenseId);
        void Update(int expenseId, ExpenseRequest updatedExpense);
    }
}

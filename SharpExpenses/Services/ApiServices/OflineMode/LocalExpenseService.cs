using SharedModels.Models;
using SharedModels.Models.RequestModels;
using SharedModels.Models.ViewModels;
using SharpExpenses.Services.ApiServices.Contracts;

namespace SharpExpenses.Services.ApiServices.OflineMode
{
    public class LocalExpenseService : IExpensesService
    {
        public Task Create(ExpenseRequest newExpense)
        {
            throw new NotImplementedException();
        }

        public Task<Expense?> Delete(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseViewModel?> Read(int expenseId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExpenseViewModel>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(int expenseId, ExpenseRequest updatedExpense)
        {
            throw new NotImplementedException();
        }
    }
}

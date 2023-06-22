using SharedModels.Models;
using SharedModels.Models.ViewModels;

namespace SharpExpenses.Services.Contracts
{
    public interface IExpenseCategoriesService
    {
        Task<List<ExpenseCategory>> ReadAll();
        Task<ExpenseCategoryViewModel?> Read(int categoryId);
        Task Create(ExpenseCategoryViewModel newCategory);
        Task<ExpenseCategory?> Update(ExpenseCategoryViewModel updatedCategory);
        Task<ExpenseCategory?> Delete(int categoryId);
    }
}

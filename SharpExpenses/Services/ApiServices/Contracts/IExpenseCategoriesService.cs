using SharedModels.Models;
using SharedModels.Models.ViewModels;

namespace SharpExpenses.Services.ApiServices.Contracts
{
    public interface IExpenseCategoriesService
    {
        Task<List<ExpenseCategory>> ReadAll();
        Task<ExpenseCategoryViewModel?> Read(int categoryId);
        Task<ExpenseCategory> Create(ExpenseCategoryViewModel newCategory);
        Task<ExpenseCategory?> Update(int categoryId, ExpenseCategoryViewModel updatedCategory);
        Task<ExpenseCategory?> Delete(int categoryId);
    }
}

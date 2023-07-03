using SharedModels.Models;
using SharedModels.Models.ViewModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class ExpenseCategoriesService : ApiServiceBase, IExpenseCategoriesService
    {
        protected override string ControllerEndpoint => "api/ExpenseCategories";

        public ExpenseCategoriesService(IHttpClientFactory httpClientFactory, ILoggingService loggingService)
            : base(httpClientFactory, loggingService)
        {

        }


        public async Task<List<ExpenseCategory>> ReadAll()
        {
            try
            {
                var response = await _httpClient.GetAsync(ControllerEndpoint);
                response.EnsureSuccessStatusCode();
                var categories = await response.Content.ReadFromJsonAsync<List<ExpenseCategory>>();
                return categories!; // categories cannot be null, as the API always return a list
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception when trying to read all Expense categories: {ex}"); // Properly log exceptions
                throw;
            }
        }

        public async Task<ExpenseCategoryViewModel?> Read(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task Create(ExpenseCategoryViewModel newCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpenseCategory?> Update(ExpenseCategoryViewModel updatedCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpenseCategory?> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}

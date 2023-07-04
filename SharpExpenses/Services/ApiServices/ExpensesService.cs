using SharedModels.Models;
using SharedModels.Models.RequestModels;
using SharedModels.Models.ViewModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class ExpensesService : ApiServiceBase, IExpensesService
    {
        protected override string ControllerEndpoint => "api/Expenses";

        public ExpensesService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }


        public async Task<List<ExpenseViewModel>> ReadAll()
        {
            var response = await _httpClient.GetAsync($"{ControllerEndpoint}");
            response.EnsureSuccessStatusCode();
            var expenses = await response.Content.ReadFromJsonAsync<List<ExpenseViewModel>>();
            return expenses!; // expenses cannot be null as the API always returns a List
        }

        public async Task<ExpenseViewModel?> Read(int expenseId)
        {
            var response = await _httpClient.GetAsync($"{ControllerEndpoint}/{expenseId}");
            response.EnsureSuccessStatusCode();
            var expense = await response.Content.ReadFromJsonAsync<ExpenseViewModel>();
            return expense;
        }

        public async Task Create(ExpenseRequest newExpense)
        {
            var response = await _httpClient.PostAsJsonAsync(ControllerEndpoint, newExpense);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(int expenseId, ExpenseRequest updatedExpense)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ControllerEndpoint}/{expenseId}", updatedExpense);
            response.EnsureSuccessStatusCode();
        }


        public async Task<Expense?> Delete(int expenseId)
        {
            var response = await _httpClient.DeleteAsync($"{ControllerEndpoint}/{expenseId}");
            response.EnsureSuccessStatusCode();
            var deletedExpense = await response.Content.ReadFromJsonAsync<Expense>();
            return deletedExpense;
        }
    }
}

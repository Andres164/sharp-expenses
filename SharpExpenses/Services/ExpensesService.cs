using SharedModels.Models;
using SharedModels.Models.RequestModels;
using SharedModels.Models.ViewModels;
using SharpExpenses.Services.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly HttpClient _httpClient;
        private const string _ControllerEndpoint = "api/Expenses";

        public ExpensesService(IHttpClientFactory clientFactory) 
        {
            this._httpClient = clientFactory.CreateClient("API"); ;
        }


        public async Task<List<ExpenseViewModel>> ReadAll()
        {
            try
            {
                var response = await this._httpClient.GetAsync($"{_ControllerEndpoint}");
                response.EnsureSuccessStatusCode();
                var expenses = await response.Content.ReadFromJsonAsync<List<ExpenseViewModel>>();
                return expenses!; // expenses cannot be null as the API always returns a List
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception when trying to READ All expenses : {ex}"); // Properly Log exceptions
                throw;
            }
        }

        public async Task<ExpenseViewModel?> Read(int expenseId)
        {
            try
            {
                var response = await this._httpClient.GetAsync($"{_ControllerEndpoint}/{expenseId}");
                response.EnsureSuccessStatusCode();
                var expense = await response.Content.ReadFromJsonAsync<ExpenseViewModel>();
                return expense;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception when trying to READ the expense with id {expenseId} : {ex}"); // Properly Log exceptions
                throw;
            }
        }

        public async Task Create(ExpenseRequest newExpense)
        {
            try
            {
                var response = await this._httpClient.PostAsJsonAsync<ExpenseRequest>(_ControllerEndpoint, newExpense);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Unexpected exception when trying to create a new expense: {ex}");// Properly Log exceptions
                throw;
            }
        }

        public async Task Update(int expenseId, ExpenseRequest updatedExpense)
        {
            try
            {
                var response = await this._httpClient.PutAsJsonAsync<ExpenseRequest>($"{_ControllerEndpoint}/{expenseId}", updatedExpense);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception when trying to update the expense with id {expenseId}: {ex}");// Properly Log exceptions
                throw;
            }
        }


        public async Task<Expense?> Delete(int expenseId)
        {
            try
            {
                var response = await this._httpClient.DeleteAsync($"{_ControllerEndpoint}/{expenseId}");
                response.EnsureSuccessStatusCode();
                var deletedExpense = await response.Content.ReadFromJsonAsync<Expense>();
                return deletedExpense;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception when trying to DELETE the expense with id {expenseId}: {ex}"); // Properly Log exceptions
                throw;
            }
        }
    }
}

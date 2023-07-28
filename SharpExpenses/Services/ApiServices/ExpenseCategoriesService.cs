using SharedModels.Models;
using SharedModels.Models.ViewModels;
using SharpExpenses.Services.ApiServices.Contracts;
using System.Net.Http.Json;

namespace SharpExpenses.Services.ApiServices
{
    public class ExpenseCategoriesService : ApiServiceBase, IExpenseCategoriesService
    {
        protected override string ControllerEndpoint => "api/ExpenseCategories";

        public ExpenseCategoriesService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {

        }


        public async Task<List<ExpenseCategory>> ReadAll()
        {
            var response = await _httpClient.GetAsync(this.ControllerEndpoint);
            response.EnsureSuccessStatusCode();
            var categories = await response.Content.ReadFromJsonAsync<List<ExpenseCategory>>();
            return categories!; // categories cannot be null, as the API always return a list
        }

        public async Task<ExpenseCategoryViewModel?> Read(int categoryId)
        {
            var response = await this._httpClient.GetAsync($"{this.ControllerEndpoint}/{categoryId}");

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            var category = await response.Content.ReadFromJsonAsync<ExpenseCategoryViewModel>();
            return category;
        }

        public async Task Create(ExpenseCategoryViewModel newCategory)
        {
            var response = await this._httpClient.PostAsJsonAsync(this.ControllerEndpoint, newCategory);
            response.EnsureSuccessStatusCode();
        }

        public async Task<ExpenseCategory?> Update(int categoryId, ExpenseCategoryViewModel updatedCategory)
        {
            var response = await this._httpClient.PutAsJsonAsync($"{this.ControllerEndpoint}/{categoryId}", updatedCategory);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            var responseUpdatedCat = await response.Content.ReadFromJsonAsync<ExpenseCategory>();
            return responseUpdatedCat;
        }

        public async Task<ExpenseCategory?> Delete(int categoryId)
        {
            var response = await this._httpClient.DeleteAsync($"{this.ControllerEndpoint}/{categoryId}");

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            var deletedCategory = await response.Content.ReadFromJsonAsync<ExpenseCategory>();
            return deletedCategory;
        }
    }
}

using Microsoft.AspNetCore.Components;
using Radzen;
using SharpExpenses.Services;
using SharpExpenses.Shared;

namespace SharpExpenses.Pages
{
    public class ModifyExpenseBase : ExpenseFormLayout
    {
        [Inject]
        public ExpenseUpdateStateService ExpenseUpdateStateService { get; set; } = null!;

        protected override void InitializeFormExpense()
        {
            var expenseBeingUpdated = this.ExpenseUpdateStateService.CurrentExpenseRequest;
            if (expenseBeingUpdated == null)
            {
                this.NavigateToManagement();
                return;
            }
            this._formExpense = expenseBeingUpdated;
        }

        protected async override Task HandleValidSubmit()
        {
            try
            {
                if (this.ExpenseUpdateStateService.ExpenseId == null)
                    throw new ArgumentNullException("ExpenseUpdateStateService.ExpenseId is null");
                int expenseId = Convert.ToInt32(this.ExpenseUpdateStateService.ExpenseId);
                await this.ExpensesService.Update(expenseId, this._formExpense);
                const int notificationDuration = 2000;
                this.ShowNotification("Gasto actualizado exitosamente", NotificationSeverity.Success, notificationDuration);
                this.NavigateToManagement();
            }
            catch (Exception ex) 
            {
                this.ShowNotification($"Error inesperado: {ex.Message}", NotificationSeverity.Error);
                this.ReloadPage();
            }
        }

        protected void NavigateToManagement()
        {
            this.UriHelper.NavigateTo("/");
        }
    }
}

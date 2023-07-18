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
                this.NotificationService.ShowNotification("No se encontro el gasto selecciono para ser actualizado");
                return;
            }
            this._formExpense = expenseBeingUpdated;
        }

        protected async override Task HandleValidSubmit()
        {
            this._isInitialized = false;
            try
            {
                if (this.ExpenseUpdateStateService.ExpenseId == null)
                    throw new ArgumentNullException("ExpenseUpdateStateService.ExpenseId is null");
                int expenseId = Convert.ToInt32(this.ExpenseUpdateStateService.ExpenseId); // Convertion because ExpenseId is nullable int
                await this.ExpensesService.Update(expenseId, this._formExpense);
                const int notificationDuration = 2000;
                this.NotificationService.ShowNotification("Gasto actualizado exitosamente", NotificationSeverity.Success, notificationDuration);
                this.NavigateToManagement();
            }
            catch (Exception) 
            {
                this.NotificationService.ShowErrorNotification("Ocurrio un error inesperado al intentar actualizar el gasto");
                int reloadDelay = 1000;
                this.ReloadPage(reloadDelay);
            }
        }

        protected void NavigateToManagement()
        {
            this.UriHelper.NavigateTo("/");
        }
    }
}

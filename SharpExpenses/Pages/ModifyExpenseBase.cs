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
                this.UriHelper.NavigateTo("/");
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
                this.ShowNotification("Gasto actualizado exitosamente", NotificationSeverity.Success);
                var timer = new Timer(new TimerCallback(_ =>
                {
                    this.UriHelper.NavigateTo("/");
                }), null, 1000, 1000);
            }
            catch (Exception ex) 
            {
                this.ShowNotification($"Error inesperado: {ex.Message}", NotificationSeverity.Error);
                this.ReloadPage();
            }
        }
    }
}

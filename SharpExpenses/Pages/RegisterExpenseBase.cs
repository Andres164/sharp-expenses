using Radzen;
using SharpExpenses.Shared;

namespace SharpExpenses.Pages
{
    public class RegisterExpenseBase : ExpenseFormLayout
    {
        override protected async Task HandleValidSubmit()
        {
            try
            {
                await this.ExpensesService.Create(this._formExpense);
                this.ShowNotification("Gasto registrado exitosamente", NotificationSeverity.Success);
            }
            catch (Exception ex)
            {
                this.ShowNotification($"Error inesperado: {ex.Message}", NotificationSeverity.Error);
                this.ReloadPage();
            }
            this.InitializeFormExpense();
        }
    }
}

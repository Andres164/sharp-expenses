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
                this.NotificationService.ShowNotification("Gasto registrado exitosamente", NotificationSeverity.Success);
                this.InitializeFormExpense();
            }
            catch (Exception)
            {
                this.NotificationService.ShowErrorNotification("Ocurrio un error inesperado al intentar registrar el gasto");
            }
        }
    }
}

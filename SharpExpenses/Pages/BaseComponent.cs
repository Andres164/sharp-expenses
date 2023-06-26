using Microsoft.AspNetCore.Components;
using Radzen;

namespace SharpExpenses.Pages
{
    public class BaseComponent : ComponentBase
    {
        [Inject]
        public NotificationService NotificationService { get; set; } = null!;
        [Inject]
        public NavigationManager UriHelper { get; set; } = null!;

        protected void ShowNotification(string message, NotificationSeverity severity = NotificationSeverity.Info)
        {
            this.NotificationService.Notify(new NotificationMessage { Severity = severity, Summary = message, Duration = 4000 });
        }

        protected void ReloadPage()
        {
            var timer = new Timer(new TimerCallback(_ =>
            {
                this.UriHelper.NavigateTo(this.UriHelper.Uri, forceLoad: true);
            }), null, 2000, 2000);
        }
    }
}

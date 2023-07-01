using Microsoft.AspNetCore.Components;

namespace SharpExpenses.Pages
{
    public class BaseComponent : ComponentBase
    {
        [Inject]
        public SharpExpenses.Services.NotificationService NotificationService { get; set; } = null!;
        [Inject]
        public NavigationManager UriHelper { get; set; } = null!;

        protected void ReloadPage()
        {
            var timer = new Timer(new TimerCallback(_ =>
            {
                this.UriHelper.NavigateTo(this.UriHelper.Uri, forceLoad: true);
            }), null, 2000, 2000);
        }
    }
}

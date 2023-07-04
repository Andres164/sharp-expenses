using Radzen;

namespace SharpExpenses.Services
{
    public class NotificationService
    {
        private readonly Radzen.NotificationService _radzenNotificationService;
        private string _lastNotificationMessage;

        private string LastNotificationMessage
        {
            set
            {
                bool isValueNotEqualToLastNotification = value != this._lastNotificationMessage,
                     wasLastNotificationNotOverlaped = DateTime.Now >= this.LastNotificationTimeStamp.AddMilliseconds( this.LastNotificationDurationInMs + 150 );

                if (isValueNotEqualToLastNotification || wasLastNotificationNotOverlaped)
                    this.LastNotificationHasRepeatedCount = 0;
                else
                    this.LastNotificationHasRepeatedCount++;

                this._lastNotificationMessage = value;
                this.LastNotificationTimeStamp = DateTime.Now;
            }
        }
        private DateTime LastNotificationTimeStamp { get; set; }
        private int LastNotificationDurationInMs { get; set; }
        private int LastNotificationHasRepeatedCount { get; set; }
        

        public NotificationService(Radzen.NotificationService notificationService)
        {
            this._radzenNotificationService = notificationService;
            this._lastNotificationMessage = string.Empty;
            this.LastNotificationMessage = string.Empty;
            this.LastNotificationTimeStamp = DateTime.MinValue;
            this.LastNotificationDurationInMs = 0;
            this.LastNotificationHasRepeatedCount = 0;
        }

        public void ShowNotification(string message, NotificationSeverity severity = NotificationSeverity.Info, int duration = 3000)
        {
            this.LastNotificationMessage = message;
            this.LastNotificationDurationInMs = duration;
            if (this.LastNotificationHasRepeatedCount > 0)
                message = $"({LastNotificationHasRepeatedCount + 1}) {message}";
            this._radzenNotificationService.Notify(new NotificationMessage { Severity = severity, Summary = message, Duration = duration });
        }

        public void ShowErrorNotification(string message, int duration = 4000)
        {
            this.ShowNotification(message, NotificationSeverity.Error, duration);
        }
    }
}

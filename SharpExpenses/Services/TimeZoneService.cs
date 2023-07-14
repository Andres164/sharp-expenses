using Microsoft.JSInterop;

namespace SharpExpenses.Services
{
    public class TimeZoneService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly string _functionToGetClientTimeZone;
        private TimeZoneInfo? _clientTimeZone;

        public TimeZoneService(IJSRuntime jSRuntime, string jsFunctionToGetUserTimeZone) 
        {
            this._jsRuntime = jSRuntime;
            this._functionToGetClientTimeZone = jsFunctionToGetUserTimeZone;
            this._clientTimeZone = null;
        }

        public async Task SetClientTimeZone()
        {
            try
            {
                string strClientTimeZone = await this._jsRuntime.InvokeAsync<string>(this._functionToGetClientTimeZone);
                this._clientTimeZone = TimeZoneInfo.FindSystemTimeZoneById(strClientTimeZone);
            }
            catch (Exception exceptionFunctionNotFound)
            {
                throw new Exception("The given function to get the client's time zone was not found", exceptionFunctionNotFound);
            }
        }

        public DateTime ConvertLocalToUtc(DateTime localDateTime) 
        {
            this.EnsureClientTimeZoneIsNotNull();
            DateTimeOffset dateTimeOffset = TimeZoneInfo.ConvertTimeToUtc(localDateTime, this._clientTimeZone!);
            return dateTimeOffset.UtcDateTime;
        }

        public DateTime ConvertUtcToLocal(DateTime utcDateTime)
        {
            this.EnsureClientTimeZoneIsNotNull();
            DateTimeOffset dateTimeOffset = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, this._clientTimeZone!);
            return dateTimeOffset.DateTime;
        }

        private void EnsureClientTimeZoneIsNotNull()
        {
            if (this._clientTimeZone == null)
                throw new InvalidOperationException($"The client time zone hasn't been set in this object, use method {nameof(this.SetClientTimeZone)} first");
        }
    }
}

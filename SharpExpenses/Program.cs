using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SharpExpenses;
using SharpExpenses.Extensions;
using SharpExpenses.Services;
using SharpExpenses.Services.ApiServices;
using SharpExpenses.Services.ApiServices.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddTransient<CookieHandler>()
    .AddScoped(sp => sp
        .GetRequiredService<IHttpClientFactory>()
        .CreateClient("API"))
    .AddHttpClient("API", client => client.BaseAddress = new Uri("https://localhost:7068/")).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddMudServices();

builder.Services.AddScoped<Radzen.NotificationService>();
builder.Services.AddScoped<SharpExpenses.Services.NotificationService>();
builder.Services.AddScoped<ExpenseUpdateStateService>();
builder.Services.AddScoped<ILoggingService, LoggingService>();

builder.Services.AddScoped<IExpensesService, ExpensesService>();
builder.Services.AddScoped<IExpenseCategoriesService, ExpenseCategoriesService>();
builder.Services.AddScoped<IProfitPerPeriodsService, ProfitPerPeriodsService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();

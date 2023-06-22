using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SharpExpenses;
using SharpExpenses.Extensions;
using SharpExpenses.Services;
using SharpExpenses.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddTransient<CookieHandler>()
    .AddScoped(sp => sp
        .GetRequiredService<IHttpClientFactory>()
        .CreateClient("API"))
    .AddHttpClient("API", client => client.BaseAddress = new Uri("https://localhost:7068/")).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddScoped<IExpensesService, ExpensesService>();
builder.Services.AddScoped<IExpenseCategoriesService, ExpenseCategoriesService>();

await builder.Build().RunAsync();

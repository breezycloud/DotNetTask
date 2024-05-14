using Client;
using Client.Interfaces.Applicant;
using Client.Interfaces.Questions;
using Client.Services.Applicants;
using Client.Services.Questions;
using Client.Services.ThemeService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Shared.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddScoped<LayoutService>();
builder.Services.AddSingleton<AppState>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("AppUrl", http =>
{
    http.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddTransient<IApplicantService, ApplicantService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();


await builder.Build().RunAsync();

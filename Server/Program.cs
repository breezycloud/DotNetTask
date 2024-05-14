using Microsoft.EntityFrameworkCore;
using Npgsql;
using Server.Context;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();


string ConnectionString = string.Empty;
#if DEBUG
ConnectionString = builder.Configuration.GetConnectionString("Local")!;
#else
    ConnectionString = builder.Configuration.GetConnectionString("Production");
#endif

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseCosmos(ConnectionString, "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "MyTask");
});


var app = builder.Build();
// Configure the HTTP request pipeline.
SeedData.EnsureSeeded(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
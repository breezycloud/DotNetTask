using Microsoft.EntityFrameworkCore;
using Npgsql;
using Server.Context;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
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
    options.UseCosmos(ConnectionString, "JrH8pFfephFy7qZMbOCdAGY7L7oWabz2o8UL2BlDe3Fanr0ROT9vFmhVGo8FF62jb89qPRkzPRFrACDbXGOkfg==", "MyTask");
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString, o => o.SetPostgresVersion(12, 18)).EnableDetailedErrors(true)); ;

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
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);

//Configure Serilog to log JSON to a file
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(
        new CompactJsonFormatter(),
        "logs/app.json")
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.MapGet("/hello", () =>
{
    Log.Information("Received request for /hello");
    return "Hello, World!";
});

app.MapGet("/generate-logs", async () =>
{
    Log.Information("Generating logs...");
    await Task.Delay(1000);
    Log.Information("Done waiting");
    return "Logs generated";
});

app.Run("http://localhost:8080");
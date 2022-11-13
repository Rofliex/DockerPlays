using Serilog;
using Serilog.Events;

try
{
    Environment.SetEnvironmentVariable("LOG_FOLDER", "/Logs");
    var baseDirectory = Environment.GetEnvironmentVariable("LOG_FOLDER");
    if (string.IsNullOrEmpty(baseDirectory))
    {
        Console.WriteLine("Env variable LOG_FOLDER is null or empty.");
        return;
    }
    var logPath = Path.Join(baseDirectory, "log.log");

    var builder = WebApplication.CreateBuilder(args);
    var logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .WriteTo.File(logPath, LogEventLevel.Debug, "[{CorrelationId} {Level:u3}] {Username} {Message:lj}{NewLine}{Exception}")
        .CreateLogger();

    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(logger);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


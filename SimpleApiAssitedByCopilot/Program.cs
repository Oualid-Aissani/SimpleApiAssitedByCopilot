using SimpleApiAssitedByCopilot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddLogging();



var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();
app.UseRouting();


app.Run();

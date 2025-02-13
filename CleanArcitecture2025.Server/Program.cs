using CleanArcitecture2025.Server.BackgroundServices;
using Infrastructure;
using Persistence;
using Rabbit.Receiver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddHostedService<RabbitHostedService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Logging.AddConsole();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    Persistence.DbInitializer.CreateDbIfNotExists(services);
}

//await app.Services.GetRequiredService<RabbitProgram>().Receiver();

await app.RunAsync();

using Lamar.Microsoft.DependencyInjection;
using Poc.TaskHub.Api.Service.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Replaces Default DI with Lamar for Advanced Registration Scenarios
builder.Host.UseLamar((context, services) =>
{
    services.AddLamar(new ContainerRegistry());
});

// Add Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP Pipeline Configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
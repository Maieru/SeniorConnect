using Microsoft.EntityFrameworkCore;
using Negocio.Context;
using Negocio.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var vaultHelper = new VaultHelper(Environment.GetEnvironmentVariable("KEY_VAULT_NAME"));

builder.Services.AddSingleton(new IotDriver(await vaultHelper.GetMongoDbConnectionString() ?? ""));

UrlHelper.SetAmbiente(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

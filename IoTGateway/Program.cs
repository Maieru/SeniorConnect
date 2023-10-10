using Microsoft.EntityFrameworkCore;
using Negocio.Context;
using Negocio.Database;
using Negocio.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var vaultHelper = new SecretsHelper(Environment.GetEnvironmentVariable("KEY_VAULT_NAME"));

builder.Services.AddSingleton(new IotDriver(await vaultHelper.GetMongoDbConnectionString() ?? ""));

UrlHelper.SetAmbiente(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

// TODO: Mudar para banco de dados de verdade
var contextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
builder.Services.AddSingleton(new ApplicationContext(contextOptions.Options));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Necessário para testes de integração
public partial class Program { }

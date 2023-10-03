using Microsoft.EntityFrameworkCore;
using Negocio.Context;
using Negocio.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new IotDriver(builder.Configuration.GetConnectionString("MongoDbDatabase") ?? ""));

UrlHelper.SetAmbiente(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Negocio.Context;
using Negocio.Database;
using Negocio.Helpers;

var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
UrlHelper.SetAmbiente(ambiente);
var vaultHelper = new SecretsHelper(ambiente);

var sqlServerConnectionString = await vaultHelper.GetSqlServerConnectionString() ?? "";
var mongoDbConnectionString = await vaultHelper.GetMongoDbConnectionString() ?? "";

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        var contextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(sqlServerConnectionString);
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(sqlServerConnectionString), ServiceLifetime.Scoped);
        services.AddSingleton(new IotDriver(mongoDbConnectionString));
    }).Build();

host.Run();
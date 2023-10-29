using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.TOs.Configuration;
using SeniorConnect.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtConfigurationOptions>();

// Add services to the container.

var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
UrlHelper.SetAmbiente(ambiente);
var vaultHelper = new SecretsHelper(ambiente);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ApiCallHelper>();
builder.Services.AddSingleton<JwtConfigurationOptions>(jwtOptions);
builder.Services.AddScoped<AuthenticationStateProvider, UsuarioAuthenticationStateProvider>();


var contextOptions = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("seniorConnect");
builder.Services.AddSingleton<ApplicationContext>(new ApplicationContext(contextOptions.Options));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
    {
        var signingKeyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);

        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
        };
    });

builder.Services.AddAuthentication().AddCookie();

builder.Services.AddAuthorization();
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

if (ambiente != "Local")
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

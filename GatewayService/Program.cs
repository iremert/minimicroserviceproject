using Microsoft.IdentityModel.Tokens;   // eklendi
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", opts =>
    {
        opts.Authority = "http://auth-server:8080";
        opts.RequireHttpsMetadata = false;
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false   // ← aud kontrolü kapalı
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddOcelot();

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
await app.UseOcelot();
app.Run();

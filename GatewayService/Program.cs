using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1) Ocelot yap�land�rma dosyas�n� oku
builder.Configuration.AddJsonFile(
    "ocelot.json",
    optional: false,
    reloadOnChange: true);

// 2) Kimlik do�rulama (IdentityServer ? JWT Bearer)
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", opts =>
    {
        opts.Authority = "http://auth-server";  // docker-compose�ta auth-server konteyner ad�
        opts.RequireHttpsMetadata = false;      // HTTP kullan�yoruz, HTTPS zorunlu olmas�n
        opts.Audience = null;                   // Ocelot scope bazl� kontrol yapacak
    });

builder.Services.AddAuthorization();           // (iste�e ba�l� ama iyi olur)

// 3) Ocelot�u ekle
builder.Services.AddOcelot();

var app = builder.Build();

app.UseRouting();

// 4) Auth ? Ocelot
app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();                          // Gateway middleware�i
app.Run();

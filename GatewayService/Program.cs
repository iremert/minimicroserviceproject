using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1) Ocelot yapýlandýrma dosyasýný oku
builder.Configuration.AddJsonFile(
    "ocelot.json",
    optional: false,
    reloadOnChange: true);

// 2) Kimlik doðrulama (IdentityServer ? JWT Bearer)
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", opts =>
    {
        opts.Authority = "http://auth-server";  // docker-compose’ta auth-server konteyner adý
        opts.RequireHttpsMetadata = false;      // HTTP kullanýyoruz, HTTPS zorunlu olmasýn
        opts.Audience = null;                   // Ocelot scope bazlý kontrol yapacak
    });

builder.Services.AddAuthorization();           // (isteðe baðlý ama iyi olur)

// 3) Ocelot’u ekle
builder.Services.AddOcelot();

var app = builder.Build();

app.UseRouting();

// 4) Auth ? Ocelot
app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();                          // Gateway middleware’i
app.Run();

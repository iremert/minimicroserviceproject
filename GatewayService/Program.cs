using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1) Ocelot yapılandırma dosyasını oku
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// 2) Kimlik doğrulama (IdentityServer → JWT Bearer)
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", opts =>
    {
        opts.Authority = "http://auth-server:8080";   // ← auth-server iç portu 8080
        opts.RequireHttpsMetadata = false;
        opts.Audience = null;                         // scope denetimini Ocelot yapacak
    });

builder.Services.AddAuthorization();                  // isteğe bağlı ama faydalı

// 3) Ocelot’u ekle
builder.Services.AddOcelot();

var app = builder.Build();

app.UseRouting();

// 4) Auth  →  Ocelot
app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();                                // Gateway middleware’i
app.Run();

using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddIdentityServer(options =>
    {
        options.IssuerUri = "http://auth-server:8080";   // tüm token’ların iss claim’i
    })
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddTestUsers(Config.TestUsers)       // demo kullanıcılar
    .AddDeveloperSigningCredential();                    // dev anahtarı

var app = builder.Build();
app.UseIdentityServer();                                 // /.well-known, /connect/token
app.Run();

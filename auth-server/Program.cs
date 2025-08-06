var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddIdentityServer()
    .AddInMemoryIdentityResources(Config.IdentityResources)   // ← şimdi hata vermeyecek
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();


var app = builder.Build();
app.UseIdentityServer();                       // /.well-known, /connect/token endpoint’lerini ekler
app.Run();

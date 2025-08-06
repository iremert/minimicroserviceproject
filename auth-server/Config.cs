using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

public static class Config
{
    public static IEnumerable<ApiScope> ApiScopes => new[]
    {
        new ApiScope("notes-api",  "Notes API"),
        new ApiScope("users-api",  "Users API")
    };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<Client> Clients => new[]
    {
        new Client
        {
            ClientId = "gateway_client",
            ClientSecrets     = { new Secret("gateway_secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes     = { "notes-api", "users-api" }
        }
    };

    public static List<TestUser> TestUsers => new()
    {
        new TestUser
        {
            SubjectId = "1",
            Username  = "demo",
            Password  = "password"
        }
    };
}

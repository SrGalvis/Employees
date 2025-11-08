using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Employees.Frontend.AuthenticationProviders;

public class AuthenticationProviderTest : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        await Task.Delay(1000);
        var anonimous = new ClaimsIdentity();
        var user = new ClaimsIdentity(authenticationType: "test");
        var admin = new ClaimsIdentity(
        [
            new("FirstName", "Carlos"),
            new("LastName", "Galvis"),
            new(ClaimTypes.Name, "carlosgalvis@yopmail.com"),
            new(ClaimTypes.Role, "Admin")
        ],
        authenticationType: "test");

        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(admin)));
    }
}
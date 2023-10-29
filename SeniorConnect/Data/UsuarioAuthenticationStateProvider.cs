using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Negocio.Model;
using System.Security.Claims;

namespace SeniorConnect.Data
{
    public class UsuarioAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ProtectedSessionStorage ProtectedSessionStorage { get; }
        private readonly AuthenticationState AnonymousUser = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public UsuarioAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage)
        {
            ProtectedSessionStorage = protectedSessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await ProtectedSessionStorage.GetAsync<UsuarioModel>("user");
                 
                if (!userSession.Success || userSession.Value == null || string.IsNullOrEmpty(userSession.Value.Usuario))
                    return await Task.FromResult(AnonymousUser);

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userSession.Value.Usuario)
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(AnonymousUser);
            }
        }

        public async Task SetAuthenticationStateAsync(UsuarioModel usuario)
        {
            if (usuario == null)
            {
                await ProtectedSessionStorage.DeleteAsync("user");
                NotifyAuthenticationStateChanged(Task.FromResult(AnonymousUser));
                return;
            }

            await ProtectedSessionStorage.SetAsync("user", usuario);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, usuario.Usuario)
                }, "CustomAuth")))));
        }
    }
}

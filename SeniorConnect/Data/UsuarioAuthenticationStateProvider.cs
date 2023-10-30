using Amazon.Runtime.Internal.Transform;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.TOs;
using Newtonsoft.Json;
using System.Security.Claims;

namespace SeniorConnect.Data
{
    public class UsuarioAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ProtectedSessionStorage ProtectedSessionStorage { get; }
        private ApiCallHelper ApiCallHelper { get; }

        private readonly AuthenticationState AnonymousUser = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public UsuarioAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage, ApiCallHelper apiCallHelper)
        {
            ProtectedSessionStorage = protectedSessionStorage;
            ApiCallHelper = apiCallHelper;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userInSession = await SessionHelper.GetUserFromSession(ProtectedSessionStorage);

                if (userInSession == null || string.IsNullOrEmpty(userInSession.Usuario))
                    return await Task.FromResult(AnonymousUser);

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[] {
                    new Claim("subject", userInSession.Id.ToString()),
                    new Claim("name", userInSession.Usuario),
                    new Claim("assinatura", userInSession.AssinaturaId.ToString())
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

            await SessionHelper.SetUserInSession(ProtectedSessionStorage, usuario);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[] {
                    new Claim("subject", usuario.Id.ToString()),
                    new Claim("name", usuario.Usuario),
                    new Claim("assinatura", usuario.AssinaturaId.ToString())
                }, "CustomAuth")))));

            var responseToken = await ApiCallHelper.Get<TokenTO>("Token/v1/CreateToken", parameters: new Dictionary<string, string>()
            {
                new KeyValuePair<string, string>("username", usuario.Usuario),
                new KeyValuePair<string, string>("password", usuario.Senha),
            });

            if (!responseToken.Sucesso)
                throw new Exception(responseToken.Mensagem);

            await SessionHelper.SetTokenInSession(ProtectedSessionStorage, responseToken.Dados.Token);
        }
    }
}

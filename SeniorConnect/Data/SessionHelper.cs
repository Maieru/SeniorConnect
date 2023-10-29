using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Negocio.Model;

namespace SeniorConnect.Data
{
    public static class SessionHelper
    {
        private const string JWT_TOKEN_KEY = "jwt-token";
        private const string USUARIO_KEY = "user";

        public static async Task<string> GetTokenFromSession(ProtectedSessionStorage sessionStorage)
        {
            var bearerToken = "";
            var bearerTokenStorage = await sessionStorage.GetAsync<string>(JWT_TOKEN_KEY);

            if (bearerTokenStorage.Success && bearerTokenStorage.Value != null)
                bearerToken = bearerTokenStorage.Value;

            return bearerToken;
        }

        public static async Task SetTokenInSession(ProtectedSessionStorage sessionStorage, string token)
        {
            await sessionStorage.SetAsync(JWT_TOKEN_KEY, token);
        }

        public static async Task<UsuarioModel> GetUserFromSession(ProtectedSessionStorage sessionStorage)
        {
            UsuarioModel usuario = null;
            var usuarioStorage = await sessionStorage.GetAsync<UsuarioModel>(USUARIO_KEY); ;

            if (usuarioStorage.Success && usuarioStorage.Value != null)
                usuario = usuarioStorage.Value;

            return usuario;
        }

        public static async Task SetUserInSession(ProtectedSessionStorage sessionStorage, UsuarioModel usuario)
        {
            await sessionStorage.SetAsync(USUARIO_KEY, usuario);
        }
    }
}

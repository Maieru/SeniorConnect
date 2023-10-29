using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Linq;
using Negocio.Model;
using Negocio.TOs.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    public class TokenHelper
    {
        public JwtConfigurationOptions JwtConfigurationOptions { get; set; }

        public TokenHelper(JwtConfigurationOptions jwtConfigurationOptions)
        {
            JwtConfigurationOptions = jwtConfigurationOptions;
        }

        public string CreateAccessToken(UsuarioModel usuario)
        {
            var keyBytes = Encoding.UTF8.GetBytes(JwtConfigurationOptions.SigningKey);
            var symmetricKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256); 

            var claims = new List<Claim>()
            {
                new Claim("subject", usuario.Usuario),
                new Claim("assinatura", usuario.AssinaturaId.ToString())                 
            };

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: JwtConfigurationOptions.Issuer,
                audience: JwtConfigurationOptions.Audience,
                expires: DateTime.Now.AddSeconds(JwtConfigurationOptions.ExpirationSeconds),
                signingCredentials: signingCredentials);

            var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
            
            return rawToken;
        }
    }
}

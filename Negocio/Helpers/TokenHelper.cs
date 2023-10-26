using Microsoft.IdentityModel.Tokens;
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

        public string CreateAccessToken(string username)
        {
            //var keyBytes = Encoding.UTF8.GetBytes(JwtConfigurationOptions.SigningKey);
            //var symmetricKey = new SymmetricSecurityKey(keyBytes);

            //var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256); 

            //var claims = new List<Claim>()
            // {
            //     new Claim("sub", username),
            //     new Claim("name", username),
            //     new Claim("aud", jwtOptions.Audience)
            // };

            //var roleClaims = permissions.Select(x => new Claim("role", x));
            //claims.AddRange(roleClaims);

            //var token = new JwtSecurityToken(
            //    issuer: jwtOptions.Issuer,
            //    audience: jwtOptions.Audience,
            //    claims: claims,
            //    expires: DateTime.Now.Add(expiration),
            //    signingCredentials: signingCredentials);

            //var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
            //return rawToken;
            return string.Empty;
        }
    }
}

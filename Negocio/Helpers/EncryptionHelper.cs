using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    public static class EncryptionHelper
    {
        public static async Task<string> Criptografa(string texto)
        {
            var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var vaultHelper = new SecretsHelper(ambiente);

            _ = int.TryParse(await vaultHelper.GetEncryptiontWorkFactor(), out var workFactor);
            var encrptionSalt = await vaultHelper.GetEncryptionSalt();

            using (var sha512 = SHA512.Create())
            {
                var hash = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(texto + encrptionSalt)));
                return BCrypt.Net.BCrypt.HashPassword(hash, workFactor);
            }
        }

        public static async Task<bool> VerificaSenha(string senhaPlain, string senhaEncriptografada)
        {
            var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var vaultHelper = new SecretsHelper(ambiente);

            var encrptionSalt = await vaultHelper.GetEncryptionSalt();

            using (var sha512 = SHA512.Create())
            {
                var hash = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(senhaPlain + encrptionSalt)));
                return BCrypt.Net.BCrypt.Verify(hash, senhaEncriptografada);
            }
        }
    }
}

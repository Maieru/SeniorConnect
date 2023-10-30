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
            var workFactor = Convert.ToInt32(Environment.GetEnvironmentVariable("EncryptionWorkFactor"));
            var encrptionSalt = Environment.GetEnvironmentVariable("EncryptionSalt");

            using (var sha512 = SHA512.Create())
            {
                var hash = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(texto + encrptionSalt)));
                return BCrypt.Net.BCrypt.HashPassword(hash, workFactor);
            }
        }

        public static bool VerificaSenha(string senhaPlain, string senhaEncriptografada)
        {
            var encrptionSalt = Environment.GetEnvironmentVariable("EncryptionSalt");

            using (var sha512 = SHA512.Create())
            {
                var hash = Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(senhaPlain + encrptionSalt)));
                return BCrypt.Net.BCrypt.Verify(hash, senhaEncriptografada);
            }
        }
    }
}

using Amazon.Runtime.Internal.Util;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    public class VaultHelper
    {
        private const string MONGO_DB_CONNECTION_STRING_KEY = "MongoDbDatabase";

        private readonly SecretClient secretClient;

        public VaultHelper(string? vaultName)
        {
            var vaultUrl = $"https://{vaultName}.vault.azure.net";
            secretClient = new SecretClient(new Uri(vaultUrl ?? ""), new DefaultAzureCredential());
        }

        public async Task<string> GetMongoDbConnectionString()
        {
            var secret = await secretClient.GetSecretAsync(MONGO_DB_CONNECTION_STRING_KEY);
            return secret.Value.Value;
        }

    }
}

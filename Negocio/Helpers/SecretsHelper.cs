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
    public class SecretsHelper
    {
        private const string MONGO_DB_CONNECTION_STRING_KEY = "MongoDbDatabase";
        private const string SQL_SERVER_CONNECTION_STRING_KEY = "SqlServerDatabase";

        private readonly string? vaultName;

        private SecretClient _secretClient;
        private SecretClient SecretClient
        {
            get
            {
                if (_secretClient == null)
                    _secretClient = new SecretClient(new Uri(MontaUrlVault()), new DefaultAzureCredential());

                return _secretClient;
            }
        }

        public SecretsHelper(string? vaultName)
        {
            this.vaultName = vaultName;
        }

        public async Task<string?> GetMongoDbConnectionString()
        {
            if (vaultName == null)
                return Environment.GetEnvironmentVariable(MONGO_DB_CONNECTION_STRING_KEY);

            var secret = await SecretClient.GetSecretAsync(MONGO_DB_CONNECTION_STRING_KEY);
            return secret.Value.Value;
        }

        public async Task<string?> GetSqlServerConnectionString()
        {
            if (vaultName == null)
                return Environment.GetEnvironmentVariable(SQL_SERVER_CONNECTION_STRING_KEY);

            var secret = await SecretClient.GetSecretAsync(SQL_SERVER_CONNECTION_STRING_KEY);
            return secret.Value.Value;
        }

        private string MontaUrlVault() => $"https://{vaultName ?? ""}.vault.azure.net";
    }
}

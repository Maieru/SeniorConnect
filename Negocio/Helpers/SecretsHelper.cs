using Amazon.Runtime.Internal.Util;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Negocio.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    public class SecretsHelper
    {
        private string cachedWorkFactor;
        private string cachedEncryptionSalt;
        
        private const string VAULT_NAME_ENVIROMENT = "KEY_VAULT_NAME";

        private const string MONGO_DB_CONNECTION_STRING_KEY = "MongoDbDatabase";
        private const string SQL_SERVER_CONNECTION_STRING_KEY = "SqlServerDatabase";
        private const string ENCRYPTION_WORK_FACTOR = "EncryptionWorkFactor";
        private const string ENCRYPTION_SALT = "EncryptionSalt";
        private const string SEND_GRID_API_KEY = "SendGridApiKey";
        private const string REMETENTE_EMAIL = "RemetenteEmail";

        private readonly string? ambiente;

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

        public SecretsHelper(string? ambiente)
        {
            this.ambiente = ambiente;
        }

        public async Task<string?> GetMongoDbConnectionString()
        {
            if (ambiente == EnvironmentNames.AMBIENTE_LOCAL)
                return Environment.GetEnvironmentVariable(MONGO_DB_CONNECTION_STRING_KEY);

            var secret = await SecretClient.GetSecretAsync(MONGO_DB_CONNECTION_STRING_KEY);
            return secret.Value.Value;
        }

        public async Task<string?> GetSqlServerConnectionString()
        {
            if (ambiente == EnvironmentNames.AMBIENTE_LOCAL)
                return Environment.GetEnvironmentVariable(SQL_SERVER_CONNECTION_STRING_KEY);

            var secret = await SecretClient.GetSecretAsync(SQL_SERVER_CONNECTION_STRING_KEY);
            return secret.Value.Value;
        }

        public async Task<string?> GetEncryptiontWorkFactor()
        {
            if (!string.IsNullOrEmpty(cachedWorkFactor))
                return cachedWorkFactor;

            if (ambiente == EnvironmentNames.AMBIENTE_LOCAL)
                return Environment.GetEnvironmentVariable(ENCRYPTION_WORK_FACTOR);

            var secret = await SecretClient.GetSecretAsync(ENCRYPTION_WORK_FACTOR);
            cachedWorkFactor = secret.Value.Value;

            return cachedWorkFactor;
        }

        public async Task<string?> GetEncryptionSalt()
        {
            if (!string.IsNullOrEmpty(cachedEncryptionSalt))
                return cachedEncryptionSalt;

            if (ambiente == EnvironmentNames.AMBIENTE_LOCAL)
                return Environment.GetEnvironmentVariable(ENCRYPTION_SALT);

            var secret = await SecretClient.GetSecretAsync(ENCRYPTION_SALT);
            cachedEncryptionSalt = secret.Value.Value;

            return cachedEncryptionSalt;
        }

        public async Task<string?> GetSendGridAPIKey()
        {
            if (ambiente == EnvironmentNames.AMBIENTE_LOCAL)
                return Environment.GetEnvironmentVariable(SEND_GRID_API_KEY);

            var secret = await SecretClient.GetSecretAsync(SEND_GRID_API_KEY);
            
            return secret.Value.Value;
        }

        public async Task<string?> GetRemetenteEmail()
        {
            if (ambiente == EnvironmentNames.AMBIENTE_LOCAL)
                return Environment.GetEnvironmentVariable(REMETENTE_EMAIL);

            var secret = await SecretClient.GetSecretAsync(REMETENTE_EMAIL);

            return secret.Value.Value;
        }

        private string MontaUrlVault()
        {
            var vaultName = Environment.GetEnvironmentVariable(VAULT_NAME_ENVIROMENT);
            return $"https://{vaultName ?? ""}.vault.azure.net";
        }
    }
}

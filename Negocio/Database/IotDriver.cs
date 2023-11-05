using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Negocio.Model.IotMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Context
{
    public class IotDriver
    {
        private const string DATABASE_NAME = "SeniorConnect";
        private const string COLLECTION_NAME_PULSEIRA = "IotMessagesPulseira";
        private const string COLLECTION_NAME_CAIXA = "IotMessagesCaixaRemedio";

        private IMongoDatabase _database;

        public IotDriver(string connectionString)
        {
            var driver = new MongoClient(connectionString);
            _database = driver.GetDatabase(DATABASE_NAME);
        }

        public IMongoCollection<StatusPulseiraModel> GetIoTMessagePulseiraCollection() => _database.GetCollection<StatusPulseiraModel>(COLLECTION_NAME_PULSEIRA);
        public IMongoCollection<StatusCaixaRemedioModel> GetIoTMessageCaixaCollection() => _database.GetCollection<StatusCaixaRemedioModel>(COLLECTION_NAME_CAIXA);
    }
}

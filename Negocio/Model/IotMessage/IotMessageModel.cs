using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Negocio.TOs.IotMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.IotMessage
{
    public abstract class IotMessageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int DeviceId { get; set; }

        public string? DeviceKey { get; set; }

        public IotMessageModel() { }

        public IotMessageModel(IotMessageTO to)
        {
            DeviceId = to.DeviceId.GetValueOrDefault();
            DeviceKey = to?.DeviceKey;
        }
    }
}

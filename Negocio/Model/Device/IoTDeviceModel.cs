using Negocio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model.Device
{
    [Table("tbIotDevice")]
    public class IoTDeviceModel
    {
        [Column("Id")]
        [Key]
        public int DeviceId { get; set; }

        [Column("IdentificationKey")]
        public string? DeviceKey { get; set; }

        [Column("Tipo")]
        public EnumDeviceType DeviceType { get; set; }

        [Column("AssinaturaId")]
        public int AssinaturaId { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        public IoTDeviceModel() { }

        public IoTDeviceModel(int deviceId, string deviceKey)
        {
            DeviceId = deviceId;
            DeviceKey = deviceKey;
        }
    }
}

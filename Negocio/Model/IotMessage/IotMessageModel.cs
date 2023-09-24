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
        [Key]
        public int Id { get; set; }

        public int DeviceId { get; set; }
        public string DeviceKey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table("tbLembreteIoTDevice")]
    public class LembreteIoTDeviceModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("LembreteId")]
        public int LembreteId { get; set; }

        [Column("IoTDeviceId")]
        public int IoTDeviceId { get; set; }
    }
}

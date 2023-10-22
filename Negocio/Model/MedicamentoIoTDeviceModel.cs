using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    [Table("tbMedicamentoIoTDevice")]
    public class MedicamentoIoTDeviceModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("MedicamentoId")]
        public int MedicamentoId { get; set; }

        [Column("IoTDeviceId")]
        public int IoTDeviceId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Negocio.TOs.IotMessage
{
    public class IotMessageTO
    {
        [Required(ErrorMessage = "É necessário preencher o campo de DeviceId")]
        public int? DeviceId { get; set; }

        [Required(ErrorMessage = "É necessário preencher o campo de DeviceKey")]
        public string? DeviceKey { get; set; }

        public IotMessageTO(int? deviceId, string? deviceKey)
        {

            this.DeviceId = deviceId;
            this.DeviceKey = deviceKey;

        }

        public IotMessageTO() { }
    }
}

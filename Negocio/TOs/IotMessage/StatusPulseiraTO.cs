namespace Negocio.TOs.IotMessage
{
    public class StatusPulseiraTO : IotMessageTO
    {
        public int BatimentoCardiaco { get; set; }
        public bool QuedaDetectada { get; set; }
        public bool BotaoEmergenciaPressionada { get; set; }

        public StatusPulseiraTO(int deviceId, string deviceKey) : base(deviceId, deviceKey) { }

        public StatusPulseiraTO() { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    public static class UrlHelper
    {
        private static string? Ambiente { get; set; }

        public static void SetAmbiente(string? ambiente)
        {
            Ambiente = ambiente;
        }

        public static string GetWebsiteUrl()
        {
            switch (Ambiente)
            {
                case "Development":
                    return "https://dev-seniorconnect.azurewebsites.net";
                case "Production":
                    return "https://seniorconnect.azurewebsites.net";
                default:
                    return "https://localhost:7238";
            }
        }

        public static string GetIoTGatewayUrl()
        {
            switch (Ambiente)
            {
                case "Development":
                    return "https://dev-iot-seniorconnect.azurewebsites.net";
                case "Production":
                    return "https://iot-seniorconnect.azurewebsites.net";
                default:
                    return "https://localhost:5001";
            }
        }
    }
}

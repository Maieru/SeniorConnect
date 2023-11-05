using Negocio.Constantes;
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
                case EnvironmentNames.AMBIENTE_DEV:
                    return "https://dev-seniorconnect.azurewebsites.net";
                case EnvironmentNames.AMBIENTE_PRODUCAO:
                    return "https://seniorconnect.azurewebsites.net";
                default:
                    return "https://localhost:7238";
            }
        }

        public static string GetIoTGatewayUrl()
        {
            switch (Ambiente)
            {
                case EnvironmentNames.AMBIENTE_DEV:
                    return "https://dev-iot-seniorconnect.azurewebsites.net";
                case EnvironmentNames.AMBIENTE_PRODUCAO:
                    return "https://iot-seniorconnect.azurewebsites.net";
                default:
                    return "https://localhost:5001";
            }
        }
    }
}

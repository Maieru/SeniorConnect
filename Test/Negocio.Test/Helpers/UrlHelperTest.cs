using Negocio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Negocio.Test.Helpers
{
    public class UrlHelperTest
    {
        private const string AMBIENTE_LOCAL = "Local";
        private const string AMBIENTE_DEVELOPMENT = "Development";
        private const string AMBIENTE_PRODUCTION = "Production";

        [Fact]
        public void GetWebsiteUrl_Local()
        {
            UrlHelper.SetAmbiente(AMBIENTE_LOCAL);
            Assert.True(UrlHelper.GetWebsiteUrl() == "https://localhost:7238");
        }

        [Fact]
        public void GetWebsiteUrl_Dev()
        {
            UrlHelper.SetAmbiente(AMBIENTE_DEVELOPMENT);
            Assert.True(UrlHelper.GetWebsiteUrl() == "https://dev-seniorconnect.azurewebsites.net");
        }

        [Fact]
        public void GetWebsiteUrl_Prod()
        {
            UrlHelper.SetAmbiente(AMBIENTE_PRODUCTION);
            Assert.True(UrlHelper.GetWebsiteUrl() == "https://seniorconnect.azurewebsites.net");
        }

        [Fact]
        public void GetIoTGatewayUrl_Local()
        {
            UrlHelper.SetAmbiente(AMBIENTE_LOCAL);
            Assert.True(UrlHelper.GetIoTGatewayUrl() == "https://localhost:5001");
        }

        [Fact]
        public void GetIoTGatewayUrl_Dev()
        {
            UrlHelper.SetAmbiente(AMBIENTE_DEVELOPMENT);
            Assert.True(UrlHelper.GetIoTGatewayUrl() == "https://dev-iot-seniorconnect.azurewebsites.net");
        }

        [Fact]
        public void GetIotGatewayUrl_Prod()
        {
            UrlHelper.SetAmbiente(AMBIENTE_PRODUCTION);
            Assert.True(UrlHelper.GetIoTGatewayUrl() == "https://iot-seniorconnect.azurewebsites.net");
        }
    }
}

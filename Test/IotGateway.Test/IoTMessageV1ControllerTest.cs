using IotGateway.Test.Comuns;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace IotGateway.Test
{
    // See also:
    //https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
    //https://medium.com/thiagobarradas/alem-do-fact-com-xunit-dotnet-6a52b69a50d2

    public class IoTMessageV1ControllerTest : IClassFixture<IoTGatewayApplicationFactory<Program>>
    {
        private readonly IoTGatewayApplicationFactory<Program> _applicationFactory;

        public IoTMessageV1ControllerTest(IoTGatewayApplicationFactory<Program> webApplicationFactory)
        {
            _applicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task Test1()
        {
            //var client = _applicationFactory.CreateClient();
            //var response = await client.GetAsync("/swagger/index.html");
        }
    }
}
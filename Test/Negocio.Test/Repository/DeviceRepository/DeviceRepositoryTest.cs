using Negocio.Model;
using Negocio.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Negocio.Test.Repository.DeviceRepository
{
    public class DeviceRepositoryTest : BaseEntityTest<Negocio.Repository.Device.DeviceRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            // act
            var dispositivo1 = await _repository.GetByIdentification(1, guids[0]);
            var dispositivo2 = await _repository.GetByIdentification(2, guids[1]);

            // assert
            Assert.Equal(devices[0], dispositivo1);
            Assert.Equal(devices[1], dispositivo2);
            Assert.IsAssignableFrom<PulseiraModel>(dispositivo1);
            Assert.IsAssignableFrom<CaixaRemedioModel>(dispositivo2);
        }
    }
}

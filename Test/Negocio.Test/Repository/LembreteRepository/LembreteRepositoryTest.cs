using Negocio.Enum;
using Negocio.Model;
using Negocio.Model.Device;
using Xunit;

namespace Negocio.Test.Repository.LembreteRepository
{
    public class LembreteRepositoryTest : BaseEntityTest<Negocio.Repository.Lembrete.LembreteRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var lembretes = new List<LembreteModel>
            {
                new LembreteModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 }
            };
            _applicationContext.Lembretes.AddRange(lembretes);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(lembretes, result);
        }

        [Fact]
        public async Task GetAll_ShouldNotReturn()
        {
            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetById_ShouldReturn()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(lembrete, result);
        }

        [Fact]
        public async Task GetById_ShouldNotReturn()
        {
            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetById_ShouldReturnNothing()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(2);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.Lembretes);
        }

        [Fact]
        public async Task GetById_ShouldReturnAssociations()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var device = new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            var deviceLembrete = new LembreteIoTDeviceModel { Id = 1, IoTDeviceId = 1, LembreteId = 1 };

            _applicationContext.LembreteIoTDevice.Add(deviceLembrete);
            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.IoTDevices.Add(device);
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.DispositivosAssociados);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Lembretes.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteNothing()
        {
            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Lembretes.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var auxiliaryDate = DateTime.UtcNow.AddDays(-1);
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            lembrete.Horario = auxiliaryDate;

            // act
            var result = await _repository.Update(lembrete);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.Horario == auxiliaryDate);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var lembreteOriginal = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            _applicationContext.Lembretes.Add(lembreteOriginal);
            await _applicationContext.SaveChangesAsync();


            // act
            var lembreteModificado = new LembreteModel { Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var result = await _repository.Update(lembreteModificado);

            Assert.True(result == 0);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 2, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            var lembreteModificado = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(lembreteModificado));
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.AssinaturaId == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdateWithDeviceAssociation()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var device = new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.Lembretes.Add(lembrete);
            _applicationContext.IoTDevices.Add(device);
            await _applicationContext.SaveChangesAsync();

            lembrete.DispositivosAssociados = new List<int>() { 1 };

            // act
            await _repository.Update(lembrete);

            Assert.True(_applicationContext.Lembretes.FirstOrDefault() == lembrete);
            Assert.NotEmpty(_applicationContext.LembreteIoTDevice);
        }

        [Fact]
        public async Task Update_ShouldNotUpdateWithDeviceAssociation()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.Lembretes.Add(lembrete);
            await _applicationContext.SaveChangesAsync();

            lembrete.DispositivosAssociados = new List<int>() { 1 };

            // act

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(lembrete));
            Assert.Empty(_applicationContext.LembreteIoTDevice);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Insert(lembrete);

            Assert.True(result == 1);
            Assert.True(_applicationContext.Lembretes.Count() == 1);
            Assert.True(_applicationContext.Lembretes.FirstOrDefault()?.Id == 1);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(lembrete));
            Assert.True(_applicationContext.Lembretes.Count() == 0);
        }

        [Fact]
        public async Task Insert_ShouldInsertWithDeviceAssociation()
        {
            // arrange
            var device = new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira };
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1, DispositivosAssociados = new List<int>() { 1 } };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.IoTDevices.Add(device);
            await _applicationContext.SaveChangesAsync();

            // arrange
            await _repository.Insert(lembrete);

            Assert.True(_applicationContext.Lembretes.FirstOrDefault() == lembrete);
            Assert.NotEmpty(_applicationContext.LembreteIoTDevice);
        }

        [Fact]
        public async Task Insert_ShouldNotInsertWithDeviceAssociation()
        {
            // arrange
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1, DispositivosAssociados = new List<int>() { 1 } };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

            _applicationContext.Assinaturas.Add(assinatura);
            await _applicationContext.SaveChangesAsync();

            // arrange

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(lembrete));
            Assert.Empty(_applicationContext.LembreteIoTDevice);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldReturn()
        {
            // arrange
            var lembretes = new List<LembreteModel>
            {
                new LembreteModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 2 },
                new LembreteModel{ Id = 4, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 3 }
            };
            _applicationContext.Lembretes.AddRange(lembretes);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetByAssinaturaId(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(lembretes[0], result[0]);
            Assert.Equal(lembretes[1], result[1]);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldNotReturn()
        {
            // arrange
            var lembretes = new List<LembreteModel>
            {
                new LembreteModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 2 },
                new LembreteModel{ Id = 4, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 3 }
            };
            _applicationContext.Lembretes.AddRange(lembretes);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetByAssinaturaId(4);

            // assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetByDevice_ShouldReturn()
        {
            // arrange
            var lembretes = new List<LembreteModel>
            {
                new LembreteModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 4, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 }
            };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
            };

            var associacoesDeviceLembrete = new List<LembreteIoTDeviceModel>
            {
                new LembreteIoTDeviceModel { Id = 1, LembreteId = 1, IoTDeviceId = 1 },
                new LembreteIoTDeviceModel { Id = 2, LembreteId = 4, IoTDeviceId = 1 },
                new LembreteIoTDeviceModel { Id = 3, LembreteId = 1, IoTDeviceId = 2 },
            };

            _applicationContext.Lembretes.AddRange(lembretes);
            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.LembreteIoTDevice.AddRange(associacoesDeviceLembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var lembretesDevice1 = await _repository.GetByDevice(devices[0]);
            var lembretesDevice2 = await _repository.GetByDevice(devices[1]);

            // assert
            Assert.NotNull(lembretesDevice1);
            Assert.Equal(2, lembretesDevice1.Count());
            Assert.Equal(lembretes[0], lembretesDevice1[0]);
            Assert.Equal(lembretes[3], lembretesDevice1[1]);

            Assert.NotNull(lembretesDevice2);
            Assert.Single(lembretesDevice2);
            Assert.Equal(lembretes[0], lembretesDevice2[0]);
        }

        [Fact]
        public async Task GetByDevice_ShouldNotReturn()
        {
            // arrange
            var lembretes = new List<LembreteModel>
            {
                new LembreteModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 },
                new LembreteModel{ Id = 4, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1 }
            };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira },
            };

            var associacoesDeviceLembrete = new List<LembreteIoTDeviceModel>
            {
                new LembreteIoTDeviceModel { Id = 1, LembreteId = 1, IoTDeviceId = 1 },
                new LembreteIoTDeviceModel { Id = 2, LembreteId = 4, IoTDeviceId = 1 },
            };

            _applicationContext.Lembretes.AddRange(lembretes);
            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.LembreteIoTDevice.AddRange(associacoesDeviceLembrete);
            await _applicationContext.SaveChangesAsync();

            // act
            var lembretesDevice = await _repository.GetByDevice(devices[1]);

            // assert
            Assert.NotNull(lembretesDevice);
            Assert.Empty(lembretesDevice);
        }

        [Fact]
        public async Task GetDevicesAssociated_ShouldReturnListOfInt_WhenLembreteIdIsValid()
        {
            // Arrange
            var lembreteId = 1;
            var device = new PulseiraModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira };
            var lembrete = new LembreteModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", AssinaturaId = 1, DispositivosAssociados = new List<int>() { 1 } };
            var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
            var lembreteIoTDeviceList = new List<LembreteIoTDeviceModel>
            {
                new LembreteIoTDeviceModel { IoTDeviceId = 1, LembreteId = 1 },
                new LembreteIoTDeviceModel { IoTDeviceId = 2, LembreteId = 1 },
                new LembreteIoTDeviceModel { IoTDeviceId = 3, LembreteId = 1 }
            };
            var expected = lembreteIoTDeviceList.Select(l => l.IoTDeviceId).ToList();
            _applicationContext.LembreteIoTDevice.AddRange(lembreteIoTDeviceList);
            _applicationContext.Assinaturas.Add(assinatura);
            _applicationContext.IoTDevices.Add(device);
            await _applicationContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetDevicesAssociated(lembreteId);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetDevicesAssociated_ShouldReturnEmptyList_WhenLembreteIdIsInvalid()
        {
            // Arrange
            var lembreteId = 1;
            var expected = new List<int>();

            // Act
            var result = await _repository.GetDevicesAssociated(lembreteId);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

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
        public async Task GetByIdentification_ShouldReturn()
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
            Assert.IsNotType<PulseiraModel>(dispositivo2);
            Assert.IsNotType<CaixaRemedioModel>(dispositivo1);
        }

        [Fact]
        public async Task GetByIdentification_ShouldNotReturn()
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
            var dispositivo1 = await _repository.GetByIdentification(2, guids[0]);
            var dispositivo2 = await _repository.GetByIdentification(1, guids[1]);
            var dispositivo3 = await _repository.GetByIdentification(0, null);

            // assert
            Assert.Null(dispositivo1);
            Assert.Null(dispositivo2);
            Assert.Null(dispositivo3);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldReturn()
        {
            // arrange
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devicesAssinatura1 = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            var devicesAssinatura2 = new List<IoTDeviceModel>
            {
                new CaixaRemedioModel {DeviceId = 3, DeviceKey = guids[2], AssinaturaId = 2, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.IoTDevices.AddRange(devicesAssinatura1);
            _applicationContext.IoTDevices.AddRange(devicesAssinatura2);
            await _applicationContext.SaveChangesAsync();

            // act
            var dispositivosAssinatura1 = await _repository.GetByAssinaturaId(1);
            var dispositivosAssinatura2 = await _repository.GetByAssinaturaId(2);

            // assert
            Assert.NotEmpty(dispositivosAssinatura1);
            Assert.NotEmpty(dispositivosAssinatura2);
            Assert.Contains(devicesAssinatura1[0], dispositivosAssinatura1);
            Assert.Contains(devicesAssinatura1[1], dispositivosAssinatura1);
            Assert.Contains(devicesAssinatura2[0], dispositivosAssinatura2);
        }

        [Fact]
        public async Task GetByAssinaturaId_ShouldNotReturn()
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
            var dispositivosAssinatura2 = await _repository.GetByAssinaturaId(2);

            // assert
            Assert.Empty(dispositivosAssinatura2);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var newDescription = "Pulseira Atualizada";
            var guids = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var devices = new List<IoTDeviceModel>
            {
                new PulseiraModel {DeviceId = 1, DeviceKey = guids[0], AssinaturaId = 1, Descricao = "Pulseira", DeviceType = Enum.EnumDeviceType.Pulseira },
                new CaixaRemedioModel {DeviceId = 2, DeviceKey = guids[1], AssinaturaId = 1, Descricao = "Caixa Remedio", DeviceType = Enum.EnumDeviceType.CaixaRemedio },
            };

            _applicationContext.Planos.Add(new PlanoModel() { Id = 1, Descricao = "Plano Teste", Valor = 59.99 });
            _applicationContext.Assinaturas.Add(new AssinaturaModel() { Id = 1, DataCriacao = DateTime.Now, PlanoId = 1 });
            _applicationContext.IoTDevices.AddRange(devices);
            await _applicationContext.SaveChangesAsync();

            devices[0].Descricao = newDescription;

            // act
            var result = await _repository.Update(devices[0]);

            Assert.True(result == 1);
            Assert.True(_applicationContext.IoTDevices.Count() == 2);
            Assert.Equal(newDescription, _applicationContext.IoTDevices.Where(d => d.DeviceId == 1).FirstOrDefault()?.Descricao);
            Assert.Equal(devices[1], _applicationContext.IoTDevices.Where(d => d.DeviceId == 2).FirstOrDefault());
        }

        //[Fact]
        //public async Task Update_ShouldUpdateNothing()
        //{
        //    // arrange
        //    var assinaturaOriginal = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
        //    _applicationContext.Assinaturas.Add(assinaturaOriginal);
        //    await _applicationContext.SaveChangesAsync();


        //    // act
        //    var assinaturaModificada = new AssinaturaModel { Id = 2, DataCriacao = DateTime.UtcNow, PlanoId = 2 };
        //    var result = await _repository.Update(assinaturaModificada);

        //    Assert.True(result == 0);
        //    Assert.True(_applicationContext.Assinaturas.Count() == 1);
        //    Assert.True(_applicationContext.Assinaturas.FirstOrDefault()?.PlanoId == 1);
        //}

        //[Fact]
        //public async Task Update_ShouldNotUpdate()
        //{
        //    // arrange
        //    var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
        //    var plano = new PlanoModel { Id = 1, Descricao = "Test 1", Valor = 1 };

        //    _applicationContext.Assinaturas.Add(assinatura);
        //    _applicationContext.Planos.Add(plano);
        //    await _applicationContext.SaveChangesAsync();

        //    var assinaturaModificada = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 2 };

        //    await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(assinaturaModificada));
        //    Assert.True(_applicationContext.Assinaturas.Count() == 1);
        //    Assert.True(_applicationContext.Assinaturas.FirstOrDefault()?.PlanoId == 1);
        //}

        //[Fact]
        //public async Task Insert_ShouldInsert()
        //{
        //    // arrange
        //    var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };
        //    var plano = new PlanoModel { Id = 1, Descricao = "Test 1", Valor = 1 };

        //    _applicationContext.Planos.Add(plano);
        //    await _applicationContext.SaveChangesAsync();


        //    // act
        //    var result = await _repository.Insert(assinatura);

        //    Assert.True(result == 1);
        //    Assert.True(_applicationContext.Assinaturas.Count() == 1);
        //    Assert.True(_applicationContext.Assinaturas.FirstOrDefault()?.Id == 1);
        //}

        //[Fact]
        //public async Task Insert_ShouldNotInsert()
        //{
        //    // arrange
        //    var assinatura = new AssinaturaModel { Id = 1, DataCriacao = DateTime.UtcNow, PlanoId = 1 };

        //    await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(assinatura));
        //    Assert.True(_applicationContext.Assinaturas.Count() == 0);
        //}
    }
}

using Negocio.Enum;
using Negocio.Model;
using Negocio.Model.Device;
using Xunit;

namespace Negocio.Test.Repository.LembreteRepository
{
    public class LembreteMedicamentoRepositoryTest : BaseEntityTest<Negocio.Repository.LembreteMedicamento.LembreteMedicamentoRepository>
    {
        [Fact]
        public async Task GetAll_ShouldReturn()
        {
            // arrange
            var lembreteMedicamento = new List<LembreteMedicamentoModel>
            {
                new LembreteMedicamentoModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 }
            };
            _applicationContext.LembreteMedicamentos.AddRange(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal(lembreteMedicamento, result);
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
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(lembreteMedicamento, result);
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
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.GetById(2);

            // assert
            Assert.Null(result);
            Assert.NotEmpty(_applicationContext.LembreteMedicamentos);
        }

        [Fact]
        public async Task Delete_ShouldDelete()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldDeleteNothing()
        {
            // act
            var result = await _repository.Delete(1);

            Assert.True(result == 0);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 0);
        }

        [Fact]
        public async Task Delete_ShouldNotDelete()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var result = await _repository.Delete(2);

            Assert.True(result == 0);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
        }

        [Fact]
        public async Task Update_ShouldUpdate()
        {
            // arrange
            var auxiliaryDate = DateTime.UtcNow.AddDays(-1);
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var medicamento = new MedicamentoModel { Id = 1, PosicaoNaCaixaRemedio = 1, Descricao = "abc", AssinaturaId = 1 };

            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            lembreteMedicamento.Horario = auxiliaryDate;

            // act
            var result = await _repository.Update(lembreteMedicamento);

            Assert.True(result == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.Horario == auxiliaryDate);
        }

        [Fact]
        public async Task Update_ShouldUpdateNothing()
        {
            // arrange
            var lembreteMedicamentoOriginal = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamentoOriginal);
            await _applicationContext.SaveChangesAsync();


            // act
            var lembreteMedicamentoModificado = new LembreteMedicamentoModel { Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var result = await _repository.Update(lembreteMedicamentoModificado);

            Assert.True(result == 0);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.MedicamentoId == 1);
        }

        [Fact]
        public async Task Update_ShouldNotUpdate()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var medicamento = new MedicamentoModel { Id = 2, PosicaoNaCaixaRemedio = 1, Descricao = "abc", AssinaturaId = 1 };

            _applicationContext.LembreteMedicamentos.Add(lembreteMedicamento);
            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();

            var lembreteMedicamentoModificado = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Update(lembreteMedicamentoModificado));
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.MedicamentoId == 1);
        }

        [Fact]
        public async Task Insert_ShouldInsert()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };
            var medicamento = new MedicamentoModel { Id = 1, PosicaoNaCaixaRemedio = 1, Descricao = "abc", AssinaturaId = 1 };

            _applicationContext.Medicamentos.Add(medicamento);
            await _applicationContext.SaveChangesAsync();


            // act
            var result = await _repository.Insert(lembreteMedicamento);

            Assert.True(result == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 1);
            Assert.True(_applicationContext.LembreteMedicamentos.FirstOrDefault()?.Id == 1);
        }

        [Fact]
        public async Task Insert_ShouldNotInsert()
        {
            // arrange
            var lembreteMedicamento = new LembreteMedicamentoModel { Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 };

            await Assert.ThrowsAsync<ArgumentException>(async () => await _repository.Insert(lembreteMedicamento));
            Assert.True(_applicationContext.LembreteMedicamentos.Count() == 0);
        }

        [Fact]
        public async Task GetByMedicamentoId_ShouldReturn()
        {
            // arrange
            var medicamentos = new List<MedicamentoModel>
            {
                new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 },
                new MedicamentoModel { Id = 2, AssinaturaId = 1, Descricao = "2", PosicaoNaCaixaRemedio = 2 },
                new MedicamentoModel { Id = 3, AssinaturaId = 1, Descricao = "3", PosicaoNaCaixaRemedio = 3 }
            };

            var lembreteMedicamento = new List<LembreteMedicamentoModel>
            {
                new LembreteMedicamentoModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abcd", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 2 }
            };

            _applicationContext.Medicamentos.AddRange(medicamentos);
            _applicationContext.LembreteMedicamentos.AddRange(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var lembretesMedicamento1 = await _repository.GetByMedicamentoId(1);
            var lembretesMedicamento2 = await _repository.GetByMedicamentoId(2);

            // assert
            Assert.NotNull(lembretesMedicamento1);
            Assert.NotNull(lembretesMedicamento2);
            Assert.Equal(2, lembretesMedicamento1.Count());
            Assert.Single(lembretesMedicamento2);
            Assert.Equal(lembreteMedicamento[0], lembretesMedicamento1[0]);
            Assert.Equal(lembreteMedicamento[1], lembretesMedicamento1[1]);
            Assert.Equal(lembreteMedicamento[2], lembretesMedicamento2[0]);
        }

        [Fact]
        public async Task GetByMedicamentoId_ShouldNotReturn()
        {
            // arrange
            var medicamentos = new List<MedicamentoModel>
            {
                new MedicamentoModel { Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1 },
                new MedicamentoModel { Id = 2, AssinaturaId = 1, Descricao = "2", PosicaoNaCaixaRemedio = 2 },
                new MedicamentoModel { Id = 3, AssinaturaId = 1, Descricao = "3", PosicaoNaCaixaRemedio = 3 }
            };

            var lembreteMedicamento = new List<LembreteMedicamentoModel>
            {
                new LembreteMedicamentoModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
            };

            _applicationContext.Medicamentos.AddRange(medicamentos);
            _applicationContext.LembreteMedicamentos.AddRange(lembreteMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var lembretesMedicamento = await _repository.GetByMedicamentoId(2);

            // assert
            Assert.NotNull(lembretesMedicamento);
            Assert.Empty(lembretesMedicamento);
        }

        [Fact]
        public async Task GetByDevice_ShouldReturn()
        {
            // arrange
            var medicamentos = new List<MedicamentoModel>
            {
                new MedicamentoModel{ Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1},
                new MedicamentoModel{ Id = 2, AssinaturaId = 2, Descricao = "2", PosicaoNaCaixaRemedio = 3},
                new MedicamentoModel{ Id = 3, AssinaturaId = 3, Descricao = "3", PosicaoNaCaixaRemedio = 5}
            };

            var devices = new List<IoTDeviceModel>
            {
                new CaixaRemedioModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira, QuantidadeContainers = 5 },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.CaixaRemedio, QuantidadeContainers = 10 },
            };

            var associacoesMedicamentoDevice = new List<MedicamentoIoTDeviceModel>
            {
                new MedicamentoIoTDeviceModel { Id = 1, MedicamentoId = 1, IoTDeviceId = 1 },
                new MedicamentoIoTDeviceModel { Id = 2, MedicamentoId = 3, IoTDeviceId = 1 },
                new MedicamentoIoTDeviceModel { Id = 3, MedicamentoId = 1, IoTDeviceId = 2 },
            };

            var lembretesDeMedicamento = new List<LembreteMedicamentoModel>
            {
                new LembreteMedicamentoModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 3 }
            };

            _applicationContext.Medicamentos.AddRange(medicamentos);
            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.MedicamentoIoTDevice.AddRange(associacoesMedicamentoDevice);
            _applicationContext.LembreteMedicamentos.AddRange(lembretesDeMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var lembretesDevice1 = await _repository.GetByDevice(devices[0] as CaixaRemedioModel);
            var lembretesDevice2 = await _repository.GetByDevice(devices[1] as CaixaRemedioModel);

            // assert
            Assert.NotNull(lembretesDevice1);
            Assert.NotNull(lembretesDevice2);

            Assert.Equal((devices[0] as CaixaRemedioModel)?.QuantidadeContainers, lembretesDevice1.Count());
            Assert.Equal((devices[1] as CaixaRemedioModel)?.QuantidadeContainers, lembretesDevice2.Count());

            Assert.Equal(2, lembretesDevice1[0].Count());
            Assert.Contains(lembretesDeMedicamento[0], lembretesDevice1[0]);
            Assert.Contains(lembretesDeMedicamento[1], lembretesDevice1[0]);
            Assert.Null(lembretesDevice1[1]);
            Assert.Null(lembretesDevice1[2]);
            Assert.Null(lembretesDevice1[3]);
            Assert.Contains(lembretesDeMedicamento[2], lembretesDevice1[4]);

            Assert.Contains(lembretesDeMedicamento[0], lembretesDevice2[0]);
            Assert.Contains(lembretesDeMedicamento[1], lembretesDevice2[0]);
        }

        [Fact]
        public async Task GetByDevice_ShouldNotReturn()
        {
            // arrange
            var medicamentos = new List<MedicamentoModel>
            {
                new MedicamentoModel{ Id = 1, AssinaturaId = 1, Descricao = "1", PosicaoNaCaixaRemedio = 1},
                new MedicamentoModel{ Id = 2, AssinaturaId = 2, Descricao = "2", PosicaoNaCaixaRemedio = 3},
                new MedicamentoModel{ Id = 3, AssinaturaId = 3, Descricao = "3", PosicaoNaCaixaRemedio = 5}
            };

            var devices = new List<IoTDeviceModel>
            {
                new CaixaRemedioModel { DeviceId = 1, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.Pulseira, QuantidadeContainers = 5 },
                new CaixaRemedioModel { DeviceId = 2, DeviceKey = Guid.NewGuid().ToString(), AssinaturaId = 1, Descricao = "Pulseira", DeviceType = EnumDeviceType.CaixaRemedio, QuantidadeContainers = 10 },
            };

            var associacoesMedicamentoDevice = new List<MedicamentoIoTDeviceModel>
            {
                new MedicamentoIoTDeviceModel { Id = 1, MedicamentoId = 1, IoTDeviceId = 1 },
                new MedicamentoIoTDeviceModel { Id = 2, MedicamentoId = 3, IoTDeviceId = 1 },
            };

            var lembretesDeMedicamento = new List<LembreteMedicamentoModel>
            {
                new LembreteMedicamentoModel{ Id = 1, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 2, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 1 },
                new LembreteMedicamentoModel{ Id = 3, Horario = DateTime.UtcNow, Descricao = "abc", MedicamentoId = 3 }
            };

            _applicationContext.Medicamentos.AddRange(medicamentos);
            _applicationContext.IoTDevices.AddRange(devices);
            _applicationContext.MedicamentoIoTDevice.AddRange(associacoesMedicamentoDevice);
            _applicationContext.LembreteMedicamentos.AddRange(lembretesDeMedicamento);
            await _applicationContext.SaveChangesAsync();

            // act
            var lembretesDevice2 = await _repository.GetByDevice(devices[1] as CaixaRemedioModel);

            // assert
            Assert.NotNull(lembretesDevice2);
            Assert.Equal((devices[1] as CaixaRemedioModel)?.QuantidadeContainers, lembretesDevice2.Count());
            Assert.True(lembretesDevice2.All(l => l == null));
        }
    }
}

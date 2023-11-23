using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using MongoDB.Bson;
using MongoDB.Driver;
using Negocio.Context;
using Negocio.Database;
using Negocio.Enum;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Model.IotMessage;
using Negocio.Repository.Alerta;
using Negocio.Repository.Device;

namespace Functions
{
    public class BigDataProcessingFunction
    {
        private readonly ILogger _logger;
        private readonly ApplicationContext _applicationContext;
        private readonly IotDriver _iotDriver;

        public BigDataProcessingFunction(ILoggerFactory loggerFactory, ApplicationContext applicationContext, IotDriver iotDriver)
        {
            _logger = loggerFactory.CreateLogger<BigDataProcessingFunction>();
            _applicationContext = applicationContext;
            _iotDriver = iotDriver;
        }

        [Function("BigDataProcessingFunction")]
        public async Task Run([TimerTrigger("0 */10 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation("Inicio da execução da função BigDataProcessingFunction.");

            var pulseiraMessageCollection = _iotDriver.GetIoTMessagePulseiraCollection();
            var alertaRepository = new AlertaRepository(_applicationContext);
            var deviceRepository = new DeviceRepository(_applicationContext);

            var filtroDataProcessamento = Builders<StatusPulseiraModel>.Filter.Exists("dataProcessamento", false);
            var mensagensNaoProcessadas = await pulseiraMessageCollection.FindAsync<StatusPulseiraModel>(filtroDataProcessamento);

            while (mensagensNaoProcessadas.MoveNext())
            {
                foreach (var mensagem in mensagensNaoProcessadas.Current)
                {
                    try
                    {
                        if (mensagem.QuedaDetectada)
                        {
                            var usuario = await deviceRepository.GetUsuarioAssociatedWithDevice(mensagem.DeviceId, mensagem.DeviceKey);
                            await alertaRepository.Insert(new AlertaModel() { TipoAlerta = EnumTipoAlerta.Queda, Data = DateTime.Now, IdUsuario = usuario });
                        }
                        // Fazer as outras trativas aqui (colocar em um método, pelo amor de deus)
                    }
                    catch (ArgumentException erro)
                    {
                        LoggerHelper.GeraLogErro(erro);
                    }
                    catch
                    {
                        _logger.LogError("Erro ao processar mensagem de pulseira");
                    }
                    finally
                    {
                        // Falta salvar a data em que a mensagem foi processada, para ela nn repetir denovo
                        var filtroId = Builders<StatusPulseiraModel>.Filter.Eq("_id", new ObjectId(mensagem.Id));
                        var update = Builders<StatusPulseiraModel>.Update.Set("dataProcessamento", DateTime.Now);
                        await pulseiraMessageCollection.UpdateOneAsync(filtroId, update);
                    }
                }
            }
        }
    }
}

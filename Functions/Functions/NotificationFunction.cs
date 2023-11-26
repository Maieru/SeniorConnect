using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Negocio.Database;
using Negocio.Enum;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Repository.Alerta;
using Negocio.Repository.Usuario;

namespace Functions
{
    public class NotificationFunction
    {
        private readonly ILogger _logger;
        private readonly EmailHelper _emailHelper;
        private readonly ApplicationContext _applicationContext;

        public NotificationFunction(ILoggerFactory loggerFactory, EmailHelper emailHelper, ApplicationContext applicationContext)
        {
            _logger = loggerFactory.CreateLogger<NotificationFunction>();
            _emailHelper = emailHelper;
            _applicationContext = applicationContext;
        }

        [Function("NotificationFunction")]
        public async Task Run([TimerTrigger("0 */10 * * * *")] MyInfo myTimer)
        {
            var usuarioRepository = new UsuarioRepository(_applicationContext);
            var alertaRepository = new AlertaRepository(_applicationContext);
            var alertasPendentes = await alertaRepository.GetAll();

            foreach (var alerta in alertasPendentes)
            {
                try
                {
                    var transaction = _applicationContext.Database.BeginTransaction();

                    try
                    {
                        var usuario = await usuarioRepository.GetById(alerta.IdUsuario);
                        await alertaRepository.Delete(alerta.Id);
                        await _emailHelper.EnviaEmail(alerta, usuario);
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }

                }
                catch (Exception erro)
                {
                    await LoggerHelper.GeraLogErro(erro);
                }
            }
        }

        
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
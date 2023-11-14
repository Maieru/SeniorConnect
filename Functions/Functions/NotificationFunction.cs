using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public class NotificationFunction
    {
        private readonly ILogger _logger;

        public NotificationFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<NotificationFunction>();
        }

        [Function("NotificationFunction")]
        public void Run([TimerTrigger("*/10 * * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation("Inicio da execução da função NotificationFunction.");
            
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
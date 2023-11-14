using Microsoft.EntityFrameworkCore.Metadata;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helpers
{
    public static class EmailHelper
    {
        private static string ChaveSendGrid { get; set; }
        private static string Remetente { get; set; }

        public static async Task ConfiguraServico(SecretsHelper secretHelper)
        {
            ChaveSendGrid = await secretHelper.GetSendGridAPIKey();
            Remetente = await secretHelper.GetRemetenteEmail();
        }

        public static async Task EnviaEmail(string assunto, string mensagem, string destinatario, string nomeDestinatario)
        {
            var client = new SendGridClient(ChaveSendGrid);
            var remetente = new EmailAddress(Remetente, "SeniorConnect");
            var emailDestinatario = new EmailAddress(destinatario, nomeDestinatario);
            
            var msg = MailHelper.CreateSingleEmail(remetente, emailDestinatario, assunto, mensagem, mensagem);
            await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}

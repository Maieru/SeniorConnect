using Microsoft.EntityFrameworkCore.Metadata;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Enum;
using Negocio.Model;

namespace Negocio.Helpers
{
    public class EmailHelper
    {
        private string ChaveSendGrid { get; set; }
        private string Remetente { get; set; }

        public EmailHelper(string chaveSendGrid, string remetente)
        {
            ChaveSendGrid = chaveSendGrid;
            Remetente = remetente;
        }

        public async Task<bool> EnviaEmail(AlertaModel alerta, UsuarioModel usuario)
        {
            if (alerta == null)
                throw new ArgumentException("O alerta não pode ser nulo.");

            if (usuario == null)
                throw new ArgumentException("O usuário não pode ser nulo.");

            if (alerta.IdUsuario != usuario.Id)
                throw new ArgumentException("O usuário não é o mesmo do alerta.");

            var client = new SendGridClient(ChaveSendGrid);
            var remetente = new EmailAddress(Remetente, "SeniorConnect");
            var emailDestinatario = new EmailAddress(usuario.Email, usuario.Usuario);
            
            var msg = MailHelper.CreateSingleEmail(remetente, emailDestinatario, MontaAssuntoAlerta(alerta), MontaMensagemAlerta(alerta), MontaMensagemAlerta(alerta));
            var resposta = await client.SendEmailAsync(msg).ConfigureAwait(false);

            return resposta.IsSuccessStatusCode;
        }

        private string MontaAssuntoAlerta(AlertaModel alertaModel)
        {
            switch (alertaModel.TipoAlerta)
            {
                case EnumTipoAlerta.Queda:
                    return "Alerta de Queda";
                case EnumTipoAlerta.IgnorarRemedio:
                    return "Alerta de Remédio Ignorado";
                case EnumTipoAlerta.BotaoEmergencia:
                    return "Alerta de Botão de Emergência";
                case EnumTipoAlerta.AumentoBatimentosCardiacos:
                    return "Alerta de Aumento de Batimentos Cardíacos";
                default:
                    throw new ArgumentException("O tipo de alerta não era válido");
            }
        }

        private string MontaMensagemAlerta(AlertaModel alertaModel)
        {
            switch (alertaModel.TipoAlerta)
            {
                case EnumTipoAlerta.Queda:
                    return "O idoso sofreu uma queda. Verifique a sua situação e tome as ações necessárias.";
                case EnumTipoAlerta.IgnorarRemedio:
                    return "O idoso ignorou o alerta para tomar o remédio.";
                case EnumTipoAlerta.BotaoEmergencia:
                    return "O idoso apertou o botão de emergência. Verifique a sua situação e tome as ações necessárias.";
                case EnumTipoAlerta.AumentoBatimentosCardiacos:
                    return "Foi detectado um aumento nos batimentos cardiacos do idoso. Verifique a sua situação e tome as ações necessárias.";
                default:
                    throw new ArgumentException("O tipo de alerta não era válido");
            }
        }
    }
}

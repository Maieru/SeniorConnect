using Negocio.Database;
using Negocio.Enum;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Repository.Alerta;
using Negocio.Repository.Usuario;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Reflection;
using System.Reflection.Emit;

namespace Negocio.Test.Helpers
{
    public class EmailHelperTest
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData(1, null)]
        [InlineData(null, 1)]
        [InlineData(1, 2)]
        public async Task EnviaEmail_InvalidAlertaOrUsuario_ThrowsArgumentException(int? idUsuarioAlerta, int? idUsuarioUsuario)
        {
            // Arrange
            var emailHelper = new EmailHelper("", "");

            var alerta = idUsuarioAlerta.HasValue ? new AlertaModel() { IdUsuario = idUsuarioAlerta.Value } : null;
            var usuario = idUsuarioUsuario.HasValue ? new UsuarioModel() { Id = idUsuarioUsuario.Value } : null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => emailHelper.EnviaEmail(alerta, usuario));
        }

        [Theory]
        [InlineData(EnumTipoAlerta.Queda, "Alerta de Queda")]
        [InlineData(EnumTipoAlerta.IgnorarRemedio, "Alerta de Remédio Ignorado")]
        [InlineData(EnumTipoAlerta.BotaoEmergencia, "Alerta de Botão de Emergência")]
        [InlineData(EnumTipoAlerta.AumentoBatimentosCardiacos, "Alerta de Aumento de Batimentos Cardíacos")]
        public async Task MontaAssuntoAlerta_ValidAlerta_ReturnsString(EnumTipoAlerta tipoAlerta, string resultadoEsperado)
        {
            // Arrange
            var tipoHelper = typeof(EmailHelper);
            var emailHelper = Activator.CreateInstance(tipoHelper, "", "");
            var montaAssuntoAlerta = tipoHelper.GetMethod("MontaAssuntoAlerta", BindingFlags.NonPublic | BindingFlags.Instance);

            var alerta = new AlertaModel() { TipoAlerta = tipoAlerta };
            
            // Act
            var result = montaAssuntoAlerta.Invoke(emailHelper, new object[] { alerta });

            // Assert
            Assert.Equal(resultadoEsperado, result);
        }

        [Theory]
        [InlineData(EnumTipoAlerta.Queda, "O idoso sofreu uma queda. Verifique a sua situação e tome as ações necessárias.")]
        [InlineData(EnumTipoAlerta.IgnorarRemedio, "O idoso ignorou o alerta para tomar o remédio.")]
        [InlineData(EnumTipoAlerta.BotaoEmergencia, "O idoso apertou o botão de emergência. Verifique a sua situação e tome as ações necessárias.")]
        [InlineData(EnumTipoAlerta.AumentoBatimentosCardiacos, "Foi detectado um aumento nos batimentos cardiacos do idoso. Verifique a sua situação e tome as ações necessárias.")]
        public async Task MontaMensagemAlerta_ValidAlerta_ReturnsString(EnumTipoAlerta tipoAlerta, string resultadoEsperado)
        {
            // Arrange
            var tipoHelper = typeof(EmailHelper);
            var emailHelper = Activator.CreateInstance(tipoHelper, "", "");
            var montaAssuntoAlerta = tipoHelper.GetMethod("MontaMensagemAlerta", BindingFlags.NonPublic | BindingFlags.Instance);

            var alerta = new AlertaModel() { TipoAlerta = tipoAlerta };

            // Act
            var result = montaAssuntoAlerta.Invoke(emailHelper, new object[] { alerta });

            // Assert
            Assert.Equal(resultadoEsperado, result);
        }
    }
}
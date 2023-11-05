using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.TOs.Configuration
{
    public record class JwtConfigurationOptions
    (
        string Issuer,
        string Audience,
        string SigningKey,
        int ExpirationSeconds
    );
}

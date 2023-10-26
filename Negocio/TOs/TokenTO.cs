using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.TOs
{
    public class TokenTO
    {
        public string Token { get; set; }
        public string Type { get; set; }
        public int Expiration { get; set; }
    }
}

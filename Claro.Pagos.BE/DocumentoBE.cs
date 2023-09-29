using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.BE
{
    public class DocumentoBE
    {
        public string cliente { get; set; }
        public decimal importe { get; set; }
        public decimal saldo { get; set; }
        public string tipoComprobante { get; set; }

        [JsonProperty("fecha")]
        public DateTime fecha { get; set; }
    }
}

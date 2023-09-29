using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.BE
{
    public class TipoPagoBE
    {
        public int Id { get; set; }
        public string formaPago { get; set; }
        public string numeroDocumento { get; set; }
        public decimal montoPagado { get; set; }
        public int pagoID { get; set; }
    }
}

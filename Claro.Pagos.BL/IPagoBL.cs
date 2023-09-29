using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.BL
{
    public interface IPagoBL
    {
        bool Insertar(PagoBE entity, List<TipoPagoBE> listTipoPago);
    }
}

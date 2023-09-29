using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.DAC
{
    public interface ITipoPagoDAC
    {
        bool Insertar(TipoPagoBE entity);
    }
}

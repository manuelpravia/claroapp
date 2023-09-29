using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.DAC
{
    public interface IPagoDAC
    {
        int Insertar(PagoBE entity);
        List<PagoBE> Listar(PagoBE entity);
        bool Delete(int id);
        PagoBE Get(int id);
        bool Update(PagoBE entity);
    }
}

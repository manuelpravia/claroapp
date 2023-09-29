using Claro.Pagos.BE;
using Claro.Pagos.DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.BL
{
    public class PagoBL : IPagoBL
    {
        private readonly IPagoDAC _ipagoDAC;
        private readonly ITipoPagoDAC _iTipopacoDAC;

        public PagoBL(PagoDAC pago,TipoPagoDAC tipo)
        {
            // _ipagoDAC = new PagoDAC();
            //_iTipopacoDAC = new TipoPagoDAC();
            _ipagoDAC = pago;
            _iTipopacoDAC = tipo;
        }

        public bool Insertar(PagoBE entity, List<TipoPagoBE> listTipoPago)
        {
            //PagoDAC _ipagoDAC = new PagoDAC();
            //TipoPagoDAC _iTipopacoDAC = new TipoPagoDAC();
            var status = false;
            var idpago = _ipagoDAC.Insertar(entity);

            if (idpago > 0)
            {
                foreach (TipoPagoBE item in listTipoPago)
                {
                    item.pagoID = idpago;
                    _iTipopacoDAC.Insertar(item);
                    status = true;
                }
            }
            return status;
        }
    }
}

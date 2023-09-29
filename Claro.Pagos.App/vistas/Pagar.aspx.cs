using Claro.Pagos.BE;
using Claro.Pagos.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Claro.Pagos.App.vistas
{
    public partial class Pagar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<DocumentoBE> documentosSeleccionados = Session["DocumentosSeleccionados"] as List<DocumentoBE>;
                DocumentoBE documentoBE = documentosSeleccionados[0];


                inputCliente.Text = documentoBE.cliente;
                inputImporte.Text = Convert.ToString(documentoBE.importe);
                inputSaldo.Text = Convert.ToString(documentoBE.saldo);
                inputComprobante.Text = documentoBE.tipoComprobante;
                inputFecha.Text = Convert.ToString(documentoBE.fecha);

                cargarComboFormaPago();
            }
        }

        public void cargarComboFormaPago()
        {

            ddlFormaPago1.Items.Add(new ListItem("--Seleccionar--", ""));
            ddlFormaPago1.Items.Add(new ListItem("EFECTIVO", "EFECTIVO"));
            ddlFormaPago1.Items.Add(new ListItem("TARJETA", "TARJETA"));

            ddlFormaPago2.Items.Add(new ListItem("--Seleccionar--", ""));
            ddlFormaPago2.Items.Add(new ListItem("EFECTIVO", "EFECTIVO"));
            ddlFormaPago2.Items.Add(new ListItem("TARJETA", "TARJETA"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string numTarjeta1 = TextNumTarjeta1.Text;
            string numMonto1 = TextMonto1.Text;
            string formaPago1 = ddlFormaPago1.SelectedValue;

            string numTarjeta2 = TextNumTarjeta2.Text;
            string numMonto2 = TextMonto2.Text;
            string formaPago2 = ddlFormaPago2.SelectedValue;
            List<TipoPagoBE> listaTipoPago = new List<TipoPagoBE>();

            if (numTarjeta1 != "" && numMonto1 != "" && formaPago1 != "")
            {
                TipoPagoBE tipoPago1 = new TipoPagoBE();
                tipoPago1.formaPago = formaPago1;
                tipoPago1.numeroDocumento = numTarjeta1;
                tipoPago1.montoPagado = Convert.ToDecimal(numMonto1);
                listaTipoPago.Add(tipoPago1);
            }

            if (numTarjeta2 != "" && numMonto2 != "" && formaPago2 != "")
            {
                TipoPagoBE tipoPago2 = new TipoPagoBE();
                tipoPago2.formaPago = formaPago2;
                tipoPago2.numeroDocumento = numTarjeta2;
                tipoPago2.montoPagado = Convert.ToDecimal(numMonto2);
                listaTipoPago.Add(tipoPago2);
            }
            List<DocumentoBE> documentosSeleccionados = Session["DocumentosSeleccionados"] as List<DocumentoBE>;
            DocumentoBE documentoBE = documentosSeleccionados[0];
            
            PagoBE pagoBE = new PagoBE();
            pagoBE.cliente = documentoBE.cliente;
            pagoBE.saldo = documentoBE.saldo;
            pagoBE.tipoComprobante = documentoBE.tipoComprobante;
            pagoBE.fecha = documentoBE.fecha;
            pagoBE.importe = documentoBE.importe;

            PagoBL pagoBL = new PagoBL();
           bool procesoExitoso = pagoBL.Insertar(pagoBE, listaTipoPago);

            Response.Redirect("listapagos.aspx");


        }


        }
}
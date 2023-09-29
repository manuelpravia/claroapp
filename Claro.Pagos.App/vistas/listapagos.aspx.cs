using Claro.Pagos.BE;
using Claro.Pagos.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace Claro.Pagos.App.vistas
{
    public partial class listapagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DocumentoBE documento = new DocumentoBE();
                documento.cliente = "";
                documento.importe = 0;
                documento.saldo = 0;
                documento.tipoComprobante = "";
                documento.fecha = DateTime.Now;
                this.Listardocumentos();
                //this.ListarDocumentosMock(documento);
            }

        }


        public void Listardocumentos()
        {
            this.hfDelete.Value = "0";

            DocumentoBL documentoBL = new DocumentoBL();
            List<DocumentoBE> list = documentoBL.ListarDocumentos();

            this.gvDocumentos.DataSource = list;
            this.gvDocumentos.DataBind();

            ScriptManager.RegisterStartupScript(this, Page.GetType(), "myLoadingHide", "$('#divLoading').hide();", true);
        }

        //public  void ListarDocumentosMock(DocumentoBE entity)
        //{
        //    this.hfDelete.Value = "0";

        //    DocumentoBL documentoBL = new DocumentoBL();
        //    List<DocumentoBE> list = documentoBL.ListarDocumentosMock(entity);

        //    this.gvDocumentos.DataSource = list;
        //    this.gvDocumentos.DataBind();

        //    ScriptManager.RegisterStartupScript(this, Page.GetType(), "myLoadingHide", "$('#divLoading').hide();", true);
        //}

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            List<DocumentoBE> datosSeleccionados = new List<DocumentoBE>();


            foreach (GridViewRow row in gvDocumentos.Rows)
            {
                CheckBox chkSeleccionar = (CheckBox)row.FindControl("chkSeleccionar");

                if (chkSeleccionar.Checked)
                {
                    // Supongamos que quieres capturar el valor de una celda específica, por ejemplo, la primera celda (índice 0)
                    string cliente = ((Label)row.FindControl("lblId2")).Text;
                    decimal importe = Convert.ToDecimal(((Label)row.FindControl("lblImporte2")).Text);
                    decimal saldo = Convert.ToDecimal(((Label)row.FindControl("lblSaldo2")).Text);
                    string tipoComprobante = ((Label)row.FindControl("lblTipoComprobante2")).Text;
                    DateTime fecha = Convert.ToDateTime(((Label)row.FindControl("lblFecha2")).Text);
                    DocumentoBE documento = new DocumentoBE
                    {
                        cliente = cliente,
                        importe = importe,
                        saldo = saldo,
                        tipoComprobante = tipoComprobante,
                        fecha = fecha
                    };
                    datosSeleccionados.Add(documento);
                }
            }

            Session["DocumentosSeleccionados"] = datosSeleccionados;

            Response.Redirect("pagar.aspx");
        }


    }
}
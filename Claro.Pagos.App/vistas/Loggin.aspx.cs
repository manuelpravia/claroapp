using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Claro.Pagos.App.vistas
{
    public partial class Loggin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Oficina oficina = new Oficina();
                oficina.Name = "";
                this.cargarComboOficinas(oficina);
            }

        }
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string oficina = ddlOficinas.SelectedValue;

            if (oficina == "CAC BEGONAS"||oficina == "CAC RIPLEY" || oficina == "CAC METRO")
            {
                Response.Redirect("listapagos.aspx");
            }
        }

        public void cargarComboOficinas(Oficina oficina)
        {
           // NacionalidadBL nacionalidadBL = new NacionalidadBL();
           // List<Nacionalidad> nacionalidades = nacionalidadBL.ListarIdentity(nacionalidadBE);
            List<Oficina> lista = new List<Oficina>();
            Oficina oficina1 = new Oficina();
            oficina1.Id = 1;
            oficina1.Name = "CAC BEGONAS";
            lista.Add(oficina1);

            Oficina oficina2 = new Oficina();
            oficina2.Id = 2;
            oficina2.Name = "CAC RIPLEY";
            lista.Add(oficina2 );

            Oficina oficina3 = new Oficina();
            oficina3.Id = 3;
            oficina3.Name = "CAC METRO";
            lista.Add(oficina3);

            ddlOficinas.Items.Add(new ListItem("--Seleccionar--", ""));
            foreach (var item in lista)
            {
                //ddlOficinas.Items.Add(new ListItem(item.Name, Convert.ToString(item.Id)));
                ddlOficinas.Items.Add(new ListItem(item.Name, item.Name));
            }
        }

    }
}
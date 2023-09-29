<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Loggin.aspx.cs" Inherits="Claro.Pagos.App.vistas.Loggin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfDelete" runat="server" Value="0" />
        
    <div class="container" style="margin-top:90px; margin-left: 350px">
        <div class="card text-bg-secondary mb-3" style="max-width: 26rem;">
          <div class="card-header">SOLUCION DE CAJAS Y RECAUDACION</div>
          <div class="card-body">
            <div class="col-12">
                 <div class="mb-1">
                     <asp:Label ID="lbOficinas" runat="server" CssClass="form-label" Text="Oficinas: "></asp:Label>
                     <asp:DropDownList ID="ddlOficinas" runat="server" CssClass="form-select">
                     </asp:DropDownList>
                 </div>
             </div>
             <div>
                 <asp:Button ID="btnIniciarSesion" runat="server" Text="Ingresar" OnClientClick="return ValidarCampos();" OnClick="btnIniciarSesion_Click" CssClass="btn btn-primary" />
             </div>
          </div>
        </div>
        </div>

</asp:Content>

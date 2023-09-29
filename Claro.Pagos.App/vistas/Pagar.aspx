<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="Claro.Pagos.App.vistas.Pagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hfDelete" runat="server" Value="0" />

    <div class="container text-center" style="margin-top:70px; margin-left:200px">
        <div class="row align-items-cente col-8">
            <form>
                <div class="col-6">
                  <div class="row mb-3">
                    <label for="inputCliente" class="col-sm-2 col-form-label">Cliente</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="inputCliente" runat="server" CssClass="form-control" disabled></asp:TextBox>
                    </div>
                  </div>
                    <div class="row mb-3">
                      <label for="inputImporte" class="col-sm-2 col-form-label">Importe</label>
                      <div class="col-sm-10">
                          <asp:TextBox ID="inputImporte" runat="server" CssClass="form-control" disabled></asp:TextBox>
                      </div>
                    </div>
                    <div class="row mb-3">
                      <label for="inputSaldo" class="col-sm-2 col-form-label">Saldo</label>
                      <div class="col-sm-10">
                          <asp:TextBox ID="inputSaldo" runat="server" CssClass="form-control" disabled></asp:TextBox>
                      </div>
                    </div>
                  </div>
                <div class="col-6">
                    <div class="row mb-3">
                      <label for="inputComprobante" class="col-sm-2 col-form-label">Tipo</label>
                      <div class="col-sm-10">
                          <asp:TextBox ID="inputComprobante" runat="server" CssClass="form-control" disabled></asp:TextBox>
                      </div>
                    </div>
                    <div class="row mb-3">
                      <label for="inputFecha" class="col-sm-2 col-form-label">fecha</label>
                      <div class="col-sm-10">
                          <asp:TextBox ID="inputFecha" runat="server" CssClass="form-control" disabled></asp:TextBox>
                      </div>
                    </div>
                </div>
                <div class="col-12">
                    <table class="table">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">Forma de Pago</th>
                          <th scope="col">Nro. Tarjeta/Documento</th>
                          <th scope="col">Monto a pagar</th>
                        </tr>
                      </thead>
                      <tbody class="table-group-divider">
                        <tr>
                          <th scope="row">1</th>
                          <td>
                              <asp:DropDownList ID="ddlFormaPago1" runat="server" CssClass="form-select"></asp:DropDownList>
                          </td>
                          <td>
                              <asp:TextBox ID="TextNumTarjeta1" runat="server" CssClass="form-control" pattern="^\d{8}$|^\d{16}$" title="Debe ingresar 8 dígitos si es DNI 16 dígitos si es TARJETA" ></asp:TextBox>
                          </td>
                          <td>
                              <asp:TextBox ID="TextMonto1" type="number" runat="server" CssClass="form-control" ></asp:TextBox>
                          </td>
                        </tr>
                        <tr>
                          <th scope="row">2</th>
                          <td>
                              <asp:DropDownList ID="ddlFormaPago2" runat="server" CssClass="form-select"></asp:DropDownList>
                          </td>
                          <td><asp:TextBox ID="TextNumTarjeta2" runat="server" CssClass="form-control" pattern="^\d{8}$|^\d{16}$" title="Debe ingresar 8 dígitos si es DNI 16 dígitos si es TARJETA"  ></asp:TextBox></td>
                          <td><asp:TextBox ID="TextMonto2" type="number" runat="server" CssClass="form-control" ></asp:TextBox></td>
                        </tr>
                      </tbody>
                    </table>
                </div>
              <asp:Button ID="btnGuardar" runat="server" class="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click"  OnClientClick="return validarDatos();"/>
              <%--<button type="submit" class="btn btn-primary">Guardar</button>--%>
            </form>

        </div>
    </div>

        <script type="text/javascript">

            function validarDatos() {
                var estado = false;

                var formaPago1 = $("tbody tr:first").find(".form-select").val();
                var numTarjeta1 = $("tbody tr:first").find(".form-control").eq(0).val();
                var monto1 = $("tbody tr:first").find(".form-control").eq(1).val();

                var formaPago2 = $("tbody tr:nth-child(2)").find(".form-select").val();
                var numTarjeta2 = $("tbody tr:nth-child(2)").find(".form-control").eq(0).val();
                var monto2 = $("tbody tr:nth-child(2)").find(".form-control").eq(1).val();

                if ((formaPago1 != "" && numTarjeta1 != "" && monto1 != "") && (formaPago2 != "" && numTarjeta2 != "" && monto2 != "")) {

                    estado = true;
                }

                if ((formaPago1 != "" && numTarjeta1 != "" && monto1 != "") && (formaPago2 == "" && numTarjeta2 == "" && monto2 == "")) {
                    estado = true;
                }


                if (!estado) {
                    alert("Por favor completar los datos");
                }

                return estado;
            }


        </script>

</asp:Content>

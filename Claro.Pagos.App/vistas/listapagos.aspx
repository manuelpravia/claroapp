<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="listapagos.aspx.cs" Inherits="Claro.Pagos.App.vistas.listapagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <%--<script type="text/javascript" src="../js/validacion.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfDelete" runat="server" Value="0" />



    <h1 style =" color:red; text-align:center">Pool de documentos por pagar</h1>

    <div class = "container ">

        <div class="row">
            <div class="row mt-4">
                <div class="row" style = "margin-bottom:10px; ">
                    <div class="col-6">
                        <input type="text" id="txtBusqueda" class="form-control" placeholder="Ingrese término de búsqueda">
                    </div>
                    <div class="col-6">
                        <button id="btnBuscar" type="button" class="btn btn-success">Buscar</button>
                    </div>
                </div>

                <asp:GridView ID="gvDocumentos" runat="server" CssClass="table table-striped" AllowPaging="true"  AutoGenerateColumns="false" AutoGenerateSelectButton="True"  >

                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="col-md-1">
                            <HeaderTemplate>
                                <asp:Label runat="server" ID="lblSeleccionar" Text="Opcion"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkSeleccionar"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label runat="server" ID="lblId" Text="Cliente"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId2" Text='<%# Eval("cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label runat="server" ID="lblImporte" Text="Importe"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblImporte2" Text='<%# Eval("importe") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label runat="server" ID="lblSaldo" Text="Saldo"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSaldo2" Text='<%# Eval("saldo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label runat="server" ID="lblTipoComprobante" Text="Tipo"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTipoComprobante2" Text='<%# Eval("tipocomprobante") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label runat="server" ID="lblFecha" Text="Fecha"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblFecha2" Text='<%# Eval("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    </asp:GridView>
                    <asp:Button ID="btnPagar" class="btn btn-info" runat="server" Text="Pagar" OnClick="btnPagar_Click"  OnClientClick="return validarSeleccion();"/>
            </div>

        </div>

    </div>

            <script type="text/javascript">

                $(document).ready(function () {
                    // Buscar todos los elementos de CheckBox dentro del GridView
                    var checkboxes = $("#<%= gvDocumentos.ClientID %> input[type='checkbox']");

                checkboxes.click(function () {
                    // Desmarcar todas las casillas de verificación
                    checkboxes.prop("checked", false);

                    // Marcar solo la casilla de verificación de la fila actual
                    $(this).prop("checked", true);
                });


                //$("#btnBuscar").click(function (e) {

                //    e.preventDefault();

                //    var terminoBusqueda = $("#txtBusqueda").val().toLowerCase();

                //    $("#gvDocumentos tr:gt(0)").each(function () {
                //        var fila = $(this);
                //        var cliente = fila.find("td:nth-child(2)").text().toLowerCase();
                //        var importe = fila.find("td:nth-child(3)").text().toLowerCase(); 

                //        if (cliente.indexOf(terminoBusqueda) !== -1 || importe.indexOf(terminoBusqueda) !== -1) {
                //            fila.show();
                //        } else {
                //            fila.hide();
                //        }
                //    });
                //});


                $("#txtBusqueda").on("input", function () {
                    var terminoBusqueda = $(this).val().toLowerCase();

                    // Recorre las filas del GridView y muestra/oculta según el término de búsqueda
                    $("#gvDocumentos tr:gt(0)").each(function () {
                        var fila = $(this);
                        var cliente = fila.find("td:nth-child(2)").text().toLowerCase(); // Cambia el índice según la columna que deseas buscar

                        // Verifica si el término de búsqueda se encuentra en la fila
                        if (cliente.indexOf(terminoBusqueda) !== -1) {
                            fila.show();
                        } else {
                            fila.hide();
                        }
                    });
                });


            });


            function validarSeleccion() {

                var checkboxes = $("#<%= gvDocumentos.ClientID %> input[type='checkbox']");

                    var alMenosUnoSeleccionado = false;

                    checkboxes.each(function () {
                        if ($(this).is(":checked")) {
                            alMenosUnoSeleccionado = true;
                            return false;
                        }
                    });

                    if (alMenosUnoSeleccionado) {

                        return true;
                    } else {

                        alert("Selecciona al menos una fila.");
                        return false;
                    }

                }
            </script>
    
</asp:Content>







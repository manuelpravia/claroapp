
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



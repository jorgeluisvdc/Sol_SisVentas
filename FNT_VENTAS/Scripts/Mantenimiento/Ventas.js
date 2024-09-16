function StockPrecioUnitario() {
    var RutaUrl = $("#Id_HdStockPrecioUnitario").val();
    var codigo = $("#Seleccionar_ddlStockProducto").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    //////ajustarBloqueoDePagina();

    var oProd = {};
    oProd.IdProducto = codigo;

    $.ajax({
        url: RutaUrl,
        data: {
            oStock: oProd
        },
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divLoadingMensaje").hide();
            $("#divLoading").hide();

            $("#txtPrecioUnitario").val(data);
            $("#txtCantidad").val("");
            $("#txtTotal").val("");
        },
        error: function (req, status, error) {
        }
    });
}

function AgregarProducto() {
    var RutaUrl = $("#Id_HdAgregarProducto").val();

    var codigo_producto = $('#Seleccionar_ddlStockProducto').val();
    var producto = $('#Seleccionar_ddlStockProducto option:selected').text();
    var precio_unitario = $("#txtPrecioUnitario").val();
    var cantidad = $("#txtCantidad").val();
    var total = $("#txtTotal").val();

    var subtotal = total / 1.18;
    var igv = total - subtotal;
    debugger;    

    var oDet = {};
    oDet.IdProducto = codigo_producto;
    //oDet.precio_unitario = precio_unitario;
    oDet.Cantidad = cantidad;
    oDet.TotalProducto = total;
    oDet.SubTotal = subtotal;
    //oDet.IdProducto = codigo_producto;
    //oDet.IdProducto = codigo_producto;

    $.ajax({
        url: RutaUrl,
        data: {
            oDetalle: oDet
        },
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            //$("#divLoadingMensaje").hide();
            //$("#divLoading").hide();

            $("#lblTotalComprobante").html('Total S/ ' + data);
            $("#lblTotalComprobantePie").html('Total S/ ' + data);

            var table = $('#TablaDetalle').DataTable();
            table.row.add([
                      codigo_producto,
                      producto,
                      parseFloat(precio_unitario).toFixed(2),
                      parseFloat(cantidad).toFixed(2),
                      parseFloat(igv).toFixed(2),
                      parseFloat(subtotal).toFixed(2),
                      parseFloat(total).toFixed(2),
                      '<button type="button" class="btn btn-danger delete">'
                      + '    <span class="fa fa-trash"></span>'
                      + '</button>',
            ]).draw(false);

            $("#Seleccionar_ddlStockProducto").val($("#Seleccionar_ddlStockProducto option:first").val());
            $('.selectpicker').selectpicker('refresh');

            $("#txtPrecioUnitario").val("");
            $("#txtCantidad").val("");
            $("#txtTotal").val("");
        },
        error: function (req, status, error) {
        }
    });

    
}

function EliminarProducto(idProducto)
{
    
    var RutaUrl = $("#Id_HdEliminarProducto").val();

    debugger;

    $.ajax({
        url: RutaUrl,
        data: {
            id: idProducto
        },
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            //$("#divLoadingMensaje").hide();
            //$("#divLoading").hide();
            debugger;
            $("#lblTotalComprobante").html('Total S/ ' + data);
            $("#lblTotalComprobantePie").html('Total S/ ' + data);
        },
        error: function (req, status, error) {
        }
    });


}
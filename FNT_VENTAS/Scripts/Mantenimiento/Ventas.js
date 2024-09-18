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

    var oMensaje = '';

    if (codigo_producto <= 0)
    {
        oMensaje = 'Debe seleccionar un producto';
    }
    else if (cantidad <= 0) {
        oMensaje = 'Debe ingresar una cantidad valida';
    }

    if (oMensaje != '')
    {
        Swal.fire({
            title: oMensaje,
            showLoaderOnConfirm: true,
            confirmButtonText: 'Aceptar',
            icon: 'error',
        }).then((result) => { });
        return false;
    }

    var oDet = {};
    oDet.IdProducto = codigo_producto;
    //oDet.precio_unitario = precio_unitario;
    oDet.Cantidad = cantidad;
    oDet.SubTotal = subtotal;
    oDet.IgvDet = igv;
    oDet.TotalProducto = total;
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

            debugger;
            var nFilas = table.rows().count();

            if (nFilas > 0)
            {
                for (var i = 0; i < nFilas; i++)
                {
                    var codigoTabla = table.data()[i][0];
                    if (table.data()[i][0] == codigo_producto)
                    {
                        $('#TablaDetalle').DataTable().row(i).remove().draw(); // se elimina una fila
                        break;
                    }
                }
            }

            table.row.add([
                      codigo_producto,
                      producto,
                      parseFloat(precio_unitario).toFixed(2),
                      parseInt(cantidad),
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

function GrabarVenta() {
    
    Swal.fire({
        title: '¿Desea registrar el comprobante actual?',
        showLoaderOnConfirm: true,
        confirmButtonText: 'Aceptar',
        showCancelButton: true,
        icon: 'success',
    }).then((result) =>
    {
        if (result.isConfirmed)
        {
            var ParamUrl = $("#Id_HdGrabarVenta").val();
            debugger;

            var tipo_doc = $("#Seleccionar_ddlTipoComprobante").val();
            //var nro_doc = $("#txtNroComprobante").val();
            var cliente = $("#Seleccionar_ddlCliente").val();
            var tipo_pago = $("#Seleccionar_ddlTipoPago").val();
            
            $("#divLoadingMensaje").show();
            $("#divLoading").show();
            //////////ajustarBloqueoDePagina();

            var oComp = {};
            oComp.idTipoComprobante = tipo_doc;
            //oComp.nroComprobante = nro_doc;
            oComp.IdCliente = cliente;
            oComp.idTipoPago = tipo_pago;

            $.ajax({
                url: ParamUrl,
                data: {
                    oComprobante: oComp
                },
                type: "post",
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#divLoadingMensaje").hide();
                    $("#divLoading").hide();
                    debugger;

                    if (data.indexOf("Modal_Vnt") == -1) {
                    }
                    else {
                        if (data.indexOf("Modal_Vnt_OK") == -1) {
                            $("#ModalRespuestaMsg").html(data);
                        }
                        else {

                            Swal.fire({
                                title: 'El comprobante ha sido registrado correctamente!',
                                showLoaderOnConfirm: true,
                                confirmButtonText: 'Aceptar',
                                icon: 'success',
                            }).then((result) => { window.location.href = "/Ventas"; });

                            //$("#Div_Informacion").html("");
                            //$("#Div_Confirmacion").html("");
                            
                        }
                    }
                },
                error: function (req, status, error) {
                }
            });

            

        }
        else //if (result.isDenied)
        {
            debugger;
            return false;
        }

    });
}


function BuscarVentas() {
    var ParamUrl = $("#Id_HdBuscarVentas").val();
    debugger;

    var fecha_ini = $("#txtFechaIni").val();
    var fecha_fin = $("#txtFechaFin").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    //////////ajustarBloqueoDePagina();

    var oBusca = {};
    oBusca.FechaIni = fecha_ini;
    oBusca.FechaFin = fecha_fin;
    
    $.ajax({
        url: ParamUrl,
        data: {
            oBusca: oBusca
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divLoadingMensaje").hide();
            $("#divLoading").hide();
            debugger;

            if (data.indexOf("Modal_Vnt") == -1) {
                $("#Div_Registros").html(data);
            }
            else {
                if (data.indexOf("Modal_Vnt_OK") == -1) {
                    $("#ModalRespuestaMsg").html(data);
                }
                else {
                    //$("#Div_Registros").html("");
                    //$("#Div_Confirmacion").html("");
                }
            }
        },
        error: function (req, status, error) {
        }
    });

}
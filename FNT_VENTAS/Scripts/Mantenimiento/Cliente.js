function Consulta_Cliente() {
    var RutaUrl = $("#Id_HdConsulta_Cliente").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    //////////ajustarBloqueoDePagina();
    $("#Div_Informacion").html("");
    $("#Div_Confirmacion").html("");
    $("#Div_Registros").html("");
    $("#btnRegistrar").hide();
    $("#btnActualizar").hide();
    $("#btnNuevo").hide();

    $.ajax({
        url: RutaUrl,
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divLoadingMensaje").hide();
            $("#divLoading").hide();

            if (data.indexOf("Modal_Vnt") == -1) {
                $("#Div_Registros").html(data);
                $('html, body').animate({ scrollTop: $("#Div_Informacion").offset().top }, 800);
                $("#btnNuevo").show();
            }
            else {
                $("#ModalRespuestaMsg").html(data);
            }
        },
        error: function (req, status, error) {
        }
    });
}

function EditarCliente(oConsulta) {
    var RutaUrl = $("#Id_HdEditarCliente").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    //////////ajustarBloqueoDePagina();
    $("#Div_Informacion").html("");
    $("#Div_Confirmacion").html("");
    $("#btnRegistrar").hide();
    $("#btnActualizar").hide();
    $("#btnNuevo").hide();

    oConsulta.VerEditar = 2;
    $.ajax({
        url: RutaUrl,
        data: {
            oCliente: oConsulta
        },
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divLoadingMensaje").hide();
            $("#divLoading").hide();

            if (data.indexOf("Modal_Vnt") == -1) {
                $("#Div_Informacion").html(data);
                $('html, body').animate({ scrollTop: $("#Div_Informacion").offset().top }, 800);
            }
            else {
                $("#ModalRespuestaMsg").html(data);
            }
        },
        error: function (req, status, error) {
        }
    });
}

function EditarClienteCancelar() {
    $("#Div_Informacion").html("");
    $("#Div_Confirmacion").html("");
    $("#btnActualizar").hide();
    $("#btnNuevo").show();
}

function ValidaBtnActualizar_Cliente() {
    $("#btnActualizar").show();
    $("#Div_Confirmacion").html("");
}

function ConfirmaActualizar_Cliente() {
    $("#btnActualizar").hide();

    var vntConfirma = '';
    vntConfirma = vntConfirma + '<div class="row"><div class="col-md-12"><hr /></div></div>';
    vntConfirma = vntConfirma + '<div class="row"><div class="col-md-6 form-label zizou-regular text-primary">Se actualizarán los datos del cliente actual.</div></div>';
    vntConfirma = vntConfirma + '<div class="row"><div class="col-md-4 form-label zizou-regular">¿Desea continuar?</div></div>';
    vntConfirma = vntConfirma + '<div class="row">';
    vntConfirma = vntConfirma + '<div class="col-md-2"><input type="button" class="btn btn-primary btn-sm" id="" value="Aceptar" onclick="Actualizar_Cliente();" /></div>';
    vntConfirma = vntConfirma + '<div class="col-md-3"><input type="button" class="btn btn-primary btn-sm" id="" value="Cancelar" onclick="CancelarActualizar_Cliente();" /></div>';
    vntConfirma = vntConfirma + '</div>';

    $("#Div_Confirmacion").html(vntConfirma);

    $('html, body').animate({ scrollTop: $("#Div_Confirmacion").offset().top }, 800);
}

function Actualizar_Cliente() {
    var RutaUrl = $("#Id_HdActualizar_Cliente").val();

    var codigo_cli = $("#txtIdCliente").val();
    var codigo_per = $("#Id_HdIdPersona").val();
    var nombre = $("#txtNombre").val();
    var ape_pat = $("#txtApePaterno").val();
    var ape_mat = $("#txtApeMaterno").val();
    var tipo_doc = $("#Seleccionar_ddlTipoDocumento").val();
    var nro_doc = $("#txtNroDocumento").val();
    var direccion = $("#txtDireccion").val();
    var telefono = $("#txtTelefono").val();
    var observacion = $("#txtClienteObservacion").val();
    var estado = $("#Seleccionar_ddlEstado").val();

    if (nombre == "" || estado == "") {
        Swal.fire({
            title: 'Debe ingresar descripción y estado',
            showLoaderOnConfirm: true,
            confirmButtonText: 'Aceptar',
            icon: 'error',
        }).then((result) => { });

    }
    else {
        $("#divLoadingMensaje").show();
        $("#divLoading").show();
        //////////ajustarBloqueoDePagina();

        var oActualiza = {};
        oActualiza.IdCliente = codigo_cli;
        oActualiza.IdPersona = codigo_per;
        oActualiza.Nombre = nombre.toUpperCase();
        oActualiza.ApePaterno = ape_pat.toUpperCase();
        oActualiza.ApeMaterno = ape_mat.toUpperCase();
        oActualiza.IdTipoDocumento = tipo_doc;
        oActualiza.NroDocumento = nro_doc;
        oActualiza.Direccion = direccion.toUpperCase();
        oActualiza.Telefono = telefono;
        oActualiza.ClienteObservacion = observacion.toUpperCase();
        oActualiza.EstadoCliente = estado;

        $.ajax({
            url: RutaUrl,
            data: {
                oCliente: oActualiza
            },
            type: "post",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#divLoadingMensaje").hide();
                $("#divLoading").hide();

                if (data.indexOf("Modal_Vnt") == -1) {
                }
                else {
                    if (data.indexOf("Modal_Vnt_OK") == -1) {
                        $("#ModalRespuestaMsg").html(data);
                    }
                    else {
                        Swal.fire({
                            title: 'El cliente se ha actualizado correctamente!',
                            showLoaderOnConfirm: true,
                            confirmButtonText: 'Aceptar',
                            icon: 'success',
                        }).then((result) => { });

                        $("#Div_Informacion").html("");
                        $("#Div_Confirmacion").html("");
                        Consulta_Cliente();
                    }
                }
            },
            error: function (req, status, error) {
            }
        });
    }
}

function CancelarActualizar_Cliente() {
    $("#Div_Confirmacion").html("");
    $("#btnActualizar").show();
}

//**************************************************************
function Nuevo_Cliente() {
    $("#btnNuevo").hide();
    var RutaUrl = $("#Id_HdNuevo_Cliente").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    ////////ajustarBloqueoDePagina();
    $("#Div_Informacion").html("");
    $("#Div_Confirmacion").html("");
    //$("#btnRegistrar").hide();
    //$("#btnActualizar").hide();
    //$("#btnNuevo").hide();

    $.ajax({
        url: RutaUrl,
        data: {},
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divLoadingMensaje").hide();
            $("#divLoading").hide();

            if (data.indexOf("Modal_Vnt") == -1) {
                $("#Div_Informacion").html(data);
                $('html, body').animate({ scrollTop: $("#Div_Informacion").offset().top }, 800);
            }
            else {
                $("#ModalRespuestaMsg").html(data);
            }
        },
        error: function (req, status, error) {
        }
    });
}

function ValidaBtnNuevo_Cliente() {
    var nombre = $("#txtNombre").val();
    var ape_pat = $("#txtApePaterno").val();
    var ape_mat = $("#txtApeMaterno").val();
    var tipo_doc = $("#Seleccionar_ddlTipoDocumento").val();
    var nro_doc = $("#txtNroDocumento").val();
    var estado = $("#Seleccionar_ddlEstado").val();

    if (nombre == "" || ape_pat == "" || ape_mat == "" || tipo_doc == "" || nro_doc == "" || estado == "") {
        $("#btnRegistrar").hide();
    }
    else {
        $("#btnRegistrar").show();
    }
}

function NuevoClienteCancelar() {
    $("#Div_Informacion").html("");
    $("#Div_Confirmacion").html("");
    $("#btnRegistrar").hide();
    $("#btnNuevo").show();
}

function ConfirmaRegistro_Cliente() {
    $("#btnRegistrar").hide();

    var vntConfirma = '';
    vntConfirma = vntConfirma + '<div class="row"><div class="col-md-12"><hr /></div></div>';
    vntConfirma = vntConfirma + '<div class="row"><div class="col-md-6 form-label zizou-regular text-primary">Se guardarán los datos del cliente actual.</div></div>';
    vntConfirma = vntConfirma + '<div class="row"><div class="col-md-4 form-label zizou-regular">¿Desea continuar?</div></div>';
    vntConfirma = vntConfirma + '<div style="height:10px;"></div>';
    vntConfirma = vntConfirma + '<div class="row">';
    vntConfirma = vntConfirma + '<div class="col-md-2"><input type="button" class="btn btn-primary btn-sm" id="" value="Aceptar" onclick="Guardar_Cliente();" /></div>';
    vntConfirma = vntConfirma + '<div class="col-md-2"><input type="button" class="btn btn-primary btn-sm" id="" value="Cancelar" onclick="CancelarGuardar_Cliente();" /></div>';
    vntConfirma = vntConfirma + '</div>';

    $("#Div_Confirmacion").html(vntConfirma);

    $('html, body').animate({ scrollTop: $("#Div_Confirmacion").offset().top }, 800);
}

function Guardar_Cliente() {
    var ParamUrl = $("#Id_HdGuardar_Cliente").val();
    debugger;
    var nombre = $("#txtNombre").val();
    var ape_pat = $("#txtApePaterno").val();
    var ape_mat = $("#txtApeMaterno").val();
    var tipo_doc = $("#Seleccionar_ddlTipoDocumento").val();
    var nro_doc = $("#txtNroDocumento").val();
    var direccion = $("#txtDireccion").val();
    var telefono = $("#txtTelefono").val();
    var observacion = $("#txtClienteObservacion").val();
    var estado = $("#Seleccionar_ddlEstado").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    //////////ajustarBloqueoDePagina();

    var oNuevo = {};
    oNuevo.Nombre = nombre.toUpperCase();
    oNuevo.ApePaterno = ape_pat.toUpperCase();
    oNuevo.ApeMaterno = ape_mat.toUpperCase();
    oNuevo.IdTipoDocumento = tipo_doc;
    oNuevo.NroDocumento = nro_doc;
    oNuevo.Direccion = direccion.toUpperCase();
    oNuevo.Telefono = telefono;
    oNuevo.ClienteObservacion = observacion.toUpperCase();
    oNuevo.EstadoCliente = estado;

    $.ajax({
        url: ParamUrl,
        data: {
            oCliente: oNuevo
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
                        title: 'El cliente ha sido registrado correctamente!',
                        showLoaderOnConfirm: true,
                        confirmButtonText: 'Aceptar',
                        icon: 'success',
                    }).then((result) => { });

                    $("#Div_Informacion").html("");
                    $("#Div_Confirmacion").html("");
                    Consulta_Cliente();
                }
            }
        },
        error: function (req, status, error) {
        }
    });
}

function CancelarGuardar_Cliente() {
    $("#Div_Confirmacion").html("");
    $("#btnRegistrar").show();
}

//**************************************************************
function RegistroClienteCancelar(GoToIndex) {
    var ParamUrl = $("#Id_HdRegistroClienteCancelar").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    //////////ajustarBloqueoDePagina();
    debugger;
    var objMensaje = {
    };
    if (GoToIndex) {
        objMensaje.Redirecciona = "../Home/Index";
    }
    else {
        objMensaje.Redirecciona = "../Cliente/Index";
    }
    $.ajax({
        url: ParamUrl,
        data: {
            oRedirecciona: objMensaje
        },
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            debugger;
            $("#ModalRespuestaMsg").html(data);
            $("#divLoadingMensaje").hide();
            $("#divLoading").hide();
        },
        error: function (req, status, error) {
        }
    });
}

//**************************************************************
function VerDetalleCliente(oCliente) {
    var RutaUrl = $("#Id_HdVerDetalleCliente").val();

    $("#divLoadingMensaje").show();
    $("#divLoading").show();
    ////////ajustarBloqueoDePagina();
    $("#Div_Informacion").html("");
    $("#Div_Confirmacion").html("");
    $("#btnRegistrar").hide();
    $("#btnActualizar").hide();
    $("#btnNuevo").hide();

    oCliente.VerEditar = 1;
    $.ajax({
        url: RutaUrl,
        data: {
            oCliente: oCliente
        },
        type: 'POST',
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divLoadingMensaje").hide();
            $("#divLoading").hide();

            if (data.indexOf("Modal_Vnt") == -1) {
                //$("#Div_Informacion").html(data);
                //$('html, body').animate({ scrollTop: $("#Div_Informacion").offset().top }, 800);
                debugger;
                Swal.fire({
                    //title: 'El cliente ha sido registrado correctamente!',
                    showLoaderOnConfirm: true,
                    preConfirm: (login) => { },
                    confirmButtonText: 'Aceptar',
                    //icon: 'success',
                    html: data,
                }).then((result) => { });

            }
            else {
                $("#ModalRespuestaMsg").html(data);
            }
        },
        error: function (req, status, error) {
        }
    });
}
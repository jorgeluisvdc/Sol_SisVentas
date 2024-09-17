using FNT_BusinessEntities.Interface;
using FNT_BusinessLogic;
using FNT_Common;
using FNT_Common.Enum;
using FNT_VENTAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FNT_VENTAS.Controllers
{
    public class VentasController : Controller
    {
        //private readonly IVentasBusinessLogic oIVentasBusinessLogic;
        private readonly VentasBusinessLogic oIVentasBusinessLogic;

        public VentasController()//IVentasBusinessLogic oIIVentasBusinessLogic)
        {
            //this.oIVentasBusinessLogic = oIIVentasBusinessLogic;
            this.oIVentasBusinessLogic = new VentasBusinessLogic(new FNT_DataModel.DBSisVentasEntities());
        }

        // GET: Ventas
        public ActionResult Index()
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            MOMensajeError oVMModal = new MOMensajeError();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();
            DTOVentasRespuesta oView = new DTOVentasRespuesta();

            //string UsuarioCod, CodLinNeg;
            #region Validar Sesiones Principales
            /*
            if (!VerificarCaducidadSesion())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;
                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            #region ValidarAutorizacion
            /*
            List<DTOMenuBase> _result = Autorizacion();
            if (_result.Count == 0)
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = "Mensaje";

                oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            else
            {
                var _info = _result.Where(p => p.Acceso).FirstOrDefault();

                if (_info == null)
                {
                    oVMModal.BtnSesionExpirada = true;
                    oVMModal.Titulo = "Mensaje";

                    oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                    oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                                   .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                                   .DTOParametroConfiguracion.VALOR;
                    if (oVMModal.RedireccionaAutorizacion != null)
                        return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                    else
                        return PartialView("../Shared/ErrorGenerico");
                }
            }
            */
            #endregion

            #region Recupera datos de usuario
            /*
            UsuarioCod = Session["CUSUARIO"].ToString().ToUpper();
            CodLinNeg = Session["WCOD_LINEA_NEGOCIO"].ToString().ToUpper();
            if (!Recupera_Datos_Login())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;

                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            // CLIENTE
            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaCliente(new DTOCliente());
            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = oDTORespuesta.DTOHeader.DescRetorno;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }
            oView.ListaDTOCliente = oDTORespuesta.ListaDTOCliente;

            // TIPO COMPROBANTE
            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaTipoComprobante(new DTOVentasConsulta());
            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = oDTORespuesta.DTOHeader.DescRetorno;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }
            oView.ListaDTOTipoComprobante = oDTORespuesta.ListaDTOTipoComprobante;

            // TIPO DE PAGO
            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaTipoPago(new DTOVentasConsulta { Estado = 1 });
            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = oDTORespuesta.DTOHeader.DescRetorno;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }
            oView.ListaDTOTipoPago = oDTORespuesta.ListaDTOTipoPago;

            // PRODUCTOS EN STOCK
            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaStockProductos(new DTOStock());
            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = oDTORespuesta.DTOHeader.DescRetorno;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }
            oView.ListaDTOStock = oDTORespuesta.ListaDTOStock;

            Session["STOCK_PRODUCTOS"] = oView.ListaDTOStock;
            List<DTODetalleComprobante> oListaDetComp = new List<DTODetalleComprobante>();
            Session["DETALLE_COMPROBANTE"] = oListaDetComp;

            return PartialView("VentasNuevo", oView);
        }

        public ActionResult ConsultaVentas()
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            MOMensajeError oVMModal = new MOMensajeError();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();
            List<DTOVenta> oLista = new List<DTOVenta>();

            //string UsuarioCod, CodLinNeg;
            #region Validar Sesiones Principales
            /*
            if (!VerificarCaducidadSesion())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;
                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            #region ValidarAutorizacion
            /*
            List<DTOMenuBase> _result = Autorizacion();
            if (_result.Count == 0)
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = "Mensaje";

                oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            else
            {
                var _info = _result.Where(p => p.Acceso).FirstOrDefault();

                if (_info == null)
                {
                    oVMModal.BtnSesionExpirada = true;
                    oVMModal.Titulo = "Mensaje";

                    oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                    oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                                   .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                                   .DTOParametroConfiguracion.VALOR;
                    if (oVMModal.RedireccionaAutorizacion != null)
                        return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                    else
                        return PartialView("../Shared/ErrorGenerico");
                }
            }
            */
            #endregion

            #region Recupera datos de usuario
            /*
            UsuarioCod = Session["CUSUARIO"].ToString().ToUpper();
            CodLinNeg = Session["WCOD_LINEA_NEGOCIO"].ToString().ToUpper();
            if (!Recupera_Datos_Login())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;

                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaVentas(new DTOVentasConsulta());

            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = oDTORespuesta.DTOHeader.DescRetorno;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }

            oLista = oDTORespuesta.ListaDTOVenta;
            Session["LISTA_VENTAS"] = oLista;

            return PartialView("VentasConsulta", oLista);
        }

        [HttpPost]
        public JsonResult StockPrecioUnitario(DTOStock oStock)
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            MOMensajeError oVMModal = new MOMensajeError();

            //string UsuarioCod;
            #region Validar Sesiones Principales
            /*
            if (!VerificarCaducidadSesion())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;
                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            #region ValidarAutorizacion
            /*
            List<DTOMenuBase> _result = Autorizacion();
            if (_result.Count == 0)
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = "Mensaje";

                oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            else
            {
                var _info = _result.Where(p => p.Acceso).FirstOrDefault();

                if (_info == null)
                {
                    oVMModal.BtnSesionExpirada = true;
                    oVMModal.Titulo = "Mensaje";

                    oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                    oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                                   .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                                   .DTOParametroConfiguracion.VALOR;
                    if (oVMModal.RedireccionaAutorizacion != null)
                        return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                    else
                        return PartialView("../Shared/ErrorGenerico");
                }
            }
            */
            #endregion

            #region Recupera datos de usuario
            /*
            UsuarioCod = Session["CUSUARIO"].ToString().ToUpper();
            CodLinNeg = Session["WCOD_LINEA_NEGOCIO"].ToString().ToUpper();
            if (!Recupera_Datos_Login())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;

                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            var oListaStock = (List<DTOStock>)Session["STOCK_PRODUCTOS"];
            double oPrecioUnitario = new double();

            if (oListaStock != null)
            {
                if (oListaStock.Count >= 0)
                {
                    var oSProd = oListaStock.Where(s => s.IdProducto == oStock.IdProducto).FirstOrDefault();
                    if (oSProd != null)
                    {
                        oPrecioUnitario = (double)oSProd.PrecioUnitario;
                    }
                }
            }

            return Json(oPrecioUnitario.ToString("N2"));
        }

        [HttpPost]
        public JsonResult AgregarProductoSV(DTODetalleComprobante oDetalle)
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            MOMensajeError oVMModal = new MOMensajeError();

            //string UsuarioCod;
            #region Validar Sesiones Principales
            /*
            if (!VerificarCaducidadSesion())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;
                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            #region ValidarAutorizacion
            /*
            List<DTOMenuBase> _result = Autorizacion();
            if (_result.Count == 0)
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = "Mensaje";

                oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            else
            {
                var _info = _result.Where(p => p.Acceso).FirstOrDefault();

                if (_info == null)
                {
                    oVMModal.BtnSesionExpirada = true;
                    oVMModal.Titulo = "Mensaje";

                    oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                    oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                                   .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                                   .DTOParametroConfiguracion.VALOR;
                    if (oVMModal.RedireccionaAutorizacion != null)
                        return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                    else
                        return PartialView("../Shared/ErrorGenerico");
                }
            }
            */
            #endregion

            #region Recupera datos de usuario
            /*
            UsuarioCod = Session["CUSUARIO"].ToString().ToUpper();
            CodLinNeg = Session["WCOD_LINEA_NEGOCIO"].ToString().ToUpper();
            if (!Recupera_Datos_Login())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;

                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            var oLista = (List<DTODetalleComprobante>)Session["DETALLE_COMPROBANTE"];
            double oTotalComprobante = new double();

            if (oLista != null)
            {
                var oListaDetComprobante = oLista.Where(d => d.IdProducto != oDetalle.IdProducto).ToList();

                DTODetalleComprobante item = new DTODetalleComprobante();
                item.IdProducto = oDetalle.IdProducto;
                item.Cantidad = oDetalle.Cantidad;
                item.SubTotal = oDetalle.SubTotal;
                item.IgvDet = oDetalle.IgvDet;
                item.TotalProducto = oDetalle.TotalProducto;
                oListaDetComprobante.Add(item);

                oTotalComprobante = (double)(oListaDetComprobante.Sum(s => s.TotalProducto));
                Session["DETALLE_COMPROBANTE"] = oListaDetComprobante;
            }
            return Json(oTotalComprobante.ToString("N2"));
        }


        [HttpPost]
        public JsonResult EliminarProductoSV(int id)
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
        MOMensajeError oVMModal = new MOMensajeError();

        //string UsuarioCod;
        #region Validar Sesiones Principales
        /*
        if (!VerificarCaducidadSesion())
        {
            oVMModal.BtnSesionExpirada = true;
            oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;
            oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
            oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                           .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                           .DTOParametroConfiguracion.VALOR;
            if (oVMModal.RedireccionaAutorizacion != null)
                return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
            else
                return PartialView("../Shared/ErrorGenerico");
        }
        */
        #endregion

        #region ValidarAutorizacion
        /*
        List<DTOMenuBase> _result = Autorizacion();
        if (_result.Count == 0)
        {
            oVMModal.BtnSesionExpirada = true;
            oVMModal.Titulo = "Mensaje";

            oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
            oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                           .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                           .DTOParametroConfiguracion.VALOR;
            if (oVMModal.RedireccionaAutorizacion != null)
                return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
            else
                return PartialView("../Shared/ErrorGenerico");
        }
        else
        {
            var _info = _result.Where(p => p.Acceso).FirstOrDefault();

            if (_info == null)
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = "Mensaje";

                oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
        }
        */
        #endregion

        #region Recupera datos de usuario
        /*
        UsuarioCod = Session["CUSUARIO"].ToString().ToUpper();
        CodLinNeg = Session["WCOD_LINEA_NEGOCIO"].ToString().ToUpper();
        if (!Recupera_Datos_Login())
        {
            oVMModal.BtnSesionExpirada = true;
            oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;

            oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
            oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                           .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                           .DTOParametroConfiguracion.VALOR;
            if (oVMModal.RedireccionaAutorizacion != null)
                return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
            else
                return PartialView("../Shared/ErrorGenerico");
        }
        */
        #endregion

        var oListaDetComprobante = (List<DTODetalleComprobante>)Session["DETALLE_COMPROBANTE"];
        double oTotalComprobante = new double();

            if (oListaDetComprobante != null)
            {
                var oLista = (from p in oListaDetComprobante
                              where p.IdProducto != id
                              select p
                              ).ToList();

                oListaDetComprobante = oLista;

                Session["DETALLE_COMPROBANTE"] = oListaDetComprobante;

                oTotalComprobante = (double)(oListaDetComprobante.Sum(s => s.TotalProducto));
            }

            return Json(oTotalComprobante.ToString("N2"));
        }


        [HttpPost]
        public ActionResult GrabarVenta(DTOComprobantePago oComprobante)
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();

            MOMensajeError oVMModal = new MOMensajeError();
            //string UsuarioCod, CodLinNeg;
            #region Validar Sesiones Principales
            /*
            if (!VerificarCaducidadSesion())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;
                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            #region ValidarAutorizacion
            /*
            List<DTOMenuBase> _result = Autorizacion();
            if (_result.Count == 0)
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = "Mensaje";

                oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            else
            {
                var _info = _result.Where(p => p.Acceso).FirstOrDefault();

                if (_info == null)
                {
                    oVMModal.BtnSesionExpirada = true;
                    oVMModal.Titulo = "Mensaje";

                    oVMModal.Mensaje = FNT_Common.Constantes.Mensajes.ERR_ACCESO;
                    oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                                   .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                                   .DTOParametroConfiguracion.VALOR;
                    if (oVMModal.RedireccionaAutorizacion != null)
                        return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                    else
                        return PartialView("../Shared/ErrorGenerico");
                }
            }
            */
            #endregion

            #region Recupera datos de usuario
            /*
            UsuarioCod = Session["CUSUARIO"].ToString().ToUpper();
            CodLinNeg = Session["WCOD_LINEA_NEGOCIO"].ToString().ToUpper();
            if (!Recupera_Datos_Login())
            {
                oVMModal.BtnSesionExpirada = true;
                oVMModal.Titulo = Constantes.Titulo.SESION_EXPIRADA;

                oVMModal.Mensaje = Constantes.Mensajes.SESION_EXPIRADA;
                oVMModal.RedireccionaAutorizacion = oIParametroConfiguracionBusinessLogic
                                               .ObtenerParametroConfiguracion(new DTOParametroConfiguracion { COD_PARAMETRO = ParametroConfiguracion.Servidor.LOGIN_ADMIN })
                                               .DTOParametroConfiguracion.VALOR;
                if (oVMModal.RedireccionaAutorizacion != null)
                    return PartialView("../MensajeError/MensajeError_Autorizacion", oVMModal);
                else
                    return PartialView("../Shared/ErrorGenerico");
            }
            */
            #endregion

            oComprobante.usuario_creacion = "VENTAS"; ////Session["CUSUARIO"].ToString();
            //oCliente.EstadoCliente = 1;
            oComprobante.guid_comprobante = Guid.NewGuid().ToString();
            var oListaDetComprobante = (List<DTODetalleComprobante>)Session["DETALLE_COMPROBANTE"];
            oComprobante.total = (double)(oListaDetComprobante.Sum(s => s.TotalProducto));

            oDTORespuesta = oIVentasBusinessLogic.InsertarComprobante(oComprobante, oListaDetComprobante);
            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Correcto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.RESULTADO;
                oMensaje.Mensaje = Constantes.Mensajes.RES_CLIENTE_OK;
                oMensaje.BtnCerrar = true;
                oMensaje.Parametros = true;
                oMensaje.NombreProceso = "OK";
            }
            else
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = Constantes.Mensajes.ERR_REGISTRAR_CLIENTE_ERR;
                oMensaje.BtnCerrar = true;
            }
            return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);

        }

    }
}
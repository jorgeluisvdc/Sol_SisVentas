using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FNT_DataModel;
using FNT_Common.Enum;
using FNT_Common;
using FNT_VENTAS.Models;
using FNT_BusinessEntities.Interface;
using FNT_BusinessLogic;

namespace FNT_VENTAS.Controllers
{
    public class ClienteController : Controller
    {
        //private DBSisVentasEntities db = new DBSisVentasEntities();

        //private readonly IVentasBusinessLogic oIVentasBusinessLogic;
        private readonly VentasBusinessLogic oIVentasBusinessLogic;

        public ClienteController()//IVentasBusinessLogic oIIVentasBusinessLogic)
        {
            //this.oIVentasBusinessLogic = oIIVentasBusinessLogic;
            this.oIVentasBusinessLogic = new VentasBusinessLogic(new FNT_DataModel.DBSisVentasEntities());
        }


        // GET: Cliente
        public ActionResult Index()
        {
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

            return PartialView("ClientePrincipal");
        }

        public ActionResult ConsultaCliente()
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            MOMensajeError oVMModal = new MOMensajeError();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();
            List<DTOCliente> oLista = new List<DTOCliente>();

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

            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaCliente(new DTOCliente());

            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = oDTORespuesta.DTOHeader.DescRetorno;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }

            oLista = oDTORespuesta.ListaDTOCliente;
            Session["LISTA_CLIENTES"] = oLista;

            return PartialView("ClienteConsulta", oLista);
        }

        public ActionResult RegistroClienteCancelar(MOMensajeConfirmacion oRedirecciona)
        {
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();

            oMensaje.Redirecciona = oRedirecciona.Redirecciona;

            oMensaje.Titulo = Constantes.Titulo.CANCELAR;
            oMensaje.Mensaje = Constantes.Mensajes.CNF_CANCELAR_SOLICITUD;
            if (!string.IsNullOrEmpty(oRedirecciona.SubMensaje))
            {
                oMensaje.Mensaje = Constantes.Mensajes.CNC_PERDER_INFORMACION;
                oMensaje.SubMensaje = Constantes.Mensajes.CNF_CONFIRMACION_CONTINUAR;
            }
            oMensaje.BtnAceptar = true;
            oMensaje.BtnCancelar = true;
            return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
        }

        [HttpPost]
        public ActionResult EditarCliente(DTOCliente oCliente)
        {
            MOMensajeError oVMModal = new MOMensajeError();
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();

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

            if (oCliente.IdCliente == 0)
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = Constantes.Mensajes.OCURRIO_ERROR;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }

            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaTipoDocumento(new DTOVentasConsulta());
            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = Constantes.Mensajes.ERR_EJECUCION_ERROR;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }

            oDTORespuesta.DTOCliente = oCliente;
            return PartialView("ClienteVerEditar", oDTORespuesta);
        }

        [HttpPost]
        public ActionResult ActualizarCliente(DTOCliente oCliente)
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

            //oArea.UsuarioModificacion = Session["CUSUARIO"].ToString();

            oCliente.UsuarioModificacion = "SISTEMA";
            oDTORespuesta = oIVentasBusinessLogic.ActualizarCliente(oCliente);

            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = Constantes.Mensajes.ERR_ACTUALIZAR_CLIENTE_ERR;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }

            //Validacion de ejecucion correcta para realizar refresh a la pagina
            oMensaje.Titulo = Constantes.Titulo.RESULTADO;
            oMensaje.Mensaje = Constantes.Mensajes.RES_ACTUALIZACION_CLIENTE_OK;
            oMensaje.NombreProceso = "OK";
            oMensaje.Parametros = true;
            oMensaje.BtnCerrar = true;

            return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
        }

        [HttpPost]
        public ActionResult NuevoCliente()
        {
            MOMensajeError oVMModal = new MOMensajeError();
            MOMensajeConfirmacion oMensaje = new MOMensajeConfirmacion();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();

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

            //if (oCliente.IdCliente == 0)
            //{
            //    oMensaje.Titulo = Constantes.Titulo.ERROR;
            //    oMensaje.Mensaje = Constantes.Mensajes.OCURRIO_ERROR;
            //    oMensaje.BtnCerrar = true;
            //    return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            //}

            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaTipoDocumento(new DTOVentasConsulta());
            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = Constantes.Mensajes.ERR_EJECUCION_ERROR;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }

            //oDTORespuesta.DTOCliente = oCliente;
            return PartialView("ClienteNuevo", oDTORespuesta);
        }

        [HttpPost]
        public ActionResult GrabarNuevo_Cliente(DTOCliente oCliente)
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

            oDTORespuesta = oIVentasBusinessLogic.ObtenerListaCliente(oCliente);

            if (oDTORespuesta.DTOHeader.CodigoRetorno == HeaderEnum.Incorrecto.ToString())
            {
                oMensaje.Titulo = Constantes.Titulo.ERROR;
                oMensaje.Mensaje = Constantes.Mensajes.ERR_EJECUCION_ERROR;
                oMensaje.BtnCerrar = true;
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }

            if (oDTORespuesta.ListaDTOCliente.Count > 0)
            {
                oMensaje.Titulo = Constantes.Titulo.VALIDACION;
                oMensaje.Mensaje = Constantes.Mensajes.VAL_CLIENTE_YAEXISTENTE;
                oMensaje.BtnCerrar = true;
                oMensaje.Parametros = true;
                oMensaje.FechaCreacion = ((DateTime)oDTORespuesta.ListaDTOCliente.FirstOrDefault().FechaCreacion).ToString("dd/MM/yyyy H:mm");
                oMensaje.UsuarioCreador = oDTORespuesta.ListaDTOCliente.FirstOrDefault().UsuarioCreacion;
                ViewBag.Error = "Error";
                return PartialView("../MensajeError/MensajeConfirmacion", oMensaje);
            }
            else
            {
                oCliente.UsuarioCreacion = "SISTEMA"; ////Session["CUSUARIO"].ToString();
                oCliente.EstadoCliente = 1;

                oDTORespuesta = oIVentasBusinessLogic.InsertarCliente(oCliente);

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
                //return Json(oMensaje.Mensaje.ToString());
            }
        }
    }
}

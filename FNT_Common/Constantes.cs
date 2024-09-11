using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FNT_Common
{
    public static class Constantes
    {

        public static class Mensajes
        {
            public static readonly string OCURRIO_ERROR = "Ocurríó un error cuando se ejecutaba la acción";

            /* RESULTADO */
            //public static readonly string RES_ACTUALIZACION_TIPO_PAGO_OK = "Su tipo de pago se ha actualizado correctamente.";
            //public static readonly string RES_TIPO_PAGO_OK = "Su tipo de pago ha sido registrado correctamente.";

            public static readonly string RES_ACTUALIZACION_CLIENTE_OK = "El cliente se ha actualizado correctamente.";
            public static readonly string RES_CLIENTE_OK = "El cliente ha sido registrado correctamente.";

            /* CONFIRMACION */
            public static readonly string CNF_CANCELAR_SOLICITUD = "¿Está seguro(a) de cancelar la solicitud en proceso?";
            public static readonly string CNF_CONFIRMACION_CONTINUAR = "¿Desea continuar?";

            /* CANCELAR */
            public static readonly string CNC_PERDER_INFORMACION = "Se perderá toda la información consultada hasta el momento.";

            /* VALIDACION */
            public static readonly string VAL_CLIENTE_YAEXISTENTE = "El cliente seleccionado ya existe.";

            /* ERROR */
            public static readonly string ERR_EJECUCION_ERROR = "Sucedió un error al intentar registrar su orden de ejecución. Inténtelo nuevamente.";

            public static readonly string ERR_ACTUALIZAR_CLIENTE_ERR = "Se presentaron inconvenientes al intentar actualizar el cliente.";
            public static readonly string ERR_REGISTRAR_CLIENTE_ERR = "Sucedió un error al intentar registrar el cliente. Inténtelo nuevamente.";

        }

        public static class Titulo
        {
            public static readonly string RESULTADO = "Resultado";
            public static readonly string ERROR = "Error";
            public static readonly string VALIDACION = "Validación";
            public static readonly string CANCELAR = "Cancelar";

            public static readonly string CONFIRMACION = "Confirmación";
            public static readonly string SESION_EXPIRADA = "Sesión expirada";
        }

        public static class Aplicaciones
        {

            public static class DatosGenerales
            {
                public static class Parametros
                {
                    public static readonly string Insert = "IN";
                    public static readonly string Update = "UP";
                    public static readonly string Delete = "DE";
                }
            }

            public static class TipoPago
            {
                public static readonly string Titulo = "Tipo de Pago";
            }

            public static class Cliente
            {
                public static readonly string Titulo = "Clientes";
            }
        }
    }
}
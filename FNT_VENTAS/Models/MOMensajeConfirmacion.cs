using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FNT_VENTAS.Models
{
    public class MOMensajeConfirmacion
    {
        public string Titulo { set; get; }
        public string Mensaje { set; get; }
        public string SubMensaje { set; get; }
        public string Descripcion { set; get; }
        public string SubMensajeColor { set; get; }
        public string PreguntaConfirmacion { set; get; }
        public bool Parametros { set; get; }
        public bool ResultadoEjecucion { set; get; }
        public string ResultadoNombreVal1 { set; get; }
        public long ResultadoVal1 { set; get; }
        public string ResultadoNombreVal2 { set; get; }
        public long ResultadoVal2 { set; get; }
        public long NroOrden { set; get; }
        public string Modalidad { set; get; }

        public bool BtnAceptar { set; get; }
        public bool BtnCancelar { set; get; }
        public bool BtnCerrar { set; get; }
        public bool BtnDescargar { set; get; }
        public string Redirecciona { set; get; }
        public string FechaCreacion { set; get; }



        public string SubMensajePie { set; get; }

        public string ResultadoValText1 { set; get; }

        public string ResultadoValText2 { set; get; }

        public bool VntCerrar { set; get; }
        public bool CerrarLoading { set; get; }

        public bool BtnSesion { set; get; }

        public string Funcion { set; get; }
        public string FuncionFinal { set; get; }
        public int ParametroFuncion { set; get; }
        public string Controlador { set; get; }
        public string ResultadoVista { set; get; }
        public string NombreProceso { set; get; }

        public string UsuarioCreador { set; get; }
        //public int VacanteNueva { set; get; }

        public string Periodo { set; get; }
        public string PeriodoPago { set; get; }
        public string Cierre { set; get; }
        public string FechaInicio { set; get; }
        public string FechaFin { set; get; }
        public long IdProceso { set; get; }
        public string TipoDedicacion { set; get; }

    }
}
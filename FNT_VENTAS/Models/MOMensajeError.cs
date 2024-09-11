using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FNT_VENTAS.Models
{
    public class MOMensajeError
    {
        public string Titulo { set; get; }
        public string Mensaje { set; get; }
        public string RedireccionaAutorizacion { set; get; }
        public bool BtnSesionExpirada { set; get; }
        public bool BtnAprobarCotizacion { set; get; }
        public bool BtnErrorCarga { set; get; }
        public bool BtnSesiones { set; get; }
        public int TipoBloqueo { get; set; }
    }
}
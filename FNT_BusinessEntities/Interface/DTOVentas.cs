using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FNT_BusinessEntities.Interface
{

    public class DTOVentasRespuesta
    {
        public DTOHeader DTOHeader { get; set; }
        //public DTOTipoPago DTOTipoPago { get; set; }
        public DTOCliente DTOCliente { get; set; }
        //public DTOTipoDocumento DTOTipoDocumento { get; set; }
        //public DTOStock DTOStock { get; set; }
        public List<DTOTipoPago> ListaDTOTipoPago { get; set; }
        public List<DTOVenta> ListaDTOVenta { get; set; }
        public List<DTOCliente> ListaDTOCliente { get; set; }
        public List<DTOTipoDocumento> ListaDTOTipoDocumento { get; set; }
        public List<DTOTipoComprobante> ListaDTOTipoComprobante { get; set; }
        public List<DTOStock> ListaDTOStock { get; set; }
    }

    public class DTOVentasConsulta
    {
        public string TipoConsulta { get; set; }
        public string ValorConsulta { get; set; }
        public string CodConsulta { get; set; }
        public Nullable<int> CodigoConsulta { get; set; }
        public string Vista { get; set; }
        public string Funcion { get; set; }
        public Nullable<int> Estado { get; set; }
    }

    public class DTOVenta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdClientePersona { get; set; }
        public string NombreCliente { get; set; }
        public string ApePatCliente { get; set; }
        public string ApeMatCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdEmpleadoPersona { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApePatEmpleado { get; set; }
        public string ApeMatEmpleado { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdComprobante { get; set; }
        public string NroComprobante { get; set; }
        public Nullable<double> TotalComprobante { get; set; }
        public int IdtipoComprobante { get; set; }
        public string DescTipoComprobante { get; set; }
        public string ObservacionVenta { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<DateTime> FechaModificacion { get; set; }
    }

    public class DTOCliente
    {
        public int IdCliente { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> EstadoCliente { get; set; }
        public string ClienteObservacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int VerEditar { get; set; } // 1: Ver | 2: Editar
    }

    public class DTOTipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string TipoDocumentoDescripcion { get; set; }
        public Nullable<int> Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    }

    public class DTOTipoComprobante
    {
        public int IdTipoComprobante { get; set; }
        public string descripcionTipoComprobante { get; set; }
        public Nullable<int> Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    }

    public class DTOTipoPago
    {
        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    }

    public class DTOStock
    {
        public int IdStock { get; set; }
        public int IdProducto { get; set; }
        public string ProductoDescripcion { get; set; }
        public Nullable<double> PrecioUnitario { get; set; }
        public Nullable<int> StockActual { get; set; }
        public Nullable<int> StockMinimo { get; set; }
        public Nullable<int> StockMaximo { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    }

    public class DTODetalleComprobante
    {
        public int IdDetalleComprobante { get; set; }
        public int IdComprobante { get; set; }
        public int IdProducto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<double> IgvDet { get; set; }
        public Nullable<double> TotalProducto { get; set; }
        public Nullable<double> Descuento { get; set; }
        public string Usuario_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        public string Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> Fecha_Modificacion { get; set; }
        public string Guid_Comprobante { get; set; }
    }

    public class DTOComprobantePago
    {
        public int idComprobante { get; set; }
        public int IdCliente { get; set; }
        public string nroComprobante { get; set; }
        public int idTipoComprobante { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<double> igv { get; set; }
        public Nullable<double> total { get; set; }
        public int idTipoPago { get; set; }
        public Nullable<double> descuento { get; set; }
        public string usuario_creacion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public string guid_comprobante { get; set; }
    }

}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FNT_DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalleComprobante
    {
        public int idDetalleComprobante { get; set; }
        public int idComprobante { get; set; }
        public int idProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<double> subTotal { get; set; }
        public Nullable<double> descuento { get; set; }
        public string usuario_creacion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public string guid_comprobante { get; set; }
    
        public virtual comprobantePago comprobantePago { get; set; }
        public virtual producto producto { get; set; }
    }
}

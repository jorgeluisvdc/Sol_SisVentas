﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBSisVentasEntities : DbContext
    {
        public DBSisVentasEntities()
            : base("name=DBSisVentasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<comprobantePago> comprobantePago { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<inventario> inventario { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<stock> stock { get; set; }
        public virtual DbSet<tipoComprobante> tipoComprobante { get; set; }
        public virtual DbSet<tipoDocumento> tipoDocumento { get; set; }
        public virtual DbSet<tipoEmpleado> tipoEmpleado { get; set; }
        public virtual DbSet<tipoPago> tipoPago { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<venta> venta { get; set; }
        public virtual DbSet<detalleComprobante> detalleComprobante { get; set; }
    }
}

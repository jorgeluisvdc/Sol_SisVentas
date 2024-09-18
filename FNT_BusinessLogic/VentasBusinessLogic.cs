using FNT_BusinessEntities.Interface;
using FNT_Common.Enum;
using FNT_DataModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
//using System.Web;
//using AutoMapper; //************
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using System.Drawing;
//using System.IO;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;




namespace FNT_BusinessLogic
{
    public class VentasBusinessLogic : IVentasBusinessLogic
    {
        private readonly DBSisVentasEntities db = new DBSisVentasEntities();

        public VentasBusinessLogic(DBSisVentasEntities db)
        {
            this.db = db;
            //this._oIParametroConfiguracionBusinessLogic = oIParametroConfiguracionBusinessLogic;
        }

        public DTOVentasRespuesta ObtenerListaVentas(DTOVentasConsulta oConsulta)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oRespuesta = new DTOVentasRespuesta();
            List<DTOVenta> oLista = new List<DTOVenta>();

            try
            {
                var oVenta = db.venta.AsQueryable();
                var oCli = db.cliente.AsQueryable();
                var oPer = db.persona.AsQueryable();
                var oComp = db.comprobantePago.AsQueryable();
                var oTipComp = db.tipoComprobante.AsQueryable();

                oLista = (from v in oVenta
                          join c in oCli on new { idCliente = (int)v.idCliente }
                                equals new { c.idCliente }
                          join p in oPer on new { idPersona = (int)c.idPersona }
                                equals new { p.idPersona }
                          join cp in oComp on new { idComprobante = (int)v.idComprobante }
                                equals new { cp.idComprobante }
                          join tc in oTipComp on new { idTipoComprobante = (int)cp.idTipoComprobante }
                                equals new { tc.idTipoComprobante }

                          select new DTOVenta
                          {
                              IdVenta = v.idVenta,
                              NombreCliente = p.nombre,
                              ApePatCliente = p.apePaterno,
                              ApeMatCliente = p.apeMaterno,

                              NroComprobante = cp.nroComprobante,
                              DescTipoComprobante = tc.descripcionTipoComprobante,
                              TotalComprobante = cp.total,

                              UsuarioCreacion = v.usuario_creacion,
                              FechaCreacion = v.fecha_creacion,
                              UsuarioModificacion = v.usuario_modificacion,
                              FechaModificacion = v.fecha_modificacion,
                          })
                //.Where(t => t.IdTipoPago == (oConsulta.CodigoConsulta == null ? t.IdTipoPago : oConsulta.CodigoConsulta)).ToList()
                //.Where(t => t.Descripcion == (string.IsNullOrEmpty(oConsulta.ValorConsulta) ? t.Descripcion : oConsulta.ValorConsulta)).ToList()
                .Where(t => t.FechaCreacion >= (oConsulta.FechaIni == null ? t.FechaCreacion : oConsulta.FechaIni)).ToList()
                .Where(t => t.FechaCreacion <= (oConsulta.FechaFin== null ? t.FechaCreacion : oConsulta.FechaFin)).ToList();

                oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                oDTOHeader.DescRetorno = string.Empty;
                oRespuesta.ListaDTOVenta = oLista;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
                //DataUtil.EscribirLog("VentasBusinessLogic | Catch : Error ObtenerListaVentas | ToString --> " + ex.ToString());
                //DataUtil.EscribirLog("VentasBusinessLogic | Catch : Error ObtenerListaVentas | Message --> " + ex.Message);
            }
            oRespuesta.DTOHeader = oDTOHeader;
            return oRespuesta;
        }

        public DTOVentasRespuesta ObtenerListaCliente(DTOCliente oConsulta)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oRespuesta = new DTOVentasRespuesta();
            List<DTOCliente> oLista = new List<DTOCliente>();

            try
            {
                var oCli = db.cliente.AsQueryable();
                var oPer = db.persona.AsQueryable();
                var oTipDoc = db.tipoDocumento.AsQueryable();

                oLista = (from c in oCli
                          join p in oPer on new { idPersona = (int)c.idPersona }
                                equals new { p.idPersona }
                          join td in oTipDoc on new { p.idTipoDocumento }
                                equals new { td.idTipoDocumento }
                          select new DTOCliente
                          {
                              IdCliente = c.idCliente,
                              IdPersona = c.idPersona,
                              Nombre = p.nombre,
                              ApePaterno = p.apePaterno,
                              ApeMaterno = p.apeMaterno,
                              IdTipoDocumento = p.idTipoDocumento,
                              TipoDocumento = td.tipoDocumentoDescripcion,
                              NroDocumento = p.nroDocumento,
                              Direccion = p.direccion,
                              Telefono = p.telefono,
                              EstadoCliente = c.estado,
                              ClienteObservacion = c.clienteObservacion,
                              UsuarioCreacion = c.usuario_creacion,
                              FechaCreacion = c.fecha_creacion,
                              UsuarioModificacion = c.usuario_modificacion,
                              FechaModificacion = c.fecha_modificacion,
                          }).Where(c => c.IdCliente == (oConsulta.IdCliente == 0 ? c.IdCliente : oConsulta.IdCliente)).ToList()
                            //.Where(c => c.Nombre == (string.IsNullOrEmpty(oConsulta.Nombre) ? c.Nombre : oConsulta.Nombre)).ToList()
                            //.Where(c => c.ApePaterno == (string.IsNullOrEmpty(oConsulta.ApePaterno) ? c.ApePaterno : oConsulta.ApePaterno)).ToList()
                            //.Where(c => c.ApeMaterno == (string.IsNullOrEmpty(oConsulta.ApeMaterno) ? c.ApeMaterno : oConsulta.ApeMaterno)).ToList()
                            .Where(c => c.NroDocumento == (string.IsNullOrEmpty(oConsulta.NroDocumento) ? c.NroDocumento : oConsulta.NroDocumento)).ToList()
                            .Where(c => c.EstadoCliente == (oConsulta.EstadoCliente == null ? c.EstadoCliente : oConsulta.EstadoCliente)).ToList();

                oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                oDTOHeader.DescRetorno = string.Empty;
                oRespuesta.ListaDTOCliente = oLista;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
            }
            oRespuesta.DTOHeader = oDTOHeader;
            return oRespuesta;
        }

        public DTOVentasRespuesta ObtenerListaTipoComprobante(DTOVentasConsulta oConsulta)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oRespuesta = new DTOVentasRespuesta();
            List<DTOTipoComprobante> oLista = new List<DTOTipoComprobante>();

            try
            {
                var oTipComp = db.tipoComprobante.AsQueryable();

                oLista = (from t in oTipComp
                          select new DTOTipoComprobante
                          {
                              IdTipoComprobante = t.idTipoComprobante,
                              descripcionTipoComprobante = t.descripcionTipoComprobante,
                              Estado = t.estado,
                              UsuarioCreacion = t.usuario_creacion,
                              FechaCreacion = t.fecha_creacion,
                              UsuarioModificacion = t.usuario_modificacion,
                              FechaModificacion = t.fecha_modificacion,
                          }).Where(t => t.IdTipoComprobante == (oConsulta.CodigoConsulta == null ? t.IdTipoComprobante : oConsulta.CodigoConsulta)).ToList()
                            .Where(t => t.descripcionTipoComprobante == (string.IsNullOrEmpty(oConsulta.ValorConsulta) ? t.descripcionTipoComprobante : oConsulta.ValorConsulta)).ToList()
                            .Where(t => t.Estado == (oConsulta.Estado == null ? t.Estado : oConsulta.Estado)).ToList();

                oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                oDTOHeader.DescRetorno = string.Empty;
                oRespuesta.ListaDTOTipoComprobante = oLista;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
            }
            oRespuesta.DTOHeader = oDTOHeader;
            return oRespuesta;
        }

        public DTOVentasRespuesta ObtenerListaTipoPago(DTOVentasConsulta oConsulta)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oRespuesta = new DTOVentasRespuesta();
            List<DTOTipoPago> oLista = new List<DTOTipoPago>();

            try
            {
                var oTipPag = db.tipoPago.AsQueryable();

                oLista = (from t in oTipPag
                              //where t.estado == oConsulta.Estado
                          select new DTOTipoPago
                          {
                              IdTipoPago = t.idTipoPago,
                              Descripcion = t.descripcion,
                              Estado = t.estado,
                              //UsuarioCreacion = t.USUARIO_CREACION,
                              //FechaCreacion = t.FECHA_CREACION,
                              //UsuarioModificacion = t.USUARIO_MODIFICACION,
                              //FechaModificacion = t.FECHA_MODIFICACION,
                          }).Where(t => t.IdTipoPago == (oConsulta.CodigoConsulta == null ? t.IdTipoPago : oConsulta.CodigoConsulta)).ToList()
                            .Where(t => t.Descripcion == (string.IsNullOrEmpty(oConsulta.ValorConsulta) ? t.Descripcion : oConsulta.ValorConsulta)).ToList()
                            .Where(t => t.Estado == (oConsulta.Estado == null ? t.Estado : oConsulta.Estado)).ToList();

                oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                oDTOHeader.DescRetorno = string.Empty;
                oRespuesta.ListaDTOTipoPago = oLista;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
            }
            oRespuesta.DTOHeader = oDTOHeader;
            return oRespuesta;
        }

        public DTOVentasRespuesta ObtenerListaStockProductos(DTOStock oConsulta)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oRespuesta = new DTOVentasRespuesta();
            List<DTOStock> oLista = new List<DTOStock>();

            try
            {
                var oStock = db.stock.AsQueryable();
                var oProd = db.producto.AsQueryable();

                oLista = (from s in oStock
                          join p in oProd on new { s.idProducto }
                                equals new { p.idProducto }
                          select new DTOStock
                          {
                              IdStock = s.idStock,
                              IdProducto = s.idProducto,
                              StockActual = s.stockActual,
                              StockMinimo = s.stockMinimo,
                              StockMaximo = s.stockMaximo,
                              ProductoDescripcion = p.productoDescripcion,
                              PrecioUnitario = p.precioUnitario,
                              UsuarioCreacion = s.usuario_creacion,
                              FechaCreacion = s.fecha_creacion,
                              UsuarioModificacion = s.usuario_modificacion,
                              FechaModificacion = s.fecha_modificacion,
                          }).Where(s => s.IdStock == (oConsulta.IdStock == 0 ? s.IdStock : oConsulta.IdStock)).ToList()
                            .Where(s => s.IdProducto == (oConsulta.IdProducto == 0 ? s.IdProducto : oConsulta.IdProducto)).ToList()
                            .Where(s => s.ProductoDescripcion == (string.IsNullOrEmpty(oConsulta.ProductoDescripcion) ? s.ProductoDescripcion : oConsulta.ProductoDescripcion)).ToList()
                            ;
                oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                oDTOHeader.DescRetorno = string.Empty;
                oRespuesta.ListaDTOStock = oLista;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
            }
            oRespuesta.DTOHeader = oDTOHeader;
            return oRespuesta;
        }

        public DTOVentasRespuesta ObtenerListaTipoDocumento(DTOVentasConsulta oConsulta)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oRespuesta = new DTOVentasRespuesta();
            List<DTOTipoDocumento> oLista = new List<DTOTipoDocumento>();

            try
            {
                var oTipDoc = db.tipoDocumento.AsQueryable();

                oLista = (from t in oTipDoc
                          select new DTOTipoDocumento
                          {
                              IdTipoDocumento = t.idTipoDocumento,
                              TipoDocumentoDescripcion = t.tipoDocumentoDescripcion,
                              Estado = t.estado,
                              UsuarioCreacion = t.usuario_creacion,
                              FechaCreacion = t.fecha_creacion,
                              UsuarioModificacion = t.usuario_modificacion,
                              FechaModificacion = t.fecha_modificacion,
                          }).Where(t => t.IdTipoDocumento == (oConsulta.CodigoConsulta == null ? t.IdTipoDocumento : oConsulta.CodigoConsulta)).ToList()
                            .Where(t => t.TipoDocumentoDescripcion == (string.IsNullOrEmpty(oConsulta.ValorConsulta) ? t.TipoDocumentoDescripcion : oConsulta.ValorConsulta)).ToList()
                            .Where(t => t.Estado == (oConsulta.Estado == null ? t.Estado : oConsulta.Estado)).ToList();

                oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                oDTOHeader.DescRetorno = string.Empty;
                oRespuesta.ListaDTOTipoDocumento = oLista;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
            }
            oRespuesta.DTOHeader = oDTOHeader;
            return oRespuesta;
        }

        public DTOVentasRespuesta ActualizarCliente(DTOCliente oCliente)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oRespuesta = new DTOVentasRespuesta();

            //var scope = new TransactionScope(
            //            TransactionScopeOption.RequiresNew,
            //            new TransactionOption()
            //            {
            //                IsolationLevel = IsolationLevel.ReadUncommitted
            //            }
            //            );
            try
            {
                if (oCliente.IdCliente != 0)
                {
                    //using (scope)
                    //{
                        var oCli = db.cliente.AsQueryable();
                        var oInfoUp = oCli.Where(c => c.idCliente == oCliente.IdCliente
                                                ).FirstOrDefault();

                        if (oInfoUp != null)
                        {
                            oInfoUp.clienteObservacion = oCliente.ClienteObservacion;
                            oInfoUp.estado = oCliente.EstadoCliente;
                            oInfoUp.fecha_modificacion = DateTime.Now;
                            oInfoUp.usuario_modificacion = oCliente.UsuarioModificacion;
                        }
                        //db.cliente.Update(oInfoUp);
                        db.Entry(oInfoUp).State = EntityState.Modified;
                        db.SaveChanges();

                        var oPer = db.persona.AsQueryable();
                        var oInfoUpPer = oPer.Where(p => p.idPersona == oCliente.IdPersona
                                                ).FirstOrDefault();

                        if (oInfoUpPer != null)
                        {
                            oInfoUpPer.nombre = oCliente.Nombre;
                            oInfoUpPer.apePaterno = oCliente.ApePaterno;
                            oInfoUpPer.apeMaterno = oCliente.ApeMaterno;
                            oInfoUpPer.idTipoDocumento = oCliente.IdTipoDocumento;
                            oInfoUpPer.nroDocumento = oCliente.NroDocumento;
                            oInfoUpPer.direccion = oCliente.Direccion;
                            oInfoUpPer.telefono = oCliente.Telefono;

                            oInfoUpPer.estado = oCliente.EstadoCliente;
                            oInfoUpPer.fecha_modificacion = DateTime.Now;
                            oInfoUpPer.usuario_modificacion = oCliente.UsuarioModificacion;
                        }
                        //db.persona.Update(oInfoUpPer);
                        db.Entry(oInfoUpPer).State = EntityState.Modified;
                        db.SaveChanges();

                        //scope.Complete();

                        oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                        oDTOHeader.DescRetorno = string.Empty;
                        oRespuesta.DTOCliente = oCliente;
                    //}
                }

            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.ToString();
            }
            oRespuesta.DTOHeader = oDTOHeader;
            return oRespuesta;
        }

        public DTOVentasRespuesta InsertarCliente(DTOCliente oCliente)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();

            //var scope = new TransactionScope(
            //            TransactionScopeOption.RequiresNew,
            //            new TransactionOptions()
            //            {
            //                IsolationLevel = IsolationLevel.ReadUncommitted
            //            }
            //);

            try
            {

                if (!string.IsNullOrEmpty(oCliente.NroDocumento))
                {
                    //using (scope)
                    //{
                    persona oIns = new persona();
                    oIns.nombre = oCliente.Nombre;
                    oIns.apePaterno = oCliente.ApePaterno;
                    oIns.apeMaterno = oCliente.ApeMaterno;
                    oIns.idTipoDocumento = oCliente.IdTipoDocumento;
                    oIns.nroDocumento = oCliente.NroDocumento;
                    oIns.direccion = oCliente.Direccion;
                    oIns.telefono = oCliente.Telefono;

                    oIns.estado = oCliente.EstadoCliente;

                    oIns.usuario_creacion = oCliente.UsuarioCreacion;
                    oIns.fecha_creacion = DateTime.Now;

                    //var oIns = Mapper.Map<DTOCliente, FNT_DataModel.persona>(oCliente);
                    //oUnitOfWork.PersonaRepository.Insert(oIns);
                    db.persona.Add(oIns);
                    db.SaveChanges();

                    var oPer = db.persona.AsQueryable();
                    var oPersona = oPer.Where(p => p.nroDocumento == oCliente.NroDocumento
                                            ).FirstOrDefault();

                    //Mapper.CreateMap<FNT_DataModel.persona, FNT_DataModel.cliente>()
                    cliente oInsCli = new cliente();
                    oInsCli.idPersona = oPersona.idPersona;
                    oInsCli.estado = oPersona.estado;
                    oInsCli.clienteObservacion = oCliente.ClienteObservacion;

                    oInsCli.usuario_creacion = oPersona.usuario_creacion;
                    oInsCli.fecha_creacion = DateTime.Now;

                    //var oInsCli = Mapper.Map<FNT_DataModel.persona, FNT_DataModel.cliente>(oPersona);
                    //oUnitOfWork.ClienteRepository.Insert(oInsCli);
                    db.cliente.Add(oInsCli);
                    db.SaveChanges();

                    //scope.Complete();

                    oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                    oDTOHeader.DescRetorno = string.Empty;
                    oDTORespuesta.DTOCliente = oCliente;
                    //}
                }
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
            }
            oDTORespuesta.DTOHeader = oDTOHeader;
            return oDTORespuesta;
        }

        public DTOVentasRespuesta InsertarComprobante(DTOComprobantePago oComprobante,List<DTODetalleComprobante> oListaDet)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            DTOVentasRespuesta oDTORespuesta = new DTOVentasRespuesta();

            try
            {
                if (!string.IsNullOrEmpty(oComprobante.guid_comprobante))
                {
                    comprobantePago oIns = new comprobantePago();
                    oIns.nroComprobante = oComprobante.nroComprobante;
                    oIns.idTipoComprobante = oComprobante.idTipoComprobante;
                    oIns.fecha = DateTime.Now; //oComprobante.fecha;
                    oIns.igv = oComprobante.igv;
                    oIns.total = oComprobante.total;
                    oIns.idTipoPago = oComprobante.idTipoPago;
                    oIns.usuario_creacion = oComprobante.usuario_creacion;
                    oIns.fecha_creacion = DateTime.Now;
                    oIns.guid_comprobante = oComprobante.guid_comprobante;

                    db.comprobantePago.Add(oIns);
                    db.SaveChanges();

                    var oComp = db.comprobantePago.AsQueryable();
                    var oComprobantePago = oComp.Where(c => c.guid_comprobante == oComprobante.guid_comprobante
                                            ).FirstOrDefault();

                    
                    detalleComprobante oInsDet = new detalleComprobante();
                    foreach (var oItem in oListaDet)
                    {
                        oInsDet.idComprobante = oComprobantePago.idComprobante;
                        oInsDet.idProducto = oItem.IdProducto;
                        oInsDet.cantidad = oItem.Cantidad;
                        oInsDet.subTotal = oItem.SubTotal;
                        oInsDet.total_detalle = oItem.TotalProducto;
                        oInsDet.igv_detalle = oItem.IgvDet;
                        //oInsDet.descuento = oDetItem.Descuento;
                        oInsDet.usuario_creacion = oComprobante.usuario_creacion;
                        oInsDet.fecha_creacion = DateTime.Now;

                        db.detalleComprobante.Add(oInsDet);
                        db.SaveChanges();
                    }

                    venta oInsVenta = new venta();
                    oInsVenta.idCliente = oComprobante.IdCliente;
                    oInsVenta.idEmpleado = 1;//oComprobante.emple;
                    oInsVenta.idComprobante = oComprobantePago.idComprobante;
                    
                    oInsVenta.usuario_creacion = oComprobante.usuario_creacion;
                    oInsVenta.fecha_creacion = DateTime.Now;

                    db.venta.Add(oInsVenta);
                    db.SaveChanges();

                    oDTOHeader.CodigoRetorno = HeaderEnum.Correcto.ToString();
                    oDTOHeader.DescRetorno = string.Empty;
                    //oDTORespuesta.DTOCliente = oComprobante;

                }
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                oDTOHeader.DescRetorno = ex.Message;
            }
            oDTORespuesta.DTOHeader = oDTOHeader;
            return oDTORespuesta;
        }

        public bool ExportaExcelVentas(List<DTOVenta> lista, HttpResponseBase Response)
        {
            try
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    Byte[] bin;

                    var ws = pck.Workbook.Worksheets.Add("Ventas");
                    string filename = "Reporte_de_ventas"+ DateTime.Now.ToString("ddMMyyyy_Hmmss") + ".xlsx";

                    ws.View.ShowGridLines = false;

                    //CABECERA
                    ws.Cells[2, 2].Value = "COD_VENTA";
                    ws.Cells[2, 3].Value = "CLIENTE";
                    ws.Cells[2, 4].Value = "FECHA";
                    ws.Cells[2, 5].Value = "NRO.COMPROBANTE";
                    ws.Cells[2, 6].Value = "TIPO_COMPROBANTE";
                    ws.Cells[2, 7].Value = "TOTAL";

                    //ANCHO DE COLUMNAS
                    ws.Column(2).Width = 13;
                    ws.Column(3).Width = 40;
                    ws.Column(4).Width = 12;
                    ws.Column(5).Width = 22;
                    ws.Column(6).Width = 22;
                    ws.Column(7).Width = 15;

                    var interno = ws.Cells["B2:G2"];
                    interno.Style.Font.SetFromFont(new Font("Arial", 10));
                    interno.Style.Font.Bold = true;
                    interno.Style.Font.Color.SetColor(Color.White);

                    interno.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    interno.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(48, 84, 150));

                    int i;
                    for (i = 0; i < lista.Count; i++)
                    {
                        if (!(lista[i].IdVenta == 0))
                        {
                            ws.Cells[i + 3, 2].Value = lista[i].IdVenta;
                        }
                        if (!(lista[i].NombreCliente == null))
                        {
                            ws.Cells[i + 3, 3].Value = lista[i].NombreCliente + " " + lista[i].ApePatCliente + " " + lista[i].ApeMatCliente; 
                        }
                        if (!(lista[i].FechaCreacion == null))
                        {
                            ws.Cells[i + 3, 4].Value = ((DateTime)lista[i].FechaCreacion).ToString("dd/MM/yyyy");
                        }
                        if (!(lista[i].NroComprobante == null))
                        {
                            ws.Cells[i + 3, 5].Value = lista[i].NroComprobante;
                        }
                        if (!(lista[i].DescTipoComprobante == null))
                        {
                            ws.Cells[i + 3, 6].Value = lista[i].DescTipoComprobante;
                        }
                        if (!(lista[i].TotalComprobante == null))
                        {
                            ws.Cells[i + 3, 7].Value = lista[i].TotalComprobante;
                        }
                    }

                    interno = ws.Cells["B2:G" + (i + 2).ToString()];
                    interno.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    interno.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    interno.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    interno.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    bin = pck.GetAsByteArray();
                    using (var memoryStream = new MemoryStream())
                    {
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.Buffer = true;
                        Response.ContentType = "application/ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                        Response.BinaryWrite(bin);
                        Response.Flush();
                        Response.End();
                    }
                }

            }
            catch (Exception ex)
            {
                //DataUtil.EscribirLog("ExportaExcelDetEjecucion --> " + ex.ToString());
                return false;
            }

            return true;
        }



    }
}
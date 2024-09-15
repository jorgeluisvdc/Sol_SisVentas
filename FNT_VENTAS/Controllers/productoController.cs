using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FNT_DataModel;

namespace FNT_VENTAS.Controllers
{
    public class productoController : Controller
    {
        private DBSisVentasEntities db = new DBSisVentasEntities();

        // GET: producto
        public ActionResult Index()
        {
            var producto = db.producto.Include(p => p.categoria);
            return View(producto.ToList());
        }

        // GET: producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: producto/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descripcion");
            return View();
        }

        // POST: producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,productoDescripcion,precioUnitario,idCategoria,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descripcion", producto.idCategoria);
            return View(producto);
        }

        // GET: producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descripcion", producto.idCategoria);
            return View(producto);
        }

        // POST: producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,productoDescripcion,precioUnitario,idCategoria,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.categoria, "idCategoria", "descripcion", producto.idCategoria);
            return View(producto);
        }

        // GET: producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            ViewBag.mensaje = "";
            var oInventario = db.inventario.Where(s => s.idProducto == id).ToList();

            if (oInventario.Count > 0 )
            {
                ViewBag.mensaje = "El producto ya tiene inventario";
            }
            else
            {
                var oStock = db.stock.Where(s => s.idProducto == id).ToList();
                if (oStock.Count > 0)
                {
                    ViewBag.mensaje = "El producto ya tiene Stock";
                }
                else
                {
                    var oDetalle = db.detalleComprobante.Where(s => s.idProducto == id).ToList();
                    if (oDetalle.Count > 0)
                    {
                        ViewBag.mensaje = "El producto ya tiene un Comprobante registrado";
                    }
                }
            }
            producto producto = db.producto.Find(id);
            if (ViewBag.mensaje=="")
            {
                db.producto.Remove(producto);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }

            //inventario stock = db.stock.Find(id);



           
            //ViewBag.mensaje = "no";
            

         
           
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

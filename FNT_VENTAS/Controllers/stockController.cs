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
    public class stockController : Controller
    {
        private DBSisVentasEntities db = new DBSisVentasEntities();

        // GET: stock
        public ActionResult Index()
        {
            var stock = db.stock.Include(s => s.producto);
            return View(stock.ToList());
        }

        // GET: stock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: stock/Create
        public ActionResult Create()
        {
            var oProducto = db.producto.AsQueryable();
            var oStock = db.stock.Select(h=> h.idProducto).ToList();

            var oListaProductos = (
                                    from p in oProducto
                                    where !oStock.Contains(p.idProducto)
                                    select p 
                                   ).ToList();


            ViewBag.idProducto = new SelectList(oListaProductos, "idProducto", "productoDescripcion");
            return View();
        }

        // POST: stock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStock,idProducto,stockActual,stockMinimo,stockMaximo,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] stock stock)
        {
            if (ModelState.IsValid)
            {
             

                db.stock.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "productoDescripcion", stock.idProducto);
            return View(stock);
        }

        // GET: stock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "productoDescripcion", stock.idProducto);
            return View(stock);
        }

        // POST: stock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStock,idProducto,stockActual,stockMinimo,stockMaximo,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProducto = new SelectList(db.producto, "idProducto", "productoDescripcion", stock.idProducto);
            return View(stock);
        }

        // GET: stock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock stock = db.stock.Find(id);
            db.stock.Remove(stock);
            db.SaveChanges();
            return RedirectToAction("Index");
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

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
    public class tipoComprobanteController : Controller
    {
        private DBSisVentasEntities db = new DBSisVentasEntities();

        // GET: tipoComprobante
        public ActionResult Index()
        {
            return View(db.tipoComprobante.ToList());
        }

        // GET: tipoComprobante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoComprobante tipoComprobante = db.tipoComprobante.Find(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

        // GET: tipoComprobante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoComprobante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoComprobante,descripcionTipoComprobante,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] tipoComprobante tipoComprobante)
        {
            if (ModelState.IsValid)
            {
                db.tipoComprobante.Add(tipoComprobante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoComprobante);
        }

        // GET: tipoComprobante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoComprobante tipoComprobante = db.tipoComprobante.Find(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

        // POST: tipoComprobante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoComprobante,descripcionTipoComprobante,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] tipoComprobante tipoComprobante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoComprobante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoComprobante);
        }

        // GET: tipoComprobante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoComprobante tipoComprobante = db.tipoComprobante.Find(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

        // POST: tipoComprobante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoComprobante tipoComprobante = db.tipoComprobante.Find(id);
            db.tipoComprobante.Remove(tipoComprobante);
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

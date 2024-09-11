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
    public class tipoPagoController : Controller
    {
        private DBSisVentasEntities db = new DBSisVentasEntities();

        // GET: tipoPago
        public ActionResult Index()
        {
            return View(db.tipoPago.ToList());
        }

        // GET: tipoPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoPago tipoPago = db.tipoPago.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // GET: tipoPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoPago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoPago,descripcion,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] tipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                db.tipoPago.Add(tipoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPago);
        }

        // GET: tipoPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoPago tipoPago = db.tipoPago.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: tipoPago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoPago,descripcion,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] tipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPago);
        }

        // GET: tipoPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoPago tipoPago = db.tipoPago.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: tipoPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoPago tipoPago = db.tipoPago.Find(id);
            db.tipoPago.Remove(tipoPago);
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

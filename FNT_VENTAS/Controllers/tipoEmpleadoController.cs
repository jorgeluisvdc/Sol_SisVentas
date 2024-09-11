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
    public class tipoEmpleadoController : Controller
    {
        private DBSisVentasEntities db = new DBSisVentasEntities();

        // GET: tipoEmpleado
        public ActionResult Index()
        {
            return View(db.tipoEmpleado.ToList());
        }

        // GET: tipoEmpleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // GET: tipoEmpleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoEmpleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoEmpleado,tipoEmpleadoDescripcion,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] tipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.tipoEmpleado.Add(tipoEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEmpleado);
        }

        // GET: tipoEmpleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: tipoEmpleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoEmpleado,tipoEmpleadoDescripcion,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] tipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEmpleado);
        }

        // GET: tipoEmpleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            if (tipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: tipoEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoEmpleado tipoEmpleado = db.tipoEmpleado.Find(id);
            db.tipoEmpleado.Remove(tipoEmpleado);
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

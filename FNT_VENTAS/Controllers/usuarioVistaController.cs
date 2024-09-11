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
    public class usuarioVistaController : Controller
    {
        private DBSisVentasEntities db = new DBSisVentasEntities();

        // GET: usuarioVista
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.empleado);
            return View(usuario.ToList());
        }

        // GET: usuarioVista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarioVista/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "empleadoObservacion");
            return View();
        }

        // POST: usuarioVista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,idEmpleado,nombreUsuario,password,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "empleadoObservacion", usuario.idEmpleado);
            return View(usuario);
        }

        // GET: usuarioVista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "empleadoObservacion", usuario.idEmpleado);
            return View(usuario);
        }

        // POST: usuarioVista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,idEmpleado,nombreUsuario,password,estado,usuario_creacion,fecha_creacion,usuario_modificacion,fecha_modificacion")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "empleadoObservacion", usuario.idEmpleado);
            return View(usuario);
        }

        // GET: usuarioVista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarioVista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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

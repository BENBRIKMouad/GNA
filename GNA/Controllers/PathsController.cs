using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GNA.Models;
using Gna.Data;

namespace GNA.Controllers
{
    public class PathsController : Controller
    {
        private Context db = new Context();

        // GET: Paths
        public ActionResult Index()
        {
            var paths = db.Paths.Include(p => p.Company);
            return View(paths.ToList());
        }

        // GET: Paths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // GET: Paths/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.TransportCompanies, "Id", "Name");
            return View();
        }

        // POST: Paths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FromCity,ToCity,DepartureTime,ArivalTime,Capacity,Price,CompanyId")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Paths.Add(path);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.TransportCompanies, "Id", "Name", path.CompanyId);
            return View(path);
        }

        // GET: Paths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.TransportCompanies, "Id", "Name", path.CompanyId);
            return View(path);
        }

        // POST: Paths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FromCity,ToCity,DepartureTime,ArivalTime,Capacity,Price,CompanyId")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Entry(path).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.TransportCompanies, "Id", "Name", path.CompanyId);
            return View(path);
        }

        // GET: Paths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = db.Paths.Find(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // POST: Paths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Path path = db.Paths.Find(id);
            db.Paths.Remove(path);
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

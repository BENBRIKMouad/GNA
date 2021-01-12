using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GNA.Models;
using Gna.Data;

namespace GNA.Controllers
{
    public class TransportCompanyController : Controller
    {
        private Context db = new Context();
        // GET: TransportCompany
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(TransportCompany transportCompany)
        {
            
            if (ModelState.IsValid)
            {
                bool emailAlredyExist = db.TransportCompanies.Any(c => c.Email == transportCompany.Email);
                if (emailAlredyExist)
                {
                    ModelState.AddModelError("", "Email Already Exists.");
                    return View(transportCompany);
                }
                db.TransportCompanies.Add(transportCompany);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(transportCompany);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] TransportCompany transportCompany) {
            var trouve = db.TransportCompanies.FirstOrDefault(s => s.Email == transportCompany.Email &&
                                                            s.Password == transportCompany.Password);

            if (trouve == null)
            {
                ModelState.AddModelError("", "password or email are incorrect");

                return View(transportCompany);
            }
            Session["user"] = trouve;
            return RedirectToAction("Index", "Home");
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
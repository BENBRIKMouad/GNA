using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool check()
        {
            if (Session["user"] == null)
                return false;
            if (Session["user"].GetType() != typeof(TransportCompany))
                return false;
            return true;
        }
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
        

        public ActionResult AddPath()
        {
            
            return check() ? View() : (ActionResult) RedirectToAction("Index", "Home") ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPath([Bind(Include = "FromCity,ToCity,DepartureTime,ArivalTime,Capacity,Price")]Path path)
        {

            int id = ((TransportCompany)Session["user"]).Id;
            bool exist = db.TransportCompanies.Any(c => c.Id == id);
            if (!check() && !exist)
            {
                return RedirectToAction("Index", "Home");
            }
            path.CompanyId = id;
            if (ModelState.IsValid)
            {
                db.Paths.Add(path);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(path);
            
        }
        
        public ActionResult ListPath()
        {
            int id = check()?((TransportCompany)Session["user"]).Id:0;
            bool exist = db.TransportCompanies.Any(c => c.Id == id);
            if (!exist)
            {
                return RedirectToAction("Index", "Home");
            }
            var paths = db.Paths.Include(p => p.Company).Where(p=>p.CompanyId==id);
            return View(paths.ToList());
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
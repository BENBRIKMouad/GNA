using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gna.Data;
using GNA.Models;

namespace GNA.Controllers
{
    public class ClientsController : Controller
    {
        private Context db = new Context();

        // GET: Clients
        public ActionResult Index()
        {
            //add client page
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Login,Password")] Client client)
        {
            var trouve = db.Clients.FirstOrDefault(s => s.Login == client.Login &&
                                                        s.Password == client.Password);

            if (trouve == null)
            {
                ModelState.AddModelError("", "password or login are incorrect");
                return View(client);
            }
            Session["user"] = trouve;
            Session["userId"] = trouve.Id;

            return RedirectToAction("Index","Home");
        }
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(Client client)
        {
            client.IsSubscribed = false;
            if (ModelState.IsValid)
            {
                bool loginAlredyExist = db.Clients.Any(c => c.Login == client.Login);
                if (loginAlredyExist)
                {
                    ModelState.AddModelError("", "Login Already Exists.");
                    return View(client);
                }
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(client);
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
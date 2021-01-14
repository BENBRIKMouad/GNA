using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
                ModelState.AddModelError("", "Nom d'utilisateur ou Mot de pass incorrect");
                return View(client);
            }
            Session["user"] = trouve;
            Session["userId"] = trouve.Id;

            return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
            }

            return View(client);
        }

        public ActionResult ListPath([Bind(Include = "FromCity,ToCity")] Path path, int? from, int? to)
        {
            if (path.FromCity == null)
            {
                var route = db.Paths.Include(p => p.Company);
                return View(route.ToList());
            }
            var paths = db.Paths.Include(p => p.Company)
                .Where(p => p.FromCity == path.FromCity && p.ToCity == path.ToCity);
            if (from != null)
                paths = paths.Where(p => p.DepartureTime.Hour > from);
            if (to != null)
                paths = paths.Where(p => p.DepartureTime.Hour < to);

            return View(paths.ToList());
        }

        public ActionResult Subscribe(int pathId)
        {
            int id = ((Client)Session["user"])?.Id ?? 0;
            bool exist = db.Clients.Any(c => c.Id == id);
            if (!exist)
                return RedirectToAction("Login");
            Path path = db.Paths.Find(pathId);
            Subscription subscription = new Subscription();
            subscription.ClientId = id;
            subscription.PathId = pathId;
            subscription.Type = 0;
            subscription.Price = path.Price;
            subscription.EndTime = DateTime.Now.AddDays(30);
            db.Subscriptions.Add(subscription);
            db.SaveChanges();

            return RedirectToAction("Succes");
        }

        public ActionResult Succes()
        {
            return View();
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
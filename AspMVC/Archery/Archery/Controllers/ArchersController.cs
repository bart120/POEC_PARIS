using Archery.Areas.BackOffice.Models;
using Archery.Data;
using Archery.Filters;
using Archery.Models;
using Archery.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class ArchersController : BaseController
    {


        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe([Bind(Exclude = "ID")]Archer archer)
        {
            /*if(DateTime.Now.AddYears(-9) <= archer.BirthDate)
            {
                //ViewBag.Erreur = "Date de naissance invalide";
                //return View();
                ModelState.AddModelError("BirthDate", "Date de naissance invalide");
            }*/

            if (ModelState.IsValid)
            {
                //archer.Password = Extension.HashMD5(archer.Password);
                archer.Password = archer.Password.HashMD5();

                db.Configuration.ValidateOnSaveEnabled = false;
                db.Archers.Add(archer);
                db.SaveChanges();

                db.Configuration.ValidateOnSaveEnabled = true;
                //TempData["Message"] = "Archer enregistré";
                Display("Archer enregistré");

                return RedirectToAction("index", "home");
            }

            return View();
        }

        [HttpGet]
        //[ArcherAuthentication]
        [Authentication(Type="ARCHER")]
        public ActionResult SubscribeTournament(int? tournamentId)
        {
            if (tournamentId == null)
                return HttpNotFound();
            ViewBag.Tournament = db.Tournaments.Find(tournamentId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication(Type = "ARCHER")]
        public ActionResult SubscribeTournament(Shooter model)
        {
            model.ArcherID = ((Archer)Session["ARCHER"]).ID;
            if (ModelState.IsValid)
            {
                db.Shooters.Add(model);
                db.SaveChanges();
            }
            ViewBag.Tournament = db.Tournaments.Find(model.TournamentID);
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
             var hash = model.Password.HashMD5();
            var archer = db.Archers.SingleOrDefault(x => x.Mail == model.Mail && x.Password == hash);
            if (archer == null)
            {
                Display("Login/mot de passe incorrect", MessageType.ERROR);
                return View();
            }
            else
            {
                Session["ARCHER"] = archer;
                if (TempData["REDIRECT"] != null)
                    return Redirect(TempData["REDIRECT"].ToString());
                else
                    return RedirectToAction("index", "home");
            }

        }

        [Authentication(Type = "ARCHER")]
        public ActionResult Logout()
        {
            Session.Remove("ARCHER");
            return RedirectToAction("index", "home");
        }

    }
}
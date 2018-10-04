using Archery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Title"] = "Accueil";
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Tournaments = db.Tournaments.Include("Weapons")
                                              .Where(x => x.StartDate >= DateTime.Now)
                                              .OrderBy(x => x.StartDate)
                                              .Take(20);
            return View(model);
        }

        //[Route("a-propos")]
        public ActionResult About()
        {
            var modelInfo = new Info
            {
                DevName = "Vincent",
                ContactMail = "vincent@vincent.com",
                CreatedDate = DateTime.Now
            };
            return View(modelInfo);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }
    }
}
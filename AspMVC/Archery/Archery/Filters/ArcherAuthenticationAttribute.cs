using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Filters
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ArcherAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["ARCHER"] == null)
            {
                filterContext.Controller.TempData["REDIRECT"] = filterContext.HttpContext.Request.Url.AbsoluteUri;
                filterContext.Result = new RedirectResult(@"\archers\login");                
            }
        }
    }
}
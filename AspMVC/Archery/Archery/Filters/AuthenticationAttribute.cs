using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public string Type { get; set; } = "BO";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if(Type == "ARCHER")
            {
                if (filterContext.HttpContext.Session["ARCHER"] == null)
                {
                    filterContext.Controller.TempData["REDIRECT"] = filterContext.HttpContext.Request.Url.AbsoluteUri;
                    filterContext.Result = new RedirectResult(@"\archers\login");
                }
            }

            if (Type == "BO")
            {
                if (filterContext.HttpContext.Session["ADMINISTRATOR"] == null)
                {
                    filterContext.Result = new RedirectResult(@"\backoffice\authentication\login");
                    //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new{ controller="authentication", action= "login", area="backoffice" }));
                }
            }
        }
    }
}
using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class 本機測試Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.HttpContext.Request.IsLocal)
                filterContext.Result = new RedirectResult("/");
        }

    }
}
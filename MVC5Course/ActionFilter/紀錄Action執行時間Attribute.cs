using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class 紀錄Action執行時間Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewBag.StartTime = DateTime.Now;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.EndTime = DateTime.Now;
            filterContext.Controller.ViewBag.RunTime = filterContext.Controller.ViewBag.EndTime- filterContext.Controller.ViewBag.StartTime;
        }
    }
}
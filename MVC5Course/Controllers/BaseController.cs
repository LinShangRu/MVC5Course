using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        public ProductRepository db = RepositoryHelper.GetProductRepository();

        //[Authorize]
        //public virtual ActionResult Index(string SortBy, string Keyword, int PageNo = 1)
        //{
        //    return this.View(this.ControllerContext);
        //}

        protected override void HandleUnknownAction(string actionName)
        {
            //this.View("Index").ExecuteResult(this.ControllerContext);
            this.Redirect("/").ExecuteResult(this.ControllerContext);

            //base.HandleUnknownAction(actionName);
        }
    }
}
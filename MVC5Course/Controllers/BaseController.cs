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

        protected override void HandleUnknownAction(string actionName)
        {
            //this.View("Index").ExecuteResult(this.ControllerContext);
            this.Redirect("/").ExecuteResult(this.ControllerContext);

            //base.HandleUnknownAction(actionName);
        }
    }
}
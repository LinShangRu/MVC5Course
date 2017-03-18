using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page!!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Home-Test";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return Redirect("Index");
            //return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel LoginData,string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                FormsAuthentication.RedirectFromLoginPage(LoginData.UserName, false);
                TempData["LoginData1"] = LoginData;
                if (ReturnUrl != null && ReturnUrl.Length > 0 && ReturnUrl.StartsWith("/"))
                {
                    
                    return Redirect(ReturnUrl);
                }
                else
                    return Redirect("Index");
                //return Content(LoginData.UserName + ":" + LoginData.Password);
            }
            return Redirect("Index");
        }
    }
}
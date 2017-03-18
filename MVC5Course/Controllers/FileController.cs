using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult File1()
        {
            return File(Server.MapPath(@"~\Content\Image.jpg"), "image/jpeg");
        }

        public ActionResult File2()
        {
            return File(Server.MapPath(@"~\Content\Image.jpg"), "image/jpeg","Downlaod.jpg");
        }

        public ActionResult File3(string ShowType)
        {
            if(string.IsNullOrEmpty(ShowType))
            {
                return View();
            }
            else if(ShowType.Equals("image"))
            {
                return File(Server.MapPath(@"~\Content\Image.jpg"), "image/jpeg");
            }
            else
            {
                return File(Server.MapPath(@"~\Content\Image.jpg"), "image/jpeg", "Downlaod.jpg");
            }
        }

    }
}
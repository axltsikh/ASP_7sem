using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThirdLab.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string errorCode)
        {
            string desc = "";
            if (errorCode == "4040")
            {
                desc = "Вы пытаетесь взаимдоействовать с несуществующей записью";
            }
            ViewBag.Error = desc;
            return View();
        }
    }
}
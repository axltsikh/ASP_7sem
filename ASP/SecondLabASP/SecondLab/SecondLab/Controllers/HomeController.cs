using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondLab.Utility;

namespace SecondLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetResult()
        {
            if (Utils.addValues.Count > 0)
            {
                ViewBag.ResultValue = Utils.result + Utils.addValues.Peek();
            }
            else
            {
                ViewBag.ResultValue = Utils.result;
            }
            return Json(ViewBag.ResultValue,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult PostResult(int RESULT)
        {
            Utils.result += RESULT;
            ViewBag.IncreasedBy = RESULT;
            return PartialView("PostPartialView");
        }
        [HttpPut]
        public ActionResult PutResult(int ADD)
        {
            Utils.addValues.Push(ADD);
            ViewBag.AddedElement = ADD;
            return PartialView("PutPartialView");
        }
        [HttpDelete]
        public ActionResult DeleteResult()
        {
            int buffer = 0;
            if (Utils.addValues.Count > 0)
            {
                buffer=1;
                Utils.addValues.Pop();
            }
            ViewBag.DeletedElements = buffer;
            return PartialView("DeletePartialView");
        }
    }
}
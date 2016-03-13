using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Models
{
    public class ARController : Controller
    {

        FabricsEntities db = new FabricsEntities();
        // GET: AR
        public ActionResult FileTest()
        {
            return File("~/Content/alphago.png",
                "image/png");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JsonTest()
        {
            
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(3);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}
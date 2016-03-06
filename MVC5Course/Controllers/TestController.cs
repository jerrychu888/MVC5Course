using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult TestIndex()
        {
            return View();
        }

        //code snippest : mvcactino4
        public ActionResult MemberProfile()
        {
            return View();
        }

        //code snippest : mvcp
        [HttpPost]
        public ActionResult MemberProfile(MemberViewModel data)
        {
            return View();
        }
    }
}
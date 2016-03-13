using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        [AllowAnonymous] //允許未登入使用此action
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginData)
        {
            if (checkLogin(loginData.Email, loginData.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(loginData.Email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤");
                return View();
            }
        }

        private bool checkLogin(string email, string password)
        {
            if (email == "jerrychu@champin.com" && password == "1234")
                return true;
            else {
                ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤");
                return false;
            }
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
        // GET: Test
        public ActionResult Registe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string FirstName,string MiddleName,string LastName, string Gender)
        {
            return Content("FirstName=" + FirstName + "MiddleName=" + MiddleName + "LastName=" + LastName + "Gender=" + Gender);
        }

        
    }
}
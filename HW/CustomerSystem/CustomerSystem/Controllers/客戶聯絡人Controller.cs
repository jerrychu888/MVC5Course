using CustomerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerSystem.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        CustomerEntities db = new CustomerEntities();
        // GET: 客戶聯絡人
        /*
        public ActionResult Index()
        {
            var data = db.客戶聯絡人;
            return View(data.ToList());
        }
        */
        //[ActionName("Index")]
        public ActionResult Index(int? id)
        {
            List<客戶聯絡人> data = null;

            if (id != null)
                data = db.客戶聯絡人.Where(p => p.客戶Id == id).ToList() ;
            else
                data = db.客戶聯絡人.ToList();
            return View(data);
        }
        
        public ActionResult Create()
        {
            return View();
            
        }

        public ActionResult CreateData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateData([Bind(Include = "客戶Id,職稱,姓名,電話,手機,Email")] 客戶聯絡人 客戶聯絡人)
        {
            db.客戶聯絡人.Add(客戶聯絡人);
            db.SaveChanges();
            //return View("Index"); 直接return , 需要自己帶data參數給他?
            return RedirectToAction("Index");
        }


        public ActionResult EditData(int id)
        {
            var data = db.客戶聯絡人.Find(id);
            return View(data);

        }

        [HttpPost]
        public ActionResult EditData([Bind(Include = "Id,客戶Id,職稱,姓名,電話,手機,Email")] 客戶聯絡人 客戶聯絡人)
        {
            try {
                var data = (from c in db.客戶聯絡人 where c.Id == 客戶聯絡人.Id select c).SingleOrDefault();
                
                //data = 客戶聯絡人;  why not??
                data.姓名 = 客戶聯絡人.姓名;
                data.職稱 = 客戶聯絡人.職稱;
                data.電話 = 客戶聯絡人.電話;
                data.手機 = 客戶聯絡人.手機;
                data.Email = 客戶聯絡人.Email;
                data.客戶Id = 客戶聯絡人.客戶Id;
                //is there any better way?
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return RedirectToAction("EditData");
        }

        public ActionResult DeleteData(int id)
        {
            var data = db.客戶聯絡人.Find(id);
            if (data != null)
            {
                db.客戶聯絡人.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewDetail(int id)
        {
            var data = db.客戶聯絡人.Where(p => p.Id == id).FirstOrDefault();
            return View(data);
        }
    }
}
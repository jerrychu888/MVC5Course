using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVC5Course.Models
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        /*
        // GET: EF
        public ActionResult Index()
        {

            db.Product.Add(new Product()
            {
                ProductName = "Prada Bag+",
                //Price = 99999, //故意讓他錯 
                Price = 999,  
                Stock = 99,
                Active = true
            });


            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach(DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;
                    foreach (var err in item.ValidationErrors)
                    {
                        throw new Exception(entityName + " " + err.ErrorMessage);
                    }
                }
                throw;
            }
            var data = db.Product.ToList();
            return View(data);
        }
        */
        public ActionResult Index(string keyword)
        {
            var products = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();
            if (!String.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.ProductName.Contains(keyword));
            }
            
            return View(products);
        }
        public ActionResult Detail(int id)
        {
            var data = db.Product.Find(id);
            // p是變數的意思
            var data2 = db.Product.First(p => p.ProductId == id);
            // 上面想法(大概...)
            //var data22 = db.Product.First(Product myfind(int p){
                // 尋找到第一筆ProuductID= p者並回傳 
            //});
            var data3 = db.Product.SingleOrDefault(p => p.ProductId == id);
            //以上都是同樣的意思

            return View(data3);
        }

        public ActionResult Delete(int id)
        {
            Product item = db.Product.Find(id); 
            db.OrderLine.RemoveRange(item.OrderLine); //item.OrderLine => 導覽屬性
            db.Product.Remove(item);  //要先刪掉Foreign KEY 才能刪

            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");

           
        }

        public ActionResult QueryPlan()
        {
            var data = db.Product.Include(s => s.OrderLine).ToList();
            return View(data);
        }
    }

    
}
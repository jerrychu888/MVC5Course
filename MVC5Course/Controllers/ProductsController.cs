using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : Controller
    {
        //private FabricsEntities db = new FabricsEntities();
        ProductRepository repo = RepositoryHelper.GetProductRepository();
        
        // GET: Products
        [計算action執行時間]
        public ActionResult Index(int? id,bool? isActive , string keyword)
        {
            //return View(db.Product.ToList());
            if (id.HasValue)
            {
                ViewBag.id = id;
            }
            //return View(repo.All().Take(5).ToList());
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Active", Value = "true" });
            items.Add(new SelectListItem() { Text = "inActive", Value = "false" });
            ViewData["isActive"] = new SelectList(items,"Value","Text");

            var data = repo.All(true);

            if (isActive.HasValue)
            {
                data = data.Where(p => p.Active == isActive.Value).Take(20);
            }

            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }
            
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(IList<批次更新的class> data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var Product = repo.Find(item.ProductId);
                    Product.Price = item.Price;
                    Product.Stock = item.Stock;
                    Product.Active = item.Active;
                    repo.UnitOfWork.Commit();
                }
                return RedirectToAction("Index");
            }
            return View(repo.All().Take(5));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Product.Add(product);
                repo.Add(product);
                //db.SaveChanges();
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        /*
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                ((FabricsEntities)repo.UnitOfWork.Context).Entry(product).State = EntityState.Modified;
                repo.UnitOfWork.Commit();
                TempData["SuccessfulMessage"] = "修改成功";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        */
        [HttpPost]
        public ActionResult Edit(int id , FormCollection form)
        {
            Product product = repo.Find(id);
            if(TryUpdateModel<Product>(product,new string[] {
            "ProductId","ProductName","Price","Active","Stock"}
            ))
            {
                repo.UnitOfWork.Commit();
            }
            return View();

        }


        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Find(id);
            product.isDelete = true;
            repo.UnitOfWork.Commit();
            //db.Product.Remove(product);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowDetail(int id)
        {
            
            return RedirectToAction("Index",new { id = id });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = (FabricsEntities)repo.UnitOfWork.Context;
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

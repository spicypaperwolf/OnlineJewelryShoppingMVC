using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineJewelryShoppingMVC;
using PagedList;
using PagedList.Mvc;

namespace OnlineJewelryShoppingMVC.Areas.Admin.Controllers
{
    public class ProductMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/ProductMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from x in db.ProductMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.prodType.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/ProductMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMst productMst = db.ProductMsts.Find(id);
            if (productMst == null)
            {
                return HttpNotFound();
            }
            return View(productMst);
        }

        // GET: Admin/ProductMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prodId,prodType")] ProductMst productMst)
        {
            if (ModelState.IsValid)
            {
                db.ProductMsts.Add(productMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productMst);
        }

        // GET: Admin/ProductMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMst productMst = db.ProductMsts.Find(id);
            if (productMst == null)
            {
                return HttpNotFound();
            }
            return View(productMst);
        }

        // POST: Admin/ProductMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prodId,prodType")] ProductMst productMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productMst);
        }

        // GET: Admin/ProductMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMst productMst = db.ProductMsts.Find(id);
            if (productMst == null)
            {
                return HttpNotFound();
            }
            return View(productMst);
        }

        // POST: Admin/ProductMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProductMst productMst = db.ProductMsts.Find(id);
            db.ProductMsts.Remove(productMst);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

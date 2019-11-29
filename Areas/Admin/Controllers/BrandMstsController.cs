using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineJewelryShoppingMVC;
using OnlineJewelryShoppingMVC.Interceptor;
using PagedList;
using PagedList.Mvc;

namespace OnlineJewelryShoppingMVC.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class BrandMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/BrandMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.BrandMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.brandType.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/BrandMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandMst brandMst = db.BrandMsts.Find(id);
            if (brandMst == null)
            {
                return HttpNotFound();
            }
            return View(brandMst);
        }

        // GET: Admin/BrandMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BrandMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "brandId,brandType")] BrandMst brandMst)
        {
            if (ModelState.IsValid)
            {
                db.BrandMsts.Add(brandMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brandMst);
        }

        // GET: Admin/BrandMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandMst brandMst = db.BrandMsts.Find(id);
            if (brandMst == null)
            {
                return HttpNotFound();
            }
            return View(brandMst);
        }

        // POST: Admin/BrandMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "brandId,brandType")] BrandMst brandMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brandMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brandMst);
        }

        // GET: Admin/BrandMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandMst brandMst = db.BrandMsts.Find(id);
            if (brandMst == null)
            {
                return HttpNotFound();
            }
            return View(brandMst);
        }

        // POST: Admin/BrandMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BrandMst brandMst = db.BrandMsts.Find(id);
            db.BrandMsts.Remove(brandMst);
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

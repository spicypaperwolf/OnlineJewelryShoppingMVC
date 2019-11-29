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
    public class CategoryMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/CategoryMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.CategoryMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.catName.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/CategoryMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            if (categoryMst == null)
            {
                return HttpNotFound();
            }
            return View(categoryMst);
        }

        // GET: Admin/CategoryMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "catId,catName")] CategoryMst categoryMst)
        {
            if (ModelState.IsValid)
            {
                db.CategoryMsts.Add(categoryMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryMst);
        }

        // GET: Admin/CategoryMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            if (categoryMst == null)
            {
                return HttpNotFound();
            }
            return View(categoryMst);
        }

        // POST: Admin/CategoryMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "catId,catName")] CategoryMst categoryMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryMst);
        }

        // GET: Admin/CategoryMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            if (categoryMst == null)
            {
                return HttpNotFound();
            }
            return View(categoryMst);
        }

        // POST: Admin/CategoryMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CategoryMst categoryMst = db.CategoryMsts.Find(id);
            db.CategoryMsts.Remove(categoryMst);
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

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
    public class AdminLoginMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/AdminLoginMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from x in db.AdminLoginMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.username.Contains(searchString) || x.password.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/AdminLoginMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLoginMst adminLoginMst = db.AdminLoginMsts.Find(id);
            if (adminLoginMst == null)
            {
                return HttpNotFound();
            }
            return View(adminLoginMst);
        }

        // GET: Admin/AdminLoginMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLoginMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,password")] AdminLoginMst adminLoginMst)
        {
            if (ModelState.IsValid)
            {
                db.AdminLoginMsts.Add(adminLoginMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminLoginMst);
        }

        // GET: Admin/AdminLoginMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLoginMst adminLoginMst = db.AdminLoginMsts.Find(id);
            if (adminLoginMst == null)
            {
                return HttpNotFound();
            }
            return View(adminLoginMst);
        }

        // POST: Admin/AdminLoginMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,password")] AdminLoginMst adminLoginMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminLoginMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminLoginMst);
        }

        // GET: Admin/AdminLoginMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLoginMst adminLoginMst = db.AdminLoginMsts.Find(id);
            if (adminLoginMst == null)
            {
                return HttpNotFound();
            }
            return View(adminLoginMst);
        }

        // POST: Admin/AdminLoginMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminLoginMst adminLoginMst = db.AdminLoginMsts.Find(id);
            db.AdminLoginMsts.Remove(adminLoginMst);
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

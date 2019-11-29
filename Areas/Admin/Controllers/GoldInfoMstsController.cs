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
    public class GoldInfoMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/GoldInfoMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.GoldInfoMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.goldType.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/GoldInfoMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoldInfoMst goldInfoMst = db.GoldInfoMsts.Find(id);
            if (goldInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(goldInfoMst);
        }

        // GET: Admin/GoldInfoMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GoldInfoMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "goldId,goldCrt,goldType,goldRate")] GoldInfoMst goldInfoMst)
        {
            if (ModelState.IsValid)
            {
                db.GoldInfoMsts.Add(goldInfoMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goldInfoMst);
        }

        // GET: Admin/GoldInfoMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoldInfoMst goldInfoMst = db.GoldInfoMsts.Find(id);
            if (goldInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(goldInfoMst);
        }

        // POST: Admin/GoldInfoMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "goldId,goldCrt,goldType,goldRate")] GoldInfoMst goldInfoMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goldInfoMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goldInfoMst);
        }

        // GET: Admin/GoldInfoMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoldInfoMst goldInfoMst = db.GoldInfoMsts.Find(id);
            if (goldInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(goldInfoMst);
        }

        // POST: Admin/GoldInfoMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GoldInfoMst goldInfoMst = db.GoldInfoMsts.Find(id);
            db.GoldInfoMsts.Remove(goldInfoMst);
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

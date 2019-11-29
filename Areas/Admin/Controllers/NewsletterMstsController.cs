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
    public class NewsletterMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/NewsletterMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.NewsletterMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.newsletterEmail.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/NewsletterMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterMst newsletterMst = db.NewsletterMsts.Find(id);
            if (newsletterMst == null)
            {
                return HttpNotFound();
            }
            return View(newsletterMst);
        }

        // GET: Admin/NewsletterMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsletterMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "newsletterId,newsletterEmail")] NewsletterMst newsletterMst)
        {
            if (ModelState.IsValid)
            {
                db.NewsletterMsts.Add(newsletterMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsletterMst);
        }

        // GET: Admin/NewsletterMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterMst newsletterMst = db.NewsletterMsts.Find(id);
            if (newsletterMst == null)
            {
                return HttpNotFound();
            }
            return View(newsletterMst);
        }

        // POST: Admin/NewsletterMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "newsletterId,newsletterEmail")] NewsletterMst newsletterMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsletterMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsletterMst);
        }

        // GET: Admin/NewsletterMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterMst newsletterMst = db.NewsletterMsts.Find(id);
            if (newsletterMst == null)
            {
                return HttpNotFound();
            }
            return View(newsletterMst);
        }

        // POST: Admin/NewsletterMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsletterMst newsletterMst = db.NewsletterMsts.Find(id);
            db.NewsletterMsts.Remove(newsletterMst);
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

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
    public class ContactMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/ContactMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.ContactMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.contactName.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }


        // GET: Admin/ContactMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMst contactMst = db.ContactMsts.Find(id);
            if (contactMst == null)
            {
                return HttpNotFound();
            }
            return View(contactMst);
        }

        // GET: Admin/ContactMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "contactId,contactName,contactMob,contactEmail,contactSubject,contactMessage")] ContactMst contactMst)
        {
            if (ModelState.IsValid)
            {
                db.ContactMsts.Add(contactMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactMst);
        }

        // GET: Admin/ContactMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMst contactMst = db.ContactMsts.Find(id);
            if (contactMst == null)
            {
                return HttpNotFound();
            }
            return View(contactMst);
        }

        // POST: Admin/ContactMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "contactId,contactName,contactMob,contactEmail,contactSubject,contactMessage")] ContactMst contactMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactMst);
        }

        // GET: Admin/ContactMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMst contactMst = db.ContactMsts.Find(id);
            if (contactMst == null)
            {
                return HttpNotFound();
            }
            return View(contactMst);
        }

        // POST: Admin/ContactMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactMst contactMst = db.ContactMsts.Find(id);
            db.ContactMsts.Remove(contactMst);
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

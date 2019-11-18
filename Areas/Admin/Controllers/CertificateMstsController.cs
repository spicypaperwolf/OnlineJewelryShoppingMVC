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
    public class CertificateMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/CertificateMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.CertificateMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.certificateType.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/CertificateMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificateMst certificateMst = db.CertificateMsts.Find(id);
            if (certificateMst == null)
            {
                return HttpNotFound();
            }
            return View(certificateMst);
        }

        // GET: Admin/CertificateMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CertificateMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "certificateId,certificateType")] CertificateMst certificateMst)
        {
            if (ModelState.IsValid)
            {
                db.CertificateMsts.Add(certificateMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(certificateMst);
        }

        // GET: Admin/CertificateMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificateMst certificateMst = db.CertificateMsts.Find(id);
            if (certificateMst == null)
            {
                return HttpNotFound();
            }
            return View(certificateMst);
        }

        // POST: Admin/CertificateMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "certificateId,certificateType")] CertificateMst certificateMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificateMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(certificateMst);
        }

        // GET: Admin/CertificateMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificateMst certificateMst = db.CertificateMsts.Find(id);
            if (certificateMst == null)
            {
                return HttpNotFound();
            }
            return View(certificateMst);
        }

        // POST: Admin/CertificateMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CertificateMst certificateMst = db.CertificateMsts.Find(id);
            db.CertificateMsts.Remove(certificateMst);
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

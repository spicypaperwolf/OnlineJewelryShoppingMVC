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
    public class TransactionMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/TransactionMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from x in db.TransactionMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.userId.ToString().Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/TransactionMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionMst transactionMst = db.TransactionMsts.Find(id);
            if (transactionMst == null)
            {
                return HttpNotFound();
            }
            return View(transactionMst);
        }

        // GET: Admin/TransactionMsts/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userId");
            return View();
        }

        // POST: Admin/TransactionMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transactionId,userId,totPrice,totQty,approvalStt")] TransactionMst transactionMst)
        {
            if (ModelState.IsValid)
            {
                db.TransactionMsts.Add(transactionMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userId", transactionMst.userId);
            return View(transactionMst);
        }

        // GET: Admin/TransactionMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionMst transactionMst = db.TransactionMsts.Find(id);
            if (transactionMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userId", transactionMst.userId);
            return View(transactionMst);
        }

        // POST: Admin/TransactionMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transactionId,userId,totPrice,totQty,approvalStt")] TransactionMst transactionMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userId", transactionMst.userId);
            return View(transactionMst);
        }

        // GET: Admin/TransactionMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionMst transactionMst = db.TransactionMsts.Find(id);
            if (transactionMst == null)
            {
                return HttpNotFound();
            }
            return View(transactionMst);
        }

        // POST: Admin/TransactionMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TransactionMst transactionMst = db.TransactionMsts.Find(id);
            db.TransactionMsts.Remove(transactionMst);
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

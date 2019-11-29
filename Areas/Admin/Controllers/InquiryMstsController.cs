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
    public class InquiryMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/InquiryMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.InquiryMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.fname.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/InquiryMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryMst inquiryMst = db.InquiryMsts.Find(id);
            if (inquiryMst == null)
            {
                return HttpNotFound();
            }
            return View(inquiryMst);
        }

        // GET: Admin/InquiryMsts/Create
        public ActionResult Create()
        {
            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId");
            return View();
        }

        // POST: Admin/InquiryMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inquiryID,transactionId,fname,lname,address,city,mobNo,emailId,cmt,cdate,cardNo,expdate,CVV_No")] InquiryMst inquiryMst)
        {
            if (ModelState.IsValid)
            {
                db.InquiryMsts.Add(inquiryMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId", inquiryMst.transactionId);
            return View(inquiryMst);
        }

        // GET: Admin/InquiryMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryMst inquiryMst = db.InquiryMsts.Find(id);
            if (inquiryMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId", inquiryMst.transactionId);
            return View(inquiryMst);
        }

        // POST: Admin/InquiryMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inquiryID,transactionId,fname,lname,address,city,mobNo,emailId,cmt,cdate,cardNo,expdate,CVV_No")] InquiryMst inquiryMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inquiryMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId", inquiryMst.transactionId);
            return View(inquiryMst);
        }

        // GET: Admin/InquiryMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InquiryMst inquiryMst = db.InquiryMsts.Find(id);
            if (inquiryMst == null)
            {
                return HttpNotFound();
            }
            return View(inquiryMst);
        }

        // POST: Admin/InquiryMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InquiryMst inquiryMst = db.InquiryMsts.Find(id);
            db.InquiryMsts.Remove(inquiryMst);
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

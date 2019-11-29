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
    public class CartListsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/CartLists
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.CartLists select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.itemCode.Contains(searchString));
            }
            return View(item.ToList().OrderByDescending(c => c.transactionId).ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/CartLists/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartList cartList = db.CartLists.Find(id);
            if (cartList == null)
            {
                return HttpNotFound();
            }
            return View(cartList);
        }

        // GET: Admin/CartLists/Create
        public ActionResult Create()
        {
            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "itemCode");
            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId");
            return View();
        }

        // POST: Admin/CartLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cartId,transactionId,itemCode,qty,price")] CartList cartList)
        {
            if (ModelState.IsValid)
            {
                db.CartLists.Add(cartList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "itemCode", cartList.itemCode);
            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId", cartList.transactionId);
            return View(cartList);
        }

        // GET: Admin/CartLists/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartList cartList = db.CartLists.Find(id);
            if (cartList == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "itemCode", cartList.itemCode);
            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId", cartList.transactionId);
            return View(cartList);
        }

        // POST: Admin/CartLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cartId,transactionId,itemCode,qty,price")] CartList cartList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "itemCode", cartList.itemCode);
            ViewBag.transactionId = new SelectList(db.TransactionMsts, "transactionId", "transactionId", cartList.transactionId);
            return View(cartList);
        }

        // GET: Admin/CartLists/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartList cartList = db.CartLists.Find(id);
            if (cartList == null)
            {
                return HttpNotFound();
            }
            return View(cartList);
        }

        // POST: Admin/CartLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CartList cartList = db.CartLists.Find(id);
            db.CartLists.Remove(cartList);
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

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
    public class CommentMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/CommentMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from y in db.CommentMsts select y;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(y => y.cmtContent.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }


        // GET: Admin/CommentMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentMst commentMst = db.CommentMsts.Find(id);
            if (commentMst == null)
            {
                return HttpNotFound();
            }
            return View(commentMst);
        }

        // GET: Admin/CommentMsts/Create
        public ActionResult Create()
        {
            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "brandId");
            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userFname");
            return View();
        }

        // POST: Admin/CommentMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cmtId,userId,itemCode,cmtContent,ratingValue")] CommentMst commentMst)
        {
            if (ModelState.IsValid)
            {
                db.CommentMsts.Add(commentMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "brandId", commentMst.itemCode);
            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userFname", commentMst.userId);
            return View(commentMst);
        }

        // GET: Admin/CommentMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentMst commentMst = db.CommentMsts.Find(id);
            if (commentMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "brandId", commentMst.itemCode);
            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userFname", commentMst.userId);
            return View(commentMst);
        }

        // POST: Admin/CommentMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cmtId,userId,itemCode,cmtContent,ratingValue")] CommentMst commentMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemCode = new SelectList(db.ItemMsts, "itemCode", "brandId", commentMst.itemCode);
            ViewBag.userId = new SelectList(db.UserRegMsts, "userId", "userFname", commentMst.userId);
            return View(commentMst);
        }

        // GET: Admin/CommentMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentMst commentMst = db.CommentMsts.Find(id);
            if (commentMst == null)
            {
                return HttpNotFound();
            }
            return View(commentMst);
        }

        // POST: Admin/CommentMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentMst commentMst = db.CommentMsts.Find(id);
            db.CommentMsts.Remove(commentMst);
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

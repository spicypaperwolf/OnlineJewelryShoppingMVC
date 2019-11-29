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
    public class BlogMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/BlogMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from x in db.BlogMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.blogTitle.Contains(searchString) || x.blogContent.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/BlogMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogMst blogMst = db.BlogMsts.Find(id);
            if (blogMst == null)
            {
                return HttpNotFound();
            }
            return View(blogMst);
        }

        // GET: Admin/BlogMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "blogId,blogImg,blogTitle,blogContent,cdate")] BlogMst blogMst)
        {
            if (ModelState.IsValid)
            {
                db.BlogMsts.Add(blogMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogMst);
        }

        // GET: Admin/BlogMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogMst blogMst = db.BlogMsts.Find(id);
            if (blogMst == null)
            {
                return HttpNotFound();
            }
            return View(blogMst);
        }

        // POST: Admin/BlogMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "blogId,blogImg,blogTitle,blogContent,cdate")] BlogMst blogMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogMst);
        }

        // GET: Admin/BlogMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogMst blogMst = db.BlogMsts.Find(id);
            if (blogMst == null)
            {
                return HttpNotFound();
            }
            return View(blogMst);
        }

        // POST: Admin/BlogMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogMst blogMst = db.BlogMsts.Find(id);
            db.BlogMsts.Remove(blogMst);
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

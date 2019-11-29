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
    public class UserRegMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/UserRegMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from x in db.UserRegMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.userFname.Contains(searchString) || x.emailId.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));

        }

        // GET: Admin/UserRegMsts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            if (userRegMst == null)
            {
                return HttpNotFound();
            }
            return View(userRegMst);
        }

        // GET: Admin/UserRegMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserRegMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,userFname,userLname,address,city,state,mobNo,emailId,dob,password,status")] UserRegMst userRegMst)
        {
            if (ModelState.IsValid)
            {
                userRegMst.status = true;
                userRegMst.cdate = DateTime.Now;
                db.UserRegMsts.Add(userRegMst);
                if (db.UserRegMsts.Where(item => item.emailId == userRegMst.emailId).FirstOrDefault() != null)
                {
                    ViewBag.ExistsEmail = "Email is already exists";
                    return View("Login");
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRegMst);
        }

        // GET: Admin/UserRegMsts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            if (userRegMst == null)
            {
                return HttpNotFound();
            }
            return View(userRegMst);
        }

        // POST: Admin/UserRegMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userFname,userLname,address,city,state,mobNo,emailId,dob,cdate,password,status")] UserRegMst userRegMst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRegMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRegMst);
        }

        // GET: Admin/UserRegMsts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            if (userRegMst == null)
            {
                return HttpNotFound();
            }
            return View(userRegMst);
        }

        // POST: Admin/UserRegMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRegMst userRegMst = db.UserRegMsts.Find(id);
            db.UserRegMsts.Remove(userRegMst);
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

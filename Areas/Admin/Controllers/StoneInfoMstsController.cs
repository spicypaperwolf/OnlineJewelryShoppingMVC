using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineJewelryShoppingMVC;
using PagedList;
using PagedList.Mvc;

namespace OnlineJewelryShoppingMVC.Areas.Admin.Controllers
{
    public class StoneInfoMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/StoneInfoMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from x in db.StoneInfoMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.stoneImg.Contains(searchString) || x.stoneColor.Contains(searchString)|| x.stoneShape.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Admin/StoneInfoMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoneInfoMst stoneInfoMst = db.StoneInfoMsts.Find(id);
            if (stoneInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(stoneInfoMst);
        }

        // GET: Admin/StoneInfoMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/StoneInfoMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stoneId,stoneShape,stoneCrt,stoneColor,stoneRate,stoneImg")] StoneInfoMst stoneInfoMst, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                int index = 0;
                foreach (HttpPostedFileBase file in files)
                {
                    index++;
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        if (files.Length != index)
                        {
                            stoneInfoMst.stoneImg += file.FileName + ", ";

                        }
                        else
                        {
                            stoneInfoMst.stoneImg += file.FileName;
                        }
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/assets/image/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                    }
                }//end of insert image
                db.StoneInfoMsts.Add(stoneInfoMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stoneInfoMst);
        }

        // GET: Admin/StoneInfoMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoneInfoMst stoneInfoMst = db.StoneInfoMsts.Find(id);
            if (stoneInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(stoneInfoMst);
        }

        // POST: Admin/StoneInfoMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stoneId,stoneShape,stoneCrt,stoneColor,stoneRate,stoneImg")] StoneInfoMst stoneInfoMst, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                int index = 0;
                foreach (HttpPostedFileBase file in files)
                {
                    index++;
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        if (files.Length != index)
                        {
                            stoneInfoMst.stoneImg += file.FileName + ", ";

                        }
                        else
                        {
                            stoneInfoMst.stoneImg += file.FileName;
                        }
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/assets/image/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                    }
                }//end of insert image

                db.Entry(stoneInfoMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stoneInfoMst);
        }

        // GET: Admin/StoneInfoMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoneInfoMst stoneInfoMst = db.StoneInfoMsts.Find(id);
            if (stoneInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(stoneInfoMst);
        }

        // POST: Admin/StoneInfoMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StoneInfoMst stoneInfoMst = db.StoneInfoMsts.Find(id);
            db.StoneInfoMsts.Remove(stoneInfoMst);
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

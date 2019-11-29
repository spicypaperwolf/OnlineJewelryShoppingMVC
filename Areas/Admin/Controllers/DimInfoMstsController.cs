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
using OnlineJewelryShoppingMVC.Interceptor;
using PagedList;
using PagedList.Mvc;


namespace OnlineJewelryShoppingMVC.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class DimInfoMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();

        // GET: Admin/DimInfoMsts
        public ActionResult Index(string searchString, int? page)
        {
            var item = from x in db.DimInfoMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.dimImg.Contains(searchString) || x.dimColor.Contains(searchString));
            }
            return View(item.ToList().ToPagedList(page ?? 1, 3));
        }
 

        // GET: Admin/DimInfoMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimInfoMst dimInfoMst = db.DimInfoMsts.Find(id);
            if (dimInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(dimInfoMst);
        }

        // GET: Admin/DimInfoMsts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DimInfoMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dimId,dimShape,dimCrt,dimSize,dimColor,dimClarity,dimCut,dimPolish,dimSymmetry,dimReport,dimRate,dimImg")] DimInfoMst dimInfoMst, HttpPostedFileBase[] files)
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
                            dimInfoMst.dimImg += file.FileName + ", ";

                        }
                        else
                        {
                            dimInfoMst.dimImg += file.FileName;
                        }
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/assets/image/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                    }
                }//end of insert image

                db.DimInfoMsts.Add(dimInfoMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dimInfoMst);
        }

        // GET: Admin/DimInfoMsts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimInfoMst dimInfoMst = db.DimInfoMsts.Find(id);
            if (dimInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(dimInfoMst);
        }

        // POST: Admin/DimInfoMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dimId,dimShape,dimCrt,dimSize,dimColor,dimClarity,dimCut,dimPolish,dimSymmetry,dimReport,dimRate,dimImg")] DimInfoMst dimInfoMst, HttpPostedFileBase[] files)
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
                            dimInfoMst.dimImg += file.FileName + ", ";

                        }
                        else
                        {
                            dimInfoMst.dimImg += file.FileName;
                        }
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/assets/image/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                    }
                }//end of insert image

                db.Entry(dimInfoMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimInfoMst);
        }

        // GET: Admin/DimInfoMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimInfoMst dimInfoMst = db.DimInfoMsts.Find(id);
            if (dimInfoMst == null)
            {
                return HttpNotFound();
            }
            return View(dimInfoMst);
        }

        // POST: Admin/DimInfoMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DimInfoMst dimInfoMst = db.DimInfoMsts.Find(id);
            db.DimInfoMsts.Remove(dimInfoMst);
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

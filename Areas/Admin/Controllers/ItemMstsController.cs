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
    public class ItemMstsController : Controller
    {
        private OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities(); 

        // GET: Admin/ItemMsts
        public ActionResult Index(string searchString ,int? page)
        {
            var item = from x in db.ItemMsts select x;
            if(!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.itemName.Contains(searchString)|| x.itemImg.Contains(searchString) );
            }
        //var itemMsts = db.ItemMsts.Include(i => i.BrandMst).Include(i => i.CategoryMst).Include(i => i.CertificateMst).Include(i => i.DimInfoMst).Include(i => i.GoldInfoMst).Include(i => i.ProductMst).Include(i => i.StoneInfoMst);
            return View(item.ToList().ToPagedList(page ??1, 3));
        }

        // GET: Admin/ItemMsts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemMst itemMst = db.ItemMsts.Find(id);
            if (itemMst == null)
            {
                return HttpNotFound();
            }
            return View(itemMst);
        }

        // GET: Admin/ItemMsts/Create
        public ActionResult Create()
        {
            ViewBag.brandId = new SelectList(db.BrandMsts, "brandId", "brandType");
            ViewBag.catId = new SelectList(db.CategoryMsts, "catId", "catName");
            ViewBag.certificateId = new SelectList(db.CertificateMsts, "certificateId", "certificateType");
            ViewBag.dimId = new SelectList(db.DimInfoMsts, "dimId", "dimShape");
            ViewBag.goldId = new SelectList(db.GoldInfoMsts, "goldId", "goldType");
            ViewBag.prodId = new SelectList(db.ProductMsts, "prodId", "prodType");
            ViewBag.stoneId = new SelectList(db.StoneInfoMsts, "stoneId", "stoneShape");
            return View();
        }

        // POST: Admin/ItemMsts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemCode,brandId,catId,certificateId,prodId,dimId,goldId,stoneId,itemName,itemImg,pairs,dimQty,dimTot,stoneQty,stoneTot,goldWt,goldTot,wstgPer,wstg,goldMaking,stoneMaking,otherMaking,totMaking,MRP")] ItemMst itemMst)
        {
            if (ModelState.IsValid)
            {
                db.ItemMsts.Add(itemMst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brandId = new SelectList(db.BrandMsts, "brandId", "brandType", itemMst.brandId);
            ViewBag.catId = new SelectList(db.CategoryMsts, "catId", "catName", itemMst.catId);
            ViewBag.certificateId = new SelectList(db.CertificateMsts, "certificateId", "certificateType", itemMst.certificateId);
            ViewBag.dimId = new SelectList(db.DimInfoMsts, "dimId", "dimShape", itemMst.dimId);
            ViewBag.goldId = new SelectList(db.GoldInfoMsts, "goldId", "goldType", itemMst.goldId);
            ViewBag.prodId = new SelectList(db.ProductMsts, "prodId", "prodType", itemMst.prodId);
            ViewBag.stoneId = new SelectList(db.StoneInfoMsts, "stoneId", "stoneShape", itemMst.stoneId);
            return View(itemMst);
        }

        // GET: Admin/ItemMsts/Edit/5
        public ActionResult Edit(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemMst itemMst = db.ItemMsts.Find(id);
            if (itemMst == null)
            {
                return HttpNotFound();
            }
            ViewBag.brandId = new SelectList(db.BrandMsts, "brandId", "brandType", itemMst.brandId);
            ViewBag.catId = new SelectList(db.CategoryMsts, "catId", "catName", itemMst.catId);
            ViewBag.certificateId = new SelectList(db.CertificateMsts, "certificateId", "certificateType", itemMst.certificateId);
            ViewBag.dimId = new SelectList(db.DimInfoMsts, "dimId", "dimShape", itemMst.dimId);
            ViewBag.goldId = new SelectList(db.GoldInfoMsts, "goldId", "goldType", itemMst.goldId);
            ViewBag.prodId = new SelectList(db.ProductMsts, "prodId", "prodType", itemMst.prodId);
            ViewBag.stoneId = new SelectList(db.StoneInfoMsts, "stoneId", "stoneShape", itemMst.stoneId);
            return View(itemMst);
        }

        // POST: Admin/ItemMsts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemCode,brandId,catId,certificateId,prodId,dimId,goldId,stoneId,itemName,itemDescription,itemImg,pairs,dimQty,dimTot,stoneQty,stoneTot,goldWt,goldTot,wstgPer,wstg,goldMaking,stoneMaking,otherMaking,totMaking,MRP")] ItemMst itemMst,HttpPostedFileBase[] files)
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
                            itemMst.itemImg += file.FileName + ",";

                        }
                        else
                        {
                            itemMst.itemImg += file.FileName;
                        }
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/assets/image/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                    }
                }
                db.Entry(itemMst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brandId = new SelectList(db.BrandMsts, "brandId", "brandType", itemMst.brandId);
            ViewBag.catId = new SelectList(db.CategoryMsts, "catId", "catName", itemMst.catId);
            ViewBag.certificateId = new SelectList(db.CertificateMsts, "certificateId", "certificateType", itemMst.certificateId);
            ViewBag.dimId = new SelectList(db.DimInfoMsts, "dimId", "dimShape", itemMst.dimId);
            ViewBag.goldId = new SelectList(db.GoldInfoMsts, "goldId", "goldType", itemMst.goldId);
            ViewBag.prodId = new SelectList(db.ProductMsts, "prodId", "prodType", itemMst.prodId);
            ViewBag.stoneId = new SelectList(db.StoneInfoMsts, "stoneId", "stoneShape", itemMst.stoneId);
            return View(itemMst);
        }

        // GET: Admin/ItemMsts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemMst itemMst = db.ItemMsts.Find(id);
            if (itemMst == null)
            {
                return HttpNotFound();
            }
            return View(itemMst);
        }

        // POST: Admin/ItemMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ItemMst itemMst = db.ItemMsts.Find(id);
            db.ItemMsts.Remove(itemMst);
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

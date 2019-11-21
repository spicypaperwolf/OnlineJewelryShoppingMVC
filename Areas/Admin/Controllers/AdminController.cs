using OnlineJewelryShoppingMVC.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelryShoppingMVC.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Items()
        {
            return View(db.ItemMsts.ToList());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelryShoppingMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        // GET: Shop/Detail
        public ActionResult Detail()
        {
            return View();
        }
        // GET: Shop/Cart
        public ActionResult Cart()
        {
            return View();
        }
        // GET: Shop/Checkout
        public ActionResult Checkout()
        {
            return View();
        }
    }
}
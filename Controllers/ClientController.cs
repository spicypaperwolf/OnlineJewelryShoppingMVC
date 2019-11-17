using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineJewelryShoppingMVC.Respository;

namespace OnlineJewelryShoppingMVC.Controllers
{
    public class ClientController : Controller
    {
        public ClientController()
        {
            ViewBag.TotalPrice = CartController.totalPrice;
            ViewBag.TotalQuality = CartController.totalQuality;
        }
        //Homepage
        public ActionResult Index()
        {
            return View();
        }

        //About us page to introduce ourself
        public ActionResult About()
        {
            return View();
        }

        //Shop page in default format for showing all products w customize filter
        public ActionResult Shop()
        {
            ItemRespository ir = new ItemRespository();
            ViewBag.ItemList = ir.GetItems();
            return View();
        }

        //Shop page in list format for showing all products w customize filter
        public ActionResult ShopList()
        {
            return View();
        }

        //Item page for details of particular product 
        public ActionResult ItemDetails()
        {
            return View();
        }

        //Login page for user
        public ActionResult Login()
        {
            return View();
        }

        //Cart Page for detailed information in cart
        public ActionResult Cart()
        {
            return View();
        }

        //Check out page for customer to process payment
        public ActionResult Checkout()
        {
            return View();
        }

        //Contact page for users who willing to keep in touch w us
        public ActionResult Contact()
        {
            return View();
        }

        //Blog page for displaying all of our post
        public ActionResult Blog()
        {
            return View();
        }

        //Blog page in list format for displaying all of our blog in the different presentation
        public ActionResult BlogList()
        {
            return View();
        }

        //Blog detailed page for presenting a specific post
        public ActionResult BlogDetails()
        {
            return View();
        }

        //Wishlist page for showing item our client wanna notice at
        public ActionResult Wishlist()
        {
            return View();
        }
    }
}
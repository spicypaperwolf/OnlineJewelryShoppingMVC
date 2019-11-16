using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoLib;
using OnlineJewelryShoppingMVC.Common;
using OnlineJewelryShoppingMVC.Models;

namespace OnlineJewelryShoppingMVC.Controllers
{
    public class ClientController : Controller
    {
        OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();
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
        //Login page for user/admi
        public ActionResult Login()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return View();
        }

        // 
        public bool isAdmin(string userName,string passWord)
        {
            try
            {
                if (db.AdminLoginMsts.First(item => item.username.Equals(userName)&&item.password.Equals(passWord)) == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
               
        public UserRegMst GetByUserName(string userName)
        {
            return db.UserRegMsts.SingleOrDefault(x => x.emailId == userName);
        }
        public AdminLoginMst GetByAdminName(string userName)
        {
            return db.AdminLoginMsts.First(item => item.username.Equals(userName));
        }

        // Ham kiem tra login
        public int checkLogin(string userName, string passWord)
        {
            var result = db.UserRegMsts.SingleOrDefault(x => x.emailId == userName);
            if (isAdmin(userName, passWord))
            {
                return 2;
            }
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {               
                var result = checkLogin(model.emailId, (model.password));
                if (result == 1)
                {
                    Session.Remove(CommonConstants.USER_SESSION);
                    var user = GetByUserName(model.emailId);
                    var userSession = new UserLogin();
                    userSession.UserName = user.emailId; // user.UserName in Database
                    userSession.Role = "user";

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Client");
                }
                else if (result == 2)
                {
                    Session.Remove(CommonConstants.USER_SESSION);
                    AdminLoginMst user = GetByAdminName(model.emailId);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username; // user.UserName in Database
                    userSession.Role = "admin";
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Dashboard", "Admin/Admin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Login is invalid!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account is being blocked!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Password is not correct");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Login is not correct!");
                }
            }
            return View("Login");
        }
        // Logout function
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Client");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OnlineJewelryShoppingMVC.Common;
using OnlineJewelryShoppingMVC.Models;
using OnlineJewelryShoppingMVC.Respository;
using OnlineJewelryShoppingMVC.Sercurity;
using PagedList;
using PagedList.Mvc;

namespace OnlineJewelryShoppingMVC.Controllers
{
    public class ClientController : Controller
    {

        OnlineJewelryShopDBEntities _context = new OnlineJewelryShopDBEntities();
        public ClientController()
        {
            ViewBag.TotalPrice = CartController.totalPrice;
            ViewBag.TotalQty = CartController.totalQty;
        }
        //Homepage
        public ActionResult Index()
        {
            ViewBag.ItemList = _context.ItemMsts.Where(i => i.itemStatus == true).OrderByDescending(i => i.created_at).ToList();
            ViewBag.RingList = _context.ItemMsts.Where(i => i.ProductMst.prodType == "Ring").ToList();
            ViewBag.EaringsList = _context.ItemMsts.Where(i => i.ProductMst.prodType == "Earings").ToList();
            ViewBag.NecklaceList = _context.ItemMsts.Where(i => i.ProductMst.prodType == "Necklace").ToList();
            ViewBag.BraceletList = _context.ItemMsts.Where(i => i.ProductMst.prodType == "Bracelet").ToList();
            ViewBag.BlogList = _context.BlogMsts.ToList();
            return View();
        }

        //About us page to introduce ourself
        public ActionResult About()
        {
            return View();
        }

        //Shop page in default format for showing all products w customize filter
        public ActionResult Shop(string searchString, int? page, string sortBy, string sort_by_prod)
        {
            var item = from x in _context.ItemMsts select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                item = item.Where(x => x.itemName.Contains(searchString) || x.itemImg.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(sort_by_prod))
            {
                item = item.Where(x => x.ProductMst.prodId.Contains(sort_by_prod));
            }

            ItemRespository ir = new ItemRespository();
            ViewBag.BrandList = _context.BrandMsts.ToList();
            ViewBag.ProdList = _context.ProductMsts.ToList();
            ViewBag.ItemList = item.Where(i => i.itemStatus == true).ToList().ToPagedList(page ?? 1, 6);
            return View(item.Where(i => i.itemStatus == true).ToList().ToPagedList(page ?? 1, 6));
        }

        [HttpPost]
        public ActionResult Shop(int? page, int sort_by, string sort_by_brand, string sort_by_prod)
        {
            var item = from x in _context.ItemMsts select x;

            if (!string.IsNullOrEmpty(sort_by_brand))
            {
                item = item.Where(x => x.BrandMst.brandId.Contains(sort_by_brand));
            }

            if (!string.IsNullOrEmpty(sort_by_prod))
            {
                item = item.Where(x => x.ProductMst.prodId.Contains(sort_by_prod));
            }

            ItemRespository ir = new ItemRespository();
            ViewBag.BrandList = _context.BrandMsts.ToList();
            ViewBag.ProdList = _context.ProductMsts.ToList();
            ViewBag.ItemList = item.ToList().ToPagedList(page ?? 1, sort_by);
            return View(item.ToList().ToPagedList(page ?? 1, sort_by));
        }

        //Shop page in list format for showing all products w customize filter
        public ActionResult ShopList(int? page)
        {
            var item = from x in _context.ItemMsts select x;
            ViewBag.BrandList = _context.BrandMsts.ToList();
            ViewBag.ProdList = _context.ProductMsts.ToList();
            return View(item.Where(i => i.itemStatus == true).ToList().ToPagedList(page ?? 1, 8));
        }

        //Shop page in list format for showing all products w customize filter
        [HttpPost]
        public ActionResult ShopList(int? page, int sort_by, string sort_by_brand)
        {
            var item = from x in _context.ItemMsts select x;

            if (!string.IsNullOrEmpty(sort_by_brand))
            {
                item = item.Where(x => x.BrandMst.brandId.Contains(sort_by_brand));
            }

            return View(item.ToList().ToPagedList(page ?? 1, sort_by));
        }

        //Item page for details of particular product 
        public ActionResult ItemDetails(string id)
        {
            ItemMst item = _context.ItemMsts.Where(i => i.itemCode.Equals(id)).FirstOrDefault();
            if (item == null || id == null)
            {
                return RedirectToAction("ErrorPage");
            }
            ViewBag.RelatedItem = _context.ItemMsts.Where(i => i.brandId == item.brandId).ToList();
            ViewBag.CmtList = _context.CommentMsts.OrderByDescending(c => c.cmtId).ToList();
            return View(item);
        }

        [HttpPost]
        public ActionResult Review(string review, string itemCode, int userId)
        {
            CommentMst c = new CommentMst();
            c.cmtContent = review;
            c.itemCode = itemCode;
            c.userId = userId;
            _context.CommentMsts.Add(c);
            _context.SaveChanges();
            return RedirectToAction("ItemDetails", "Client", new { id = itemCode});
        }

        //Login page for user/admi
        public ActionResult Login()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return View();
        }

        // 
        public bool isAdmin(string userName, string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                try
                {
                    AdminLoginMst adminLogin = _context.AdminLoginMsts.First(item => item.username.Equals(userName));
                    bool verifyPassword = MD5Service.VerifyMd5Hash(md5Hash, password, adminLogin.password);
                    if (adminLogin == null || !verifyPassword)
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
        }

        public UserRegMst GetByUserName(string userName)
        {
            return _context.UserRegMsts.SingleOrDefault(x => x.emailId == userName);
        }
        public AdminLoginMst GetByAdminName(string userName)
        {
            return _context.AdminLoginMsts.First(item => item.username.Equals(userName));
        }

        // Ham kiem tra login
        public int checkLogin(string userName, string password)
        {
            var result = _context.UserRegMsts.SingleOrDefault(x => x.emailId == userName);
            if (isAdmin(userName, password))
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
                    using (MD5 md5Hash = MD5.Create())
                    {
                        bool verifyPassword = MD5Service.VerifyMd5Hash(md5Hash, password, result.password);
                        if (verifyPassword)
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
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            //UserLogin u = new UserLogin();
            //u = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (ModelState.IsValid)
            {
                var result = checkLogin(model.emailId, (model.password));
                if (result == 1)
                {
                    Session.Remove(CommonConstants.USER_SESSION);
                    var user = GetByUserName(model.emailId);
                    var userSession = new UserLogin();
                    userSession.UserID = user.userId;
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
                    return RedirectToAction("Dashboard", "Admin");
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
            if (Session[CommonConstants.USER_SESSION] != null)
            {
                Session.Remove(CommonConstants.USER_SESSION);
            }
            return RedirectToAction("Login", "Client");
        }

        //Contact page for users who willing to keep in touch w us
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string c_name, string c_email, string c_phone, string c_subject, string c_message)
        {
            ContactMst c = new ContactMst();
            c.contactName = c_name;
            c.contactEmail = c_email;
            c.contactMob = c_phone;
            c.contactSubject = c_subject;
            c.contactMessage = c_message;
            _context.ContactMsts.Add(c);
            _context.SaveChanges();
            ViewBag.Success = "The message has been sent successfully. Thank you!";
            return View();
        }

        //Blog page for displaying all of our post
        public ActionResult Blog(int? page)
        {
            var blog = from x in _context.BlogMsts select x;
            return View(blog.ToList().ToPagedList(page ?? 1, 3));
        }


        //Blog detailed page for presenting a specific post
        public ActionResult BlogDetails(int id)
        {
            BlogMst blog = _context.BlogMsts.Where(b => b.blogId.Equals(id)).FirstOrDefault();
            if (blog == null)
            {
                return RedirectToAction("ErrorPage");
            }
            ViewBag.RecentBlog = _context.BlogMsts.OrderByDescending(b => b.cdate).ToList();
            return View(blog);
        }

        //Wishlist page for showing item our client wanna notice at
        public ActionResult Wishlist()
        {
            return View();
        }

        //Error Page
        public ActionResult ErrorPage()
        {
            return View();
        }

        //For handling newsletter requirement from user
        [HttpPost]
        public ActionResult Newsletter(string n_email)
        {
            NewsletterMst n = new NewsletterMst();
            n.newsletterEmail = n_email;
            _context.NewsletterMsts.Add(n);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Resister(UserRegMst model)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                model.password = MD5Service.GetMd5Hash(md5Hash, model.password);
            }
            model.status = true;
            model.cdate = DateTime.Now;
            _context.UserRegMsts.Add(model);
            if (_context.UserRegMsts.Where(item => item.emailId == model.emailId).FirstOrDefault() != null)
            {
                ViewBag.ExistsEmail = "Email is already exists";
                return View("Login");
            }
            _context.SaveChanges();
            var user = GetByUserName(model.emailId);
            var userSession = new UserLogin();
            userSession.UserID = user.userId;
            userSession.UserName = user.emailId; // user.UserName in Database
            userSession.Role = "user";
            Session.Add(CommonConstants.USER_SESSION, userSession);
            return RedirectToAction("Index", "Client");
        }

    }
}
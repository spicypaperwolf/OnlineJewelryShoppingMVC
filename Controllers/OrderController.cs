using OnlineJewelryShoppingMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelryShoppingMVC.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {
            ViewBag.TotalPrice = CartController.totalPrice;
            ViewBag.TotalQty = CartController.totalQty;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(string fname, string lname, string address, string city, string state,
            string email, string mobNo, string cardNo, string expDate, string CVV)
        {
            using (OnlineJewelryShopDBEntities _context = new OnlineJewelryShopDBEntities())
            {

                if (Session["cartList"] != null)
                {
                    if (Session[CommonConstants.USER_SESSION] != null)
                    {
                        UserLogin u = new UserLogin();
                        u = (UserLogin)Session[CommonConstants.USER_SESSION];

                        RandomGenerator ran = new RandomGenerator();

                        InquiryMst i = new InquiryMst();

                        i.inquiryID = ran.RandomSth();
                        i.fname = fname;
                        i.lname = lname;
                        i.city = city;
                        i.address = address;
                        i.cmt = "";
                        i.mobNo = mobNo;
                        i.emailId = email;
                        i.cardNo = cardNo;
                        i.expdate = expDate;
                        i.CVV_No = CVV;
                        i.cdate = System.DateTime.Now;
                        foreach (CartList item in (List<CartList>)Session["cartList"])
                        {
                            i.transactionId = item.transactionId;
                            break;
                        }
                        _context.InquiryMsts.Add(i);


                        foreach (CartList item in (List<CartList>)Session["cartList"])
                        {
                            CartList c = new CartList();
                            c.cartId = item.cartId;
                            c.transactionId = item.transactionId;
                            c.itemCode = item.itemCode;
                            c.qty = item.qty;
                            c.price = item.price;
                            _context.CartLists.Add(c);
                        }

                        TransactionMst t = new TransactionMst();
                        foreach (CartList item in (List<CartList>)Session["cartList"])
                        {
                            t.transactionId = item.transactionId;
                            break;
                        }
                        t.userId = u.UserID;
                        t.approvalStt = "Pending";
                        t.totPrice = ViewBag.TotalPrice;
                        t.totQty = ViewBag.TotalQty;


                        _context.TransactionMsts.Add(t);
                    }
                    else
                    {
                        RandomGenerator ran = new RandomGenerator();

                        InquiryMst i = new InquiryMst();

                        i.inquiryID = ran.RandomSth();
                        i.fname = fname;
                        i.lname = lname;
                        i.city = city;
                        i.address = address;
                        i.cmt = "";
                        i.mobNo = mobNo;
                        i.emailId = email;
                        i.cardNo = cardNo;
                        i.expdate = expDate;
                        i.CVV_No = CVV;
                        i.cdate = System.DateTime.Now;
                        foreach (CartList item in (List<CartList>)Session["cartList"])
                        {
                            i.transactionId = item.transactionId;
                            break;
                        }
                        _context.InquiryMsts.Add(i);


                        foreach (CartList item in (List<CartList>)Session["cartList"])
                        {
                            CartList c = new CartList();
                            c.cartId = item.cartId;
                            c.transactionId = item.transactionId;
                            c.itemCode = item.itemCode;
                            c.qty = item.qty;
                            c.price = item.price;
                            _context.CartLists.Add(c);
                        }

                        TransactionMst t = new TransactionMst();
                        foreach (CartList item in (List<CartList>)Session["cartList"])
                        {
                            t.transactionId = item.transactionId;
                            break;
                        }

                        t.approvalStt = "Pending";
                        t.totPrice = ViewBag.TotalPrice;
                        t.totQty = ViewBag.TotalQty;

                        _context.TransactionMsts.Add(t);
                    }
                    
                    _context.SaveChanges();
                    Session.Remove("cartList");
                    CartController.totalPrice = 0;
                    CartController.totalQty = 0;
                }
                return RedirectToAction("Index");
            }
        }

        public class RandomGenerator
        {
            // Generate a random number between two numbers    
            public int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

            // Generate a random string with a given size    
            public string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }

            // Generate a random password    
            public string RandomSth()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(RandomString(4, true));
                builder.Append(RandomNumber(1000, 9999));
                builder.Append(RandomString(2, false));
                return builder.ToString();
            }
        }
    }
}
using OnlineJewelryShoppingMVC.Common;
using OnlineJewelryShoppingMVC.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelryShoppingMVC.Controllers
{
    public class CartController : Controller
    {
        ItemRespository ir = new ItemRespository();
        public static decimal totalPrice = 0;
        public static int totalQty = 0;
        public static RandomGenerator rand = new RandomGenerator();
        public static string transactionId = rand.RandomSth();

        public CartController()
        {
            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalQty = totalQty;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Buy(string id, int? number)
        {
            UserLogin u = new UserLogin();
            u = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (number != null)
            {
                totalQty += Int32.Parse(number.ToString());
            }
            else
            {
                totalQty++;
            }
            RandomGenerator ran = new RandomGenerator();
            List<CartList> carts = new List<CartList>();
            if (Session["cartList"] == null)
            {
                carts.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = 1, price = ir.GetItemById(id).MRP, cartId = ran.RandomString(10, false), transactionId = transactionId });
                Session["cartList"] = carts;
            }
            else
            {
                carts = (List<CartList>)Session["cartList"];
                int index = isExist(id);
                if (index != -1)
                {
                    if (number != null)
                    {
                        carts[index].qty += Int32.Parse(number.ToString());
                    }
                    else
                    {
                        carts[index].qty++;
                    }   
                }
                else
                {
                    if (number != null)
                    {
                        carts.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = Int32.Parse(number.ToString()), price = ir.GetItemById(id).MRP, cartId = ran.RandomString(10, false), transactionId = transactionId });
                    }
                    else
                    {
                        carts.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = 1, price = ir.GetItemById(id).MRP, cartId = ran.RandomString(10, false), transactionId = transactionId });
                    }
                }
                Session["cart"] = carts;
            }
            carts.ForEach(item => {
                totalPrice += item.price;
            }) ;
            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalQuality = totalQty;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveBy1(string id)
        {
            totalQty--;
            List<CartList> carts = (List<CartList>)Session["cartList"];
            int index = isExist(id);
            if (carts[index].qty > 1)
            {
                carts[index].qty--;
            }
            else
            {
                carts.RemoveAt(index);
            }
           
            Session["cartList"] = carts;
            totalPrice = 0;
            carts.ForEach(item => {
                totalPrice += item.price;
            });
            return RedirectToAction("Shop", "Client");
        }

        private int isExist(string id)
        {
            List<CartList> carts = (List<CartList>)Session["cartList"];
            int result = carts.Find(item => item.itemCode.Equals(id))!=null ? carts.IndexOf(carts.Find(item => item.itemCode.Equals(id))) : -1;
            return result;
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

        public ActionResult ClearCart()
        {
            Session.Remove("cartList");
            totalPrice = 0;
            totalQty = 0;
            return RedirectToAction("Index", "Client");
        }
    }
}
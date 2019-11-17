using OnlineJewelryShoppingMVC.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJewelryShoppingMVC.Controllers
{
    public class CartController : Controller
    {
        ItemRespository ir = new ItemRespository();
        public static decimal totalPrice = 0;
        public static decimal totalQuality = 0;

        public CartController()
        {
            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalQuality = totalQuality;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Buy(string id)
        {
            totalQuality++;
            Random ran = new Random();
            ran.Next(1, 1000);
            List<CartList> carts = new List<CartList>();
            if (Session["cartList"] == null)
            {
                carts.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = 1, price = ir.GetItemById(id).MRP, cartId = "C" + ran });
                Session["cartList"] = carts;
            }
            else
            {
                carts = (List<CartList>)Session["cartList"];
                int index = isExist(id);
                if (index != -1)
                {
                    carts[index].qty++;
                }
                else
                {
                    carts.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = 1, price = ir.GetItemById(id).MRP, cartId = "C" + ran });
                }
                Session["cart"] = carts;
            }
            carts.ForEach(item => {
                totalPrice += item.price;
            }) ;
            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalQuality = totalQuality;
            return RedirectToAction("Shop", "Client");
        }

        public ActionResult RemoveBy1(string id)
        {
            totalQuality--;
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

        //public ActionResult CreateOrder()
        //{

        //}
    }
}
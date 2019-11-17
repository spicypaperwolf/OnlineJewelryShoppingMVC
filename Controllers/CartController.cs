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

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Buy(string id)
        {
            Random ran = new Random();
            ran.Next(1, 1000);

            if (Session["cartList"] == null)
            {
                List<CartList> cart = new List<CartList>();
                cart.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = 1, price = ir.GetItemById(id).MRP, cartId = "C" + ran });
                Session["cartList"] = cart;
            }
            else
            {
                List<CartList> cart = (List<CartList>)Session["cartList"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].qty++;
                }
                else
                {
                    cart.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = 1, price = ir.GetItemById(id).MRP, cartId = "C" + ran });
                }
                Session["cart"] = cart;
            }

            return RedirectToAction("Shop", "Client");

            //Random ran = new Random();
            //ran.Next(1, 1000);
            //List<CartList> cartList = new List<CartList>();
            //if (Session["cartList"]!=null)
            //{
            //    cartList = (List<CartList>)Session["cartList"];
            //    Session.Remove("cartList");
            //}
            //cartList.Add(new CartList { itemCode = ir.GetItemById(id).itemCode, qty = 1, price = ir.GetItemById(id).MRP, cartId = "C" + ran });
            //Session["cartList"] = cartList;
            //return RedirectToAction("Index");
        }

        public ActionResult RemoveBy1(string id)
        {
            List<CartList> cart = (List<CartList>)Session["cartList"];
            int index = isExist(id);
            if (cart[index].qty > 1)
            {
                cart[index].qty--;
            }
            else
            {
                cart.RemoveAt(index);
            }
           
            Session["cartList"] = cart;
            return RedirectToAction("Shop", "Client");
        }

        private int isExist(string id)
        {
            List<CartList> cart = (List<CartList>)Session["cartList"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].itemCode.Equals(id))
                    return i;
            return -1;
        }

        //public ActionResult CreateOrder()
        //{

        //}
    }
}
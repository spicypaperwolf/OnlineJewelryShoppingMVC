using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewelryShoppingMVC.Respository
{
    public class CartRespository
    {
        OnlineJewelryShopDBEntities _context = new OnlineJewelryShopDBEntities();

        public string CreateOrder(CartList cart, InquiryMst inquiry)
        {
            _context.CartLists.Add(cart);
            _context.InquiryMsts.Add(inquiry);
            _context.SaveChanges();
            return "Successfully Create Order!";
        }
    }
}
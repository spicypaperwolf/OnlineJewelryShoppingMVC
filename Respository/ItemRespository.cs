using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewelryShoppingMVC.Respository
{
    public class ItemRespository
    {
        OnlineJewelryShopDBEntities _context = new OnlineJewelryShopDBEntities();
        public List<ItemMst> GetItems()
        {
            var ItemList = _context.ItemMsts.ToList();
            return ItemList;
        }

        public ItemMst GetItemById(string id)
        {
            return GetItems().SingleOrDefault(i => i.itemCode.Equals(id));
        }

        public decimal totPrice(decimal a, int b)
        {
            return a * b;
        }

        public string returnImage(string id)
        {
            string imgPath = _context.ItemMsts.Find(id).itemImg;
            return imgPath;
        }
    }
}
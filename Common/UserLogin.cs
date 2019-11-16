using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJewelryShoppingMVC
{
    [Serializable]
    public class UserLogin
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Role { get; internal set; }
    }
}
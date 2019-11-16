using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewelryShoppingMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please input user name!")]
        public string emailId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please input password!")]
        public string password { get; set; }
        public bool RememberMe { get; set; }
    }
}
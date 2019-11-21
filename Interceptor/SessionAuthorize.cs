using OnlineJewelryShoppingMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Chan user vao trang admin
namespace OnlineJewelryShoppingMVC.Interceptor
{
    public class SessionAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            UserLogin auth = new UserLogin();
            auth = (UserLogin)context.HttpContext.Session[CommonConstants.USER_SESSION];
            if (auth == null)
            {
                context.Result = new RedirectResult("/Client/Login");
            }
            else
            {
                if (auth.Role == "user")
                {
                    context.Result = new RedirectResult("/Client/Index");
                }
            }
        }
    }
}
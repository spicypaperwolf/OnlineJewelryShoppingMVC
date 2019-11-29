using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using OnlineJewelryShoppingMVC;
using System.Collections;
using OnlineJewelryShoppingMVC.Common;
using OnlineJewelryShoppingMVC.Interceptor;

namespace OnlineJewelryShoppingMVC.Areas.Admin.Controllers
{
    [SessionAuthorize]
    public class DashboardController : Controller
    {
        // GET: Admin/Admin
        OnlineJewelryShopDBEntities db = new OnlineJewelryShopDBEntities();
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult CharterColumn()
        {
            var db = new OnlineJewelryShopDBEntities();
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var result = (from c in db.TransactionMsts select c);
            result.ToList().ForEach(rs =>
            {
                if (rs.UserRegMst != null)
                {
                    InquiryMst inquiryMst = db.InquiryMsts.Where(item => item.transactionId == rs.transactionId).FirstOrDefault();
                    xValue.Add(inquiryMst.cdate);
                }
            });
            result.ToList().ForEach(rs => {
                if (rs.UserRegMst != null)
                {
                    yValue.Add(rs.totPrice);
                }
            });

            new Chart(width: 800, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Chart for Diamond [Collumn Chart]")
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");
            return null;
        }
        public ActionResult LineChart()
        {
            var db = new OnlineJewelryShopDBEntities();
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var result = (from c in db.TransactionMsts select c);
            result.ToList().ForEach(rs =>
            {
                if (rs.UserRegMst == null)
                {
                    InquiryMst inquiryMst = db.InquiryMsts.Where(item => item.transactionId == rs.transactionId).FirstOrDefault();
                    xValue.Add(inquiryMst.cdate);
                }
            });
            result.ToList().ForEach(rs => {
                if (rs.UserRegMst == null)
                {
                    yValue.Add(rs.totPrice);
                }
            });

            new Chart(width: 800, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Chart for Diamond [Collumn Chart]")
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");
            return null;
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

    }
}
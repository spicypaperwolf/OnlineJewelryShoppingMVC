using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using OnlineJewelryShoppingMVC;
using System.Collections;

namespace OnlineJewelryShoppingMVC.Areas.Admin.Controllers
{
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

            var result = (from c in db.DimInfoMsts select c);
            result.ToList().ForEach(rs => xValue.Add(rs.dimColor));
            result.ToList().ForEach(rs => yValue.Add(rs.dimRate));

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

            var result = (from c in db.DimInfoMsts select c);
            result.ToList().ForEach(rs => xValue.Add(rs.dimColor));
            result.ToList().ForEach(rs => yValue.Add(rs.dimRate));

            new Chart(width: 800, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Chart for Diamond [Line Chart]")
                .AddSeries("Default", chartType: "Line", xValue: xValue, yValues: yValue)
                .Write("bmp");
            return null;
        }




    }
}
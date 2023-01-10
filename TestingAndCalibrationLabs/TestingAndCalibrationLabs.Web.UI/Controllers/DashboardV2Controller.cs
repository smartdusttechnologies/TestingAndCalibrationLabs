using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class DashboardV2Controller : Controller
    {
        public IActionResult Index()
        {

            var Template = new DashboardV2Box();
            Template.Traffic = 21;
            Template.Likes = 23;
            Template.Sales = 211;
            Template.NewMember = 422;
            Template.Inventory = 21;
            Template.mention = 23;
            Template.Downloads = 211;
            Template.Messages = 422;

            var salesValue = new RecapModel();
            salesValue.Month = new List<string> { "January", "February", "March", "April", "May", "June", "July" };
            salesValue.salesData1 = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            salesValue.SalesData2 = new List<int> { 25, 18, 30, 45, 6, 67, 45 };

            salesValue.Revenue = 21110;
            salesValue.RevenueGrowth = 20;
            salesValue.Cost = 2110;
            salesValue.CostWarning = 2000;
            salesValue.Profit = 20;
            salesValue.ProfitPercentage = 21;
            salesValue.Goal = 211;
            salesValue.GoalRate = 322;
            salesValue.CartValue = 210;
            salesValue.PurchaseNo = 2;
            salesValue.PageVisitors = 2810;
            salesValue.CostWarning = 2000;
            salesValue.InquiriesNo = 200;
            salesValue.DateRange = " 21 July ,2014 to 22 jan, 2022";

            var visitorvalue = new UsVisitor();
            visitorvalue.vistorslist = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            visitorvalue.ReferalNo = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            visitorvalue.organiclist = new List<int> { 21, 12, 33, 45, 66, 7, 45 };

            visitorvalue.VisitorsAvg = 7654;
            visitorvalue.ReferalPercent = "32%";
            visitorvalue.OrganicPercentage = "31%";

            var Browse = new BrowserUsage();
            Browse.BrowserName = new List<string> { "Chrome", "IE", "FireFox", "Safari", "Opera", "Navigator" };
            Browse.Data = new List<int> { 700, 500, 400, 600, 300, 100 };

            var orderdata = new LatestOrder();
            orderdata.Orderid = 12;
            orderdata.item = "Call of Duty IV";
            orderdata.Status = "Pending";
            orderdata.Popularity = "90,80,90,-70,61,-83,63";

            var product = new RecentProduct();
            product.Name = "Samsung TV";
            product.price = 18;
            product.ProductDetails = "ritesh ji ka tv hai achhe se pahuchao";

            var Modelset = new DashboardV2();

            Modelset.map = visitorvalue;
            Modelset.RecapModel = salesValue;
            Modelset.Box = Template;
            Modelset.Usage = Browse;
            Modelset.Order = orderdata;
            Modelset.Detail = product;



            return View(Modelset);
        }
    }
}

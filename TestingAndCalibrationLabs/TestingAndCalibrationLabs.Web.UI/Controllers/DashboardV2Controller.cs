
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// Class Contain a Index method in while all Dashboard V2 model object is created 
    /// </summary>
    public class DashboardV2Controller : Controller
    {
       /// <summary>
       /// It contain All the values for the model 
       /// </summary>
       /// <returns> pass the Dashboardv2 Model object to the view </returns>
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
            orderdata.Orderid = new List<string> { "OR1848", "OR1848", "OR1848", "OR1848" };
            orderdata.item = new List<string> { "Call of Duty IV", "Call of Duty IV","Call of Duty IV", "Call of Duty IV" };
            orderdata.Status = new List<string> { "Pending", "Delivered","waiting","Pending" };
            orderdata.Popularity = new List<string> { "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63" };
            orderdata.BadgeName = new List<string> { "badge badge-success","badge badge-danger","badge badge-warning", "badge badge-success" };


            var product = new RecentProduct();
            product.Name = new List<string> { "Samsung TV", "Jio TV", "Bauraha TV", "boka TV" };
            product.price = new List<string> { "$1600", "$1400", "$1800", "$1200" };
            product.ProductDetails = new List<string> { "ritesh ji ka tv hai achhe se pahuchao", "ritesh ji ka tv hai achhe se pahuchao", "ye to pakka raj ka tv h", "burbak belong to my friend raj" };
            product.ProductImg = new List<string> { "/img/default-150x150.png", "/img/default-150x150.png", "/img/default-150x150.png", "/img/default-150x150.png" };

            var chat1 = new ChatModel();
            chat1.Name = "Raj";
            chat1.Message = "Hi Ritesh how are you";
            chat1.Time = "23 Jan 5:37 pm";
            chat1.Image = "/img/user1-128x128.jpg";
            var chat2 = new ChatModel();
            chat2.Name = "Ritesh singh";
            chat2.Message = "Hello Gupta fine ";
            chat2.Time = "23 Jan 5:38 pm";
            chat2.Image = "/img/user1-128x128.jpg";
            var chat3 = new ChatModel();
            chat3.Name = "Ritesh singh";
            chat3.Message = "apna batao anda kab khila rahe";
            chat3.Time = "23 Jan 5:38 pm";
            chat3.Image = "/img/user1-128x128.jpg";
            var chat4 = new ChatModel();
            chat4.Name = "Raj";
            chat4.Message = "Bhai Paisa Nahi hai ";
            chat4.Time = "23 Jan 5:39 pm";
            chat4.Image = "/img/user1-128x128.jpg";
            var chat5 = new ChatModel();
            chat5.Name = "Ritesh singh";
            chat5.Message = "UU to thik h ii dekho Pura smartdust members  ka focus hmlog k msg p hi hai! Oye tumhe hi bol raha jao kaam kr lo thora   ";
            chat5.Time = "23 Jan 5:40 pm";
            chat5.Image = "/img/user1-128x128.jpg";

            var chat6 = new ChatModel();
            chat6.Name = "Raj";
            chat6.Message = "Jaane DO ritesh  in log ko kaam dhandha nahi hai  ";
            chat6.Time = "23 Jan 5:41 pm";
            chat6.Image = "/img/user1-128x128.jpg";


            var members = new LatestMember();
            members.ImageLink = new List<string> {"/img/user7-128x128.jpg", "/img/user8-128x128.jpg", "/img/user1-128x128.jpg", "/img/user6-128x128.jpg" };
            members.Name = new List<string> { "Ritesh Singh", "Prem Ranjan", "Raj Gupta", "Aman Raj" };
            members.Date = new List<string> { "12 August", "01 July", "03 jan", "03 Jan" };

            var Modelset = new DashboardV2();

            Modelset.map = visitorvalue;
            Modelset.RecapModel = salesValue;
            Modelset.Box = Template;
            Modelset.Usage = Browse;
            Modelset.Order = orderdata;
            Modelset.Detail = product;
            Modelset.ChatData = new List<ChatModel> {chat1,chat2,chat3,chat4,chat5,chat6};
            Modelset.Member = members;


            return View(Modelset);
        }
    }
}

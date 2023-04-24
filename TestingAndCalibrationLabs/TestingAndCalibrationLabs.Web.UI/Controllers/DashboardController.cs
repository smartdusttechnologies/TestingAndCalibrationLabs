
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1;

using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2;


namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class DashboardController : Controller
    {
        /// <summary>
        /// This Function is putting the data in the model 
        /// </summary>
        /// ModelList model will be return to the view
        /// <returns></returns>
        public IActionResult Index()
        {

            //var call = new List<ABC>();
            //call.Add(new ABC {Phone="1234567890" });

            //var  Email = new List<ABC>();
            // Email.Add(new ABC {Email="himanshujaiswal292@gmail.com"});

            return View();
        }
        /// <summary>
        /// This Method is for AreaGraph And Dounut Graph
        /// </summary>
        /// <returns> It will return the object of area Graph </returns>
        [HttpPost]
        public IActionResult AreaChart()
        {

            #region Different Numbers of data for AreaChart 
            //var AreaInfo = new SalesModel();
            //AreaInfo.Label = "Digital goods";
            //AreaInfo.backgroundColor = "yellow";
            //AreaInfo.borderColor = "green";
            //AreaInfo.pointColor = "blue";
            //AreaInfo.pointStrokeColor = "red";
            //AreaInfo.pointRadius = "false";
            //AreaInfo.pointHighlightStroke = "rgba(220,220,220,1)";
            //AreaInfo.data = new List<int> { 21, 12, 33, 45, 66, 7, 45 };

            //var AreaInfo2 = new SalesModel();
            //AreaInfo2.Label = "Electronic Items";
            //AreaInfo2.backgroundColor = "red";
            //AreaInfo2.borderColor = "green";
            //AreaInfo2.pointRadius = "false";
            //AreaInfo2.pointColor = "navyblue";
            //AreaInfo2.pointStrokeColor = "red";
            //AreaInfo2.pointHighlightStroke = "rgba(220,220,220,1)";
            //AreaInfo2.data = new List<int> { 21, 12, 33, 56, 21, 7, 78 };

            //var AreaInfo3 = new SalesModel();
            //AreaInfo3.Label = "Food Item";
            //AreaInfo3.backgroundColor = "white";
            //AreaInfo3.borderColor = "pink";
            //AreaInfo3.pointRadius = "false";
            //AreaInfo3.pointColor = "skyblue";
            //AreaInfo3.pointStrokeColor = "red";
            //AreaInfo3.pointHighlightStroke = "rgba(220,220,220,1)";
            //AreaInfo3.data = new List<int> { 21, 23, 13, 11, 54, 7, 65 };
            #endregion



            var AreaInfo4 = new SalesModel();
            AreaInfo4.Label = "Digital Goods";
            AreaInfo4.backgroundColor = "rgba(210, 214, 222, 1)";
            AreaInfo4.borderColor = "rgba(210, 214, 222, 1)";
            AreaInfo4.pointRadius = "false";
            AreaInfo4.pointColor = "#3b8bba";
            AreaInfo4.pointStrokeColor = "rgba(60,141,188,1)";
            AreaInfo4.pointHighlightStroke = "rgba(60,141,188,1)";
            AreaInfo4.data = new List<int> { 28, 48, 40, 19, 86, 27, 90 };

            var AreaInfo5 = new SalesModel();
            AreaInfo5.Label = "Electronics";
            AreaInfo5.backgroundColor = "rgba(60,141,188,0.9)";
            AreaInfo5.borderColor = "rgba(60,141,188,0.8)";
            AreaInfo5.pointRadius = "false";
            AreaInfo5.pointColor = "rgba(210, 214, 222, 1)";
            AreaInfo5.pointStrokeColor = "#c1c7d1";
            AreaInfo5.pointHighlightStroke = "rgba(220,220,220,1)";
            AreaInfo5.data = new List<int> { 65, 59, 80, 81, 56, 55, 40 };

            var donutData = new DonutGraph();
            donutData.SalesName = new List<string> { "Instore ", "Mail-order", "Sales" };
            donutData.DataSet = new List<int> { 51, 43, 23 };
            donutData.Background = new List<string> { "#f56954", "#00a65a", "#f39c12" };

            #region Different Data for Donut Chart
            //var donutData1 = new DonutGraph();
            //donutData1.SalesName = new List<string> { "Mobile Sales", "cracker Sales", "Website Sales" };
            //donutData1.DataSet = new List<int> { 45, 12, 43 };
            //donutData1.Background = new List<string> { "red", "pink", "yellow" };
            #endregion

            var salesValue = new AreaGraph();
            salesValue.AreaData = new List<SalesModel> { /*AreaInfo, AreaInfo2, AreaInfo3,*/ AreaInfo5, AreaInfo4 };
            salesValue.DonutData = new List<DonutGraph> { donutData/*,donutData1*/};
            salesValue.Month = new List<string> { "January", "February", "March", "April", "May", "June", "July" };


            return Ok(salesValue);
        }
        /// <summary>
        /// This Method is for Line Chart 
        /// </summary>
        /// <returns> It will return the object of Line Chart</returns>
        [HttpPost]
        public IActionResult LineChart()
        {
            #region DYNAMIC Data for Line Chart
            //var LinechartData = new Dashboard_SalesGraph();
            //LinechartData.Label = "Goodies";
            //LinechartData.fill = "false";
            //LinechartData.borderWidth = 3;
            //LinechartData.lineTension = 0;
            //LinechartData.spanGaps = "true";
            //LinechartData.borderColor = "red";
            //LinechartData.pointRadius = 3;
            //LinechartData.pointHoverRadius = 7;
            //LinechartData.pointColor = "blue";
            //LinechartData.pointBackgroundColor = "green";
            //LinechartData.data = new List<int> { 2666, 2778, 4912, 3767, 6810, 5670, 4820, 15073, 10687, 8432 };
            #endregion


            var LinechartData2 = new Dashboard_SalesGraph();
            LinechartData2.Label = "Digital Goods";
            LinechartData2.fill = "false";
            LinechartData2.borderWidth = 2;
            LinechartData2.lineTension = 0;
            LinechartData2.spanGaps = "true";
            LinechartData2.borderColor = "#efefef";
            LinechartData2.pointRadius = 3;
            LinechartData2.pointHoverRadius = 7;
            LinechartData2.pointColor = "#efefef";
            LinechartData2.pointBackgroundColor = "#efefef";
            LinechartData2.data = new List<int> { 2666, 2778, 4912, 3767, 6810, 5670, 4820, 15073, 10687, 8432 };


            var graph = new LineGraph();
            graph.LineGraphData = new List<Dashboard_SalesGraph> { /*LinechartData ,*/ LinechartData2 };
            graph.QuarterData = new List<string> { "2011 Q1", "2011 Q2", "2011 Q3", "2011 Q4", "2012 Q1", "2012 Q2", "2012 Q3", "2012 Q4", "2013 Q1", "2013 Q2" };
            graph.Gapdata = 5000;

            return Ok(graph);
        }
        /// <summary>
        /// This Method Consist the Data For the small tiles 
        /// </summary>
        /// <returns> It will return the object of TilesCard</returns>
        [HttpPost]
        public ActionResult TemplateData()
        {
            var Template = new Dashboard_BoxTemplate();
            Template.Info = 21;
            Template.Bounce = "23%";
            Template.Registration = 211;
            Template.visitors = 422;
            return Ok(Template);
        }
        /// <summary>
        /// It Method consist the data for the Todo list 
        /// </summary>
        /// <returns> It will return the ojbect of the ToDo List</returns>
        [HttpPost]
        public IActionResult TODO_List()
        {


            var TODO1 = new Dashboard_To_Do();
            TODO1.ToDo = new List<string> { "Design a nice theme", "Make the theme responsive", "Let theme shine like a star", "Let theme shine like a star ", "Check your messages and notifications", "Let theme shine like a star " };
            TODO1.Time = new List<string> { "2 min", "4 min", "1 Day", "3 Day", "1 week", "1 month" };
            TODO1.Status = new List<string> { "badge badge-success", "badge badge-danger", "badge badge-warning", "badge badge-success", "badge badge-danger", "badge badge-warning" };


            return Ok(TODO1);
        }
        /// <summary>
        /// IT Conist the Message For the Inbox of V1
        /// </summary>
        /// <returns>It will return the object of the ChatBox</returns>
        [HttpPost]
        public IActionResult ChatBox()
        {
            #region ChatBox Extra Message
            //var chat1 = new ChatBox();
            //chat1.Name = "Alexander Pierce";
            //chat1.Message = "Hi Ritesh how are you";
            //chat1.Time = "23 Jan 5:37 pm";
            //chat1.Image = "/img/user1-128x128.jpg";

            //var chat2 = new ChatBox();
            //chat2.Name = "Sarah Bullock";
            //chat2.Message = "Hi Ritesh how are you";
            //chat2.Time =  "23 Jan 5:37 pm";
            //chat2.Image = "/img/user1-128x128.jpg";
            //var chat3 = new ChatBox();
            //chat3.Name = "Alexander Pierce";
            //chat3.Message = "Hi Ritesh how are you";
            //chat3.Time = "23 Jan 5:37 pm";
            //chat3.Image = "/img/user1-128x128.jpg"; 
            //var chat4 = new ChatBox();
            //chat4.Name = "Alexander Pierce";
            //chat4.Message = "Hi Ritesh how are you";
            //chat4.Time = "23 Jan 5:37 pm";
            //chat4.Image = "/img/user1-128x128.jpg";
            #endregion
            var chat5 = new ChatBox();
            chat5.Name = "Alexander Pierce";
            chat5.Message = "Is this template really for free? That's unbelievable!";
            chat5.Time = "23 Jan 5:37 pm";
            chat5.Image = "/img/user1-128x128.jpg";

            var chat6 = new ChatBox();
            chat6.Name = "Sarah Bullock";
            chat6.Message = "You better believe it!";
            chat6.Time = "23 Jan 5:37 pm";
            chat6.Image = "/img/user1-128x128.jpg";
            var chat7 = new ChatBox();
            chat7.Name = "Alexander Pierce";
            chat7.Message = "Working with AdminLTE on a great new app! Wanna join?";
            chat7.Time = "23 Jan 5:37 pm";
            chat7.Image = "/img/user1-128x128.jpg";
            var chat8 = new ChatBox();
            chat8.Name = "Sarah Bullock";
            chat8.Message = "I would love to.";
            chat8.Time = "23 Jan 5:37 pm";
            chat8.Image = "/img/user1-128x128.jpg";


            var MessageData = new ChatBoxModel();
            MessageData.Inbox = new List<ChatBox> { /*chat1,chat2, chat3,chat4,*/ chat5, chat6, chat7, chat8 };
            MessageData.OwnerName = "Sarah Bullock";
            return Ok(MessageData);
        }
        /// <summary>
        /// It Consist the Data for the visitor
        /// </summary>
        /// <returns> It will return the object of Visitor Map</returns>
        [HttpPost]
        public IActionResult Map()
        {

            var MapData = new Dashboard_Map();
            MapData.CountryData = new List<string> { "US: 398", "SA: 400", "CA: 1000", " DE: 500", "FR: 760", "CN: 300", "AU: 700", " BR: 600" };


            return Ok(MapData);
        }


        public IActionResult DashboardV2()
        {
            return View();
        }
        /// <summary>
        /// It consist the data for Templates
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DashboardV2Template()
        {
            var Template = new DashboardV2Box();

            Template.Inventory = 21;
            Template.mention = 23;
            Template.Downloads = 211;
            Template.Messages = 422;
            return Ok(Template);
        }

        /// <summary>
        /// It consist the data for Templates
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //public IActionResult Call(string phoneNumber)
        //{
        //    var phone = new ABC();
        //    phone.Phone = "7021663819";
        //    // Do something with the phone number, such as dialing it.
        //    return Ok(phone);
        //}


        /// <summary>
        /// It Consist the data for the small tiles item
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult V2InfoBox()
        {
            var TemplateInfo = new InfoBox();
            TemplateInfo.Traffic = 21;
            TemplateInfo.Likes = 23;
            TemplateInfo.Sales = 211;
            TemplateInfo.NewMember = 422;
            return Ok(TemplateInfo);
        }

        /// <summary>
        /// It consist the data for the areachart of v2
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AreachartV2()
        {
            #region Area Chart Multiple Data
            //var AreaInfo = new RecapModel();
            //AreaInfo.Label = "Digital goods";
            //AreaInfo.backgroundColor = "yellow";
            //AreaInfo.borderColor = "green";
            //AreaInfo.pointColor = "blue";
            //AreaInfo.pointStrokeColor = "red";
            //AreaInfo.pointRadius = "false";
            //AreaInfo.pointHighlightStroke = "rgba(220,220,220,1)";
            //AreaInfo.data = new List<int> { 21, 12, 33, 45, 66, 7, 45 };

            //var AreaInfo2 = new RecapModel();
            //AreaInfo2.Label = "Electronic Items";
            //AreaInfo2.backgroundColor = "red";
            //AreaInfo2.borderColor = "green";
            //AreaInfo2.pointRadius = "false";
            //AreaInfo2.pointColor = "navyblue";
            //AreaInfo2.pointStrokeColor = "red";
            //AreaInfo2.pointHighlightStroke = "rgba(220,220,220,1)";
            //AreaInfo2.data = new List<int> { 21, 12, 33, 56, 21, 7, 78 };
            #endregion

            var AreaInfo4 = new RecapModel();
            AreaInfo4.Label = "Digital Goods";
            AreaInfo4.backgroundColor = "rgba(210, 214, 222, 1)";
            AreaInfo4.borderColor = "rgba(210, 214, 222, 1)";
            AreaInfo4.pointRadius = "false";
            AreaInfo4.pointColor = "#3b8bba";
            AreaInfo4.pointStrokeColor = "rgba(60,141,188,1)";
            AreaInfo4.pointHighlightStroke = "rgba(60,141,188,1)";
            AreaInfo4.data = new List<int> { 28, 48, 40, 19, 86, 27, 90 };

            var AreaInfo5 = new RecapModel();
            AreaInfo5.Label = "Electronics";
            AreaInfo5.backgroundColor = "rgba(60,141,188,0.9)";
            AreaInfo5.borderColor = "rgba(60,141,188,0.8)";
            AreaInfo5.pointRadius = "false";
            AreaInfo5.pointColor = "rgba(210, 214, 222, 1)";
            AreaInfo5.pointStrokeColor = "#c1c7d1";
            AreaInfo5.pointHighlightStroke = "rgba(220,220,220,1)";
            AreaInfo5.data = new List<int> { 65, 59, 80, 81, 56, 55, 40 };

            var GoalList = new GoalCompletionList();
            GoalList.GoalMessage = "Add Products to Cart";
            GoalList.Target = 200;
            GoalList.Reach = 160;
            GoalList.AlertType = "progress-bar bg-primary";
            var GoalList1 = new GoalCompletionList();
            GoalList1.GoalMessage = "Complete Purchase";
            GoalList1.Target = 400;
            GoalList1.Reach = 310;
            GoalList1.AlertType = "progress-bar bg-danger";
            var GoalList2 = new GoalCompletionList();
            GoalList2.GoalMessage = "Visit Premium Page";
            GoalList2.Target = 800;
            GoalList2.Reach = 480;
            GoalList2.AlertType = "progress-bar bg-success";
            var GoalList3 = new GoalCompletionList();
            GoalList3.GoalMessage = "Send Inquiries";
            GoalList3.Target = 500;
            GoalList3.Reach = 250;
            GoalList3.AlertType = "progress-bar bg-warning";

            #region Extra Goal Completion Data
            //var GoalList4 = new GoalCompletionList();
            //GoalList4.GoalMessage = "MobileSell Rate";
            //GoalList4.Target = 500;
            //GoalList4.Reach = 160;
            //GoalList4.AlertType = "progress-bar bg-primary";
            //var GoalList5 = new GoalCompletionList();
            //GoalList5.GoalMessage = "Stationary Item ";
            //GoalList5.Target = 400;
            //GoalList5.Reach = 370;
            //GoalList5.AlertType = "progress-bar bg-danger";
            #endregion

            var salesValue = new AreaChartRecap();
            salesValue.AreaGraphData = new List<RecapModel> { /*AreaInfo,AreaInfo2 ,*/ AreaInfo4, AreaInfo5 };
            salesValue.GoalListData = new List<GoalCompletionList> { GoalList, GoalList1, GoalList2, GoalList3/*, GoalList4, GoalList5*/ };
            salesValue.Month = new List<string> { "January", "February", "March", "April", "May", "June", "July" };

            salesValue.Revenue = 21110;
            salesValue.RevenueGrowth = 20;
            salesValue.Cost = 2110;
            salesValue.CostWarning = 2000;
            salesValue.Profit = 20;
            salesValue.ProfitPercentage = 21;
            salesValue.Goal = 211;
            salesValue.GoalRate = 322;
            salesValue.DateRange = " 21 July ,2014 to 22 jan, 2022";
            return Ok(salesValue);
        }
        /// <summary>
        /// It consist the The Data CartoGram Graph
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult VisitorsReport()
        {
            var visitorvalue = new UsVisitor();
            visitorvalue.vistorslist = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            visitorvalue.ReferalNo = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            visitorvalue.organiclist = new List<int> { 21, 12, 33, 45, 66, 7, 45 };

            visitorvalue.VisitorsAvg = 7654;
            visitorvalue.ReferalPercent = "32%";
            visitorvalue.OrganicPercentage = "31%";
            return Ok(visitorvalue);
        }
        /// <summary>
        /// It Consist the data for the dounut of V2
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public IActionResult BrowserUse()
        {
            var Browse = new BrowserUsage();
            Browse.Data = new List<int> { 700, 500, 400, 600, 300, 100 };
            Browse.BackgroundColor = new List<string> { "#f56954", "#00a65a", "#f39c12", "#00c0ef", "#3c8dbc", "#d2d6de" };
            var DoughtNut = new DoughNutGraph();
            DoughtNut.DounutData = new List<BrowserUsage> { Browse };
            DoughtNut.BrowserName = new List<string> { "Chrome", "IE", "FireFox", "Safari", "Opera", "Navigator" };
            DoughtNut.DounutAlertType = new List<string> { "text-danger", "text-success", "text-warning", "text-info", "text-primary", "text-secondary" };

            return Ok(DoughtNut);
        }
        /// <summary>
        /// It Consist the data for the Newest order Received
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult LatestOrders()
        {
            var orderdata = new LatestOrder();
            orderdata.Orderid = new List<string> { "OR9842", "OR1848", "OR7429", "OR7429", "OR7429", "OR7429" };
            orderdata.item = new List<string> { "Call of Duty IV", "Samsung Smart TV", "iPhone 6 Plus", "Samsung Smart TV", "Samsung Smart TV", "Call of Duty IV" };
            orderdata.Status = new List<string> { "Pending", "Delivered", "waiting", "Pending", "Pending", "Delivered" };
            orderdata.Popularity = new List<string> { "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63", "90,80,90,-70,61,-83,63" };
            orderdata.BadgeName = new List<string> { "badge badge-success", "badge badge-danger", "badge badge-warning", "badge badge-success", "badge badge-success", "badge badge-danger" };

            return Ok(orderdata);
        }
        /// <summary>
        /// IT consist the detail of the Recent Items 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RecentItem()
        {

            var product = new RecentProduct();
            product.Name = new List<string> { "Samsung TV", "Bicycle", "Xbox One", "PlayStation 4" };
            product.price = new List<string> { "$1800", "$700", "$350", "$399" };
            product.ProductDetails = new List<string> { "Samsung 32\" 1080p 60Hz LED Smart HDTV.", "26\" Mongoose Dolomite Men's 7-speed, Navy Blue.", "Xbox One Console Bundle with Halo Master Chief Collection.", "PlayStation 4 500GB Console (PS4)" };
            product.ProductImg = new List<string> { "/img/default-150x150.png", "/img/default-150x150.png", "/img/default-150x150.png", "/img/default-150x150.png" };
            return Ok(product);
        }
        /// <summary>
        /// It Consist the message of the chatbox of Dashboard V2 chat box
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult MessageBoxV2()
        {
            //var chat1 = new ChatModel();
            //chat1.Name = "Sarah Bullock";
            //chat1.Message = "Hi Ritesh how are you";
            //chat1.Time = "23 Jan 5:37 pm";
            //chat1.Image = "/img/user1-128x128.jpg";

            //var chat2 = new ChatModel();
            //chat2.Name = "Sarah Bullock";
            //chat2.Message = "Hi Ritesh how are you";
            //chat2.Time = "23 Jan 5:37 pm";
            //chat2.Image = "/img/user1-128x128.jpg";
            //var chat3 = new ChatModel();
            //chat3.Name = "Sarah Bullock";
            //chat3.Message = "Hi Ritesh how are you";
            //chat3.Time = "23 Jan 5:37 pm";
            //chat3.Image = "/img/user1-128x128.jpg";
            //var chat4 = new ChatModel();
            //chat4.Name = "Sarah Bullock";
            //chat4.Message = "Hi Ritesh how are you";
            //chat4.Time = "23 Jan 5:37 pm";
            //chat4.Image = "/img/user1-128x128.jpg";
            var chat5 = new ChatModel();
            chat5.Name = "Alexander Pierce";
            chat5.Message = "Is this template really for free? That's unbelievable!";
            chat5.Time = "23 Jan 5:37 pm";
            chat5.Image = "/img/user1-128x128.jpg";

            var chat6 = new ChatModel();
            chat6.Name = "Sarah Bullock";
            chat6.Message = "You better believe it!";
            chat6.Time = "23 Jan 5:37 pm";
            chat6.Image = "/img/user1-128x128.jpg";
            var chat7 = new ChatModel();
            chat7.Name = "Alexander Pierce";
            chat7.Message = "Working with AdminLTE on a great new app! Wanna join?";
            chat7.Time = "23 Jan 5:37 pm";
            chat7.Image = "/img/user1-128x128.jpg";
            var chat8 = new ChatModel();
            chat8.Name = "Sarah Bullock";
            chat8.Message = "I would love to.";
            chat8.Time = "23 Jan 5:37 pm";
            chat8.Image = "/img/user1-128x128.jpg";



            var MessageBox = new MessageBox();
            MessageBox.InboxData = new List<ChatModel> { /*chat1, chat2, chat3, chat4,*/ chat5, chat6, chat7, chat8 };
            MessageBox.OwnerName = "Sarah Bullock";



            return Ok(MessageBox);

        }
        /// <summary>
        /// IT consist the Information of New Member joiners
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NewMembers()
        {
            var members = new LatestMember();
            members.ImageLink = new List<string> { "/img/user7-128x128.jpg", "/img/user8-128x128.jpg", "/img/user1-128x128.jpg", "/img/user6-128x128.jpg" };
            members.Name = new List<string> { "Ritesh Singh", "Prem Ranjan", "Raj Gupta", "Aman Raj" };
            members.Date = new List<string> { "12 August", "01 July", "03 jan", "03 Jan" };

            return Ok(members);
        }
        [HttpGet]
        public IActionResult BottomNavbarModal()
        {
            //BottomNavbarModelDTO _BottomNavbarModal = new BottomNavbarModelDTO();
            List<BottomNavbarModelDTO> _BottomNavbarModal = new List<BottomNavbarModelDTO>()
                {
                  new BottomNavbarModelDTO { Title="Phone", Icon= "Phone", IconClass="fa fa-phone symbol fa-2x",URL= "https://www.facebook.com/login" },
                  new BottomNavbarModelDTO { Title="XYZ", Icon= "Facebook", IconClass="fab fa-facebook fa-2x",URL= "https://www.facebook.com/login" },
                  new BottomNavbarModelDTO { Title="LMN", Icon = "Email", IconClass="fa fa-envelope fa-2x",URL= "https://www.facebook.com/login" },
                  new BottomNavbarModelDTO { Title="PQR", Icon = "ContactUs", IconClass="fa fa-envelope fa-2x",URL= "https://www.facebook.com/login" },
               };
            //return PartialView("~/wwwroot/css/Bottom.css", _BottomNavbarModal);
            return Json(_BottomNavbarModal);
        }

       
    }
}


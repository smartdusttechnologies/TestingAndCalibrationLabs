using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Business.Data.Repository.QueryBuilder;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder;
using System.Linq;
using Microsoft.AspNetCore.Razor.Language;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IMapper _mapper;
        public DashboardController(IDashboardService dashboardService, IMapper mapper)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {


           // var Data = _dashboardService.Template("dfdf");
           
            
            var salesValue = new SalesModel();
            //salesValue.Month = new List<string> { "January", "February", "March", "April", "May", "June", "July" };
            //salesValue.salesData1 = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            salesValue.Month = new List<object> ();
            salesValue.salesData = new List<SalesComponentDataModel>(); 
            
            //for (var item=1; item <= Data.)
            //var salesModeldata = new SalesComponentDataModel();
            //salesModeldata.label = "";
            //salesModeldata.pointRadius = "false";
            //salesModeldata.pointHighlightFill = "";
            //salesModeldata.backgroundColor = "rgba("+ 60*item+ "," + item*141+","+ item*188+ "," + item* 0.9+") ";
            //salesModeldata.borderColor  = "rgba(" + 60 * item + "," + item * 141 + "," + item * 188 + "," + item * 0.8 + ") ";

            //salesModeldata.pointColor = "#"+3*item+"b8bba";
            //salesModeldata.pointStrokeColor =  "rgba(" + 60 * item + "," + item * 141 + "," + item * 188 + "," + item * 1 + ") ";
            //salesModeldata.pointHighlightFill = "#fff ";
            //salesModeldata.pointHighlightStroke = "rgba(" + 60 * item + "," + item * 141 + "," + item * 188 + "," + item * 1 + ") ";

            //salesValue.salesData.Add(salesModeldata);
            var count = typeof(DashboardModel).GetProperties().Count();
            var salesModeldata = new SalesComponentDataModel();
            //For future use
            //for (  var item = 0; item< Data.Dictionary.Count; item++)
            //{


            //    if (item > 0)
            //    {
            //        //

            //        salesModeldata.label = Data.Dictionary.ToList()[item].Key;
            //        salesModeldata.pointRadius = "false";
            //        salesModeldata.pointHighlightFill = "";
            //        salesModeldata.backgroundColor = "rgba(" + 60 * item + "," + item * 141 + "," + item * 188 + "," + item * 0.9 + ") ";
            //        salesModeldata.borderColor = "rgba(" + 60 * item + "," + item * 141 + "," + item * 188 + "," + item * 0.8 + ") ";

            //        salesModeldata.pointColor = "#" + 3 * item + "b8bba";
            //        salesModeldata.pointStrokeColor = "rgba(" + 60 * item + "," + item * 141 + "," + item * 188 + "," + item * 1 + ") ";
            //        salesModeldata.pointHighlightFill = "#fff ";
            //        salesModeldata.pointHighlightStroke = "rgba(" + 60 * item + "," + item * 141 + "," + item * 188 + "," + item * 1 + ") ";
            //        salesModeldata.Data = new List<object>();

            //        foreach (var datainfo in Data.Dictionary.ToList()[item].Value)
            //        {
                       
            //            salesModeldata.Data.Add(datainfo);
            //        }
            //        salesValue.salesData.Add(salesModeldata);
            //    }
            //    else
            //    {
            //        foreach (var datainfo in Data.Dictionary.ToList()[item].Value)
            //        {
            //            salesValue.Month.Add(datainfo);


            //        }
            //    }
            //}


            
            //salesValue.SalesData2 = new List<int> { 25, 18, 30, 45, 6, 67, 45 };
            salesValue.SalesName = new List<string> { "Instore Sales", "Download Sales", "Mail-Order Sales" };
            salesValue.DataSet = new List<int> { 15, 12, 43 };

            var Graph = new Dashboard_SalesGraph();
            Graph.QuarterData = new List<string> { "2011 Q1", "2011 Q2", "2011 Q3", "2011 Q4", "2012 Q1", "2012 Q2", "2012 Q3", "2012 Q4", "2013 Q1", "2013 Q2" };
            Graph.data = new List<int> { 2666, 2778, 4912, 3767, 6810, 5670, 4820, 15073, 10687, 8432 };

            var MapData = new Dashboard_Map();
            MapData.CountryData = new List<string> { "US: 398", "SA: 400", "CA: 1000", " DE: 500", "FR: 760", "CN: 300", "AU: 700", " BR: 600" };

            var Template = new Dashboard_BoxTemplate();
            Template.info = 21;
            Template.bounce = "23%";
            Template.Registration = 211;
            Template.visitors = 422;

            var TODO = new Dashboard_To_Do();
            TODO.ToDo = new List<string> { "Hi ritesh i was sent from the T0-DO controller", "Hi ritesh i was sent from the T0-DO controller", "Hi ritesh i was sent from the T0-DO controller" };
            TODO.Time = new List<string> { "4 min", "4 min", "4 min" };
            TODO.Status = new List<string> { "badge badge-success", "badge badge-danger", "badge badge-warning" };


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

            var Modelset = new Dashboard_Common();
            Modelset.Graph = Graph;
            Modelset.SalesModel = salesValue;
            Modelset.map = MapData;
            Modelset.template = Template;
            Modelset.To_Do = TODO;
            Modelset.ChatData = new List<ChatModel> { chat1, chat2, chat3, chat4, chat5, chat6 };


            return View(Modelset);
        }
    }
}

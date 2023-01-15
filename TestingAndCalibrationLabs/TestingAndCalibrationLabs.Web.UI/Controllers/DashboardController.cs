using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models;

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
            var salesValue = new SalesModel();
            salesValue.Month = new List<string> { "January", "February", "March", "April", "May", "June", "July" };
            salesValue.SalesData1 = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            salesValue.SalesData2 = new List<int> { 25, 18, 30, 45, 6, 67, 45 };
            salesValue.SalesName = new List<string> { "Instore Sales", "Download Sales", "Mail-Order Sales" };
            salesValue.DataSet = new List<int> { 15, 12, 43 };

            var Graph = new Dashboard_SalesGraph();
            Graph.QuarterData = new List<string> { "2011 Q1", "2011 Q2", "2011 Q3", "2011 Q4", "2012 Q1", "2012 Q2", "2012 Q3", "2012 Q4", "2013 Q1", "2013 Q2" };
            Graph.Data = new List<int> { 2666, 2778, 4912, 3767, 6810, 5670, 4820, 15073, 10687, 8432 };

            var MapData = new Dashboard_Map();
            MapData.CountryData = new List<string> { "US: 398", "SA: 400", "CA: 1000", " DE: 500", "FR: 760", "CN: 300", "AU: 700", " BR: 600" };

            var Template = new Dashboard_BoxTemplate();
            Template.Info = 21;
            Template.Bounce = "23%";
            Template.Registration = 211;
            Template.Visitors = 422;

            var TODO = new Dashboard_To_Do();
            TODO.ToDo = new List<string>{ "Hi ritesh i was sent from the T0-DO controller", "Hi ritesh i was sent from the T0-DO controller" , "Hi ritesh i was sent from the T0-DO controller"};
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


            var ModelList = new Dashboard_Common();
            ModelList.Graph = Graph;
            ModelList.SalesModel = salesValue;
            ModelList.Map = MapData;
            ModelList.Template = Template;
            ModelList.To_Do = TODO;
            ModelList.ChatData = new List<ChatModel> { chat1, chat2, chat3, chat4, chat5, chat6 };


            return View(ModelList);
        }
    }
}

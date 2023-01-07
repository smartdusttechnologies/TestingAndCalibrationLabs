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
            TODO.ToDo = new List<string>{ "Hi ritesh i was sent from the T0-DO controller"};
            TODO.Time =   "4 min"; 


         var ModelList = new Dashboard_Common();
            ModelList.Graph = Graph;
            ModelList.SalesModel = salesValue;
            ModelList.Map = MapData;
            ModelList.Template = Template;
            ModelList.To_Do = TODO;


            return View(ModelList);
        }
    }
}

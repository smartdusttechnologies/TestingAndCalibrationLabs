using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1;
using TestingAndCalibrationLabs.Web.UI.Models;


namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var salesValue = new SalesModel();
            salesValue.Month = new List<string> { "January", "February", "March", "April", "May", "June", "July" };
            salesValue.salesData1 = new List<int> { 21, 12, 33, 45, 66, 7, 45 };
            salesValue.SalesData2 = new List<int> { 25, 18, 30, 45, 6, 67, 45 };
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
            TODO.ToDo = new List<string>{ "Hi ritesh i was sent from the T0-DO controller"};
            TODO.time =   "4 min"; 


         var Modelset = new Dashboard_Common();
            Modelset.Graph = Graph;
            Modelset.SalesModel = salesValue;
            Modelset.map = MapData;
            Modelset.template = Template;
            Modelset.To_Do = TODO;


            return View(Modelset);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Web.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// Controllers Loads the Home Page Application
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Default Action of the Home Cotroller
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// UI Shows the Various Plans and respective Prices
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// UI will get the information from the User
        /// </summary>
        /// <returns></returns>
        public IActionResult TestDetails()
        {
            //here hardcoding the values instread of accessing from the DB
            List<TestDetailsModel> TestDetailsOfUsers = new List<TestDetailsModel>();
            for(var i = 0; i < 5; i++)
            {
                var tempDetails=new TestDetailsModel();
                tempDetails.SampleType = "Testing Tools";
                tempDetails.SampleDetails = "NA";
                tempDetails.DateOfTP= DateTime.Now;
                tempDetails.JobCode = 1122;
                tempDetails.SampleId = 5566;
                tempDetails.NumberOfSampleQuantity = 10;
                tempDetails.TestName = "Testing Meterial";
                tempDetails.TestMethod = "Meterial Strenght";
                tempDetails.PersonAuthorized = "Sumanth";
                tempDetails.ReceivedOn= DateTime.Now;
                tempDetails.TargedOn = DateTime.Now;
                tempDetails.CompletedOn= DateTime.Now;
                tempDetails.Remarks = "Some Comments";
                TestDetailsOfUsers.Add(tempDetails);
                var tempDetailss = new TestDetailsModel();
                tempDetailss.SampleType = "Testing Meterials";
                tempDetailss.SampleDetails = "NA";
                tempDetailss.DateOfTP = DateTime.Now;
                tempDetailss.JobCode = 2299;
                tempDetailss.SampleId = 1155;
                tempDetailss.NumberOfSampleQuantity = 30;
                tempDetailss.TestName = "Testing Product";
                tempDetailss.TestMethod = "Meterial Quality";
                tempDetailss.PersonAuthorized = "Rishi";
                tempDetailss.ReceivedOn = DateTime.Now;
                tempDetailss.TargedOn = DateTime.Now;
                tempDetailss.CompletedOn = DateTime.Now;
                tempDetailss.Remarks = "Some Guidance";
                TestDetailsOfUsers.Add(tempDetailss);
            }
            return View(TestDetailsOfUsers);
        }
    }
}

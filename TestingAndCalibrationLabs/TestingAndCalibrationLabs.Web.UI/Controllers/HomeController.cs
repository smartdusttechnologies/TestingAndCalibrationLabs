using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Web.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TestingAndCalibrationLabs.Business.Core.Model;


namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrganizationService _orgnizationService;
        private readonly IMapper _mapper;
        public HomeController(IAuthenticationService authenticationService, IOrganizationService orgnizationService,IMapper mapper)
        {
            _authenticationService = authenticationService;
            _orgnizationService = orgnizationService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = PolicyTypes.Users.Manage)]
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// UI will get the information from the User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Policy = PolicyTypes.Users.Manage)]
        public IActionResult TestDetails()
        {
            // here hardcoding the Grid heddings values instead of accessing from the DB
            List<string> TableHeadding = new List<string>();
            TableHeadding.Add("Actions");
            TableHeadding.Add("Sample Type");
            TableHeadding.Add("Sample Details");
            TableHeadding.Add("Date Of TP");
            TableHeadding.Add("Job Code");
            TableHeadding.Add("Sample ID");
            TableHeadding.Add("Number Of Sample Quality");
            TableHeadding.Add("Test Name");
            TableHeadding.Add("Test Method");
            TableHeadding.Add("Person Authorized");
            TableHeadding.Add("Received On");
            TableHeadding.Add("Targeted On");
            TableHeadding.Add("Completed On");
            TableHeadding.Add("Remarks");
            //here hardcoding the values of Grid instead of accessing from the DB
            List<TestDetailsModel> TestDetailsOfUsers = new List<TestDetailsModel>();
            for (var i = 0; i < 20; i++)
            {
                var tempDetails = new TestDetailsModel();
                tempDetails.SampleType = "Testing Tools";
                tempDetails.SampleDetails = "NA";
                tempDetails.DateOfTP = DateTime.Now;
                tempDetails.JobCode = 1122;
                tempDetails.SampleId = 5566;
                tempDetails.NumberOfSampleQuantity = 10;
                tempDetails.TestName = "Testing Solutions";
                tempDetails.TestMethod = "Meterial Strenght";
                tempDetails.PersonAuthorized = "Sumanth";
                tempDetails.ReceivedOn = DateTime.Now;
                tempDetails.TargedOn = DateTime.Now;
                tempDetails.CompletedOn = DateTime.Now;
                tempDetails.Remarks = "Some needed Comments";
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
            ViewBag.TableHeaddings = TableHeadding.Distinct();
            return View(TestDetailsOfUsers);
        }

        /// <summary>
        /// This Method Control is For Header
        /// </summary>
        /// <returns>PartilView return _HeaderStrip</returns>
        public IActionResult Headerstrip()
        {
            HeaderstripModelDTO _HeaderStrip = new HeaderstripModelDTO();
            _HeaderStrip.Contact = "9049894772";
            _HeaderStrip.Email = "tushardhangar12@gmail.com";
            _HeaderStrip.CompanyImageURl = "/image/smartdust_technologies_logo.jpg";
            _HeaderStrip.AwardImageURL1 = "/image/cvalibration_award.jpg";
            _HeaderStrip.AwardImageURL2 = "/image/award.jpg";
            _HeaderStrip.AwardImageURL3 = "/image/trophy-gold.jpg";
            _HeaderStrip.linkedlnURL = "https://www.linkedin.com/login";
            _HeaderStrip.FacebookURL = "https://www.facebook.com/login";
            return PartialView("~/Views/Home/HeaderstripTempleat.cshtml", _HeaderStrip);
        }

        /// <summary>
        /// This Method Control is For NewsStripTicker
        /// </summary>
        /// <returns>PartilView "~/Views/Home/_newsstripticker.cshtml" _Newsstrip</returns>
        public IActionResult NewsStripTicker()
        {
            var _Newsstrip = new NewsStripModelDTO();
            _Newsstrip.NewsStrip = new List<string> { "Delhi hit-and-run case live: Last rites of victim under way amid heavy police deployment", "Cricketer Rishabh Pant hospitalised after serious "};
            _Newsstrip.ImageIcon = "/image/new.gif";
            return PartialView("~/Views/Home/NewsstripTicker.cshtml", _Newsstrip);
        }
    }
}

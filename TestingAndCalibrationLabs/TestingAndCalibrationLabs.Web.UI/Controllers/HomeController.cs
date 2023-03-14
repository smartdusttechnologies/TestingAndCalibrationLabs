using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Web.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;


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

        /// <summary>
        /// Default Action of the Home Controller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       /// [Authorize(Policy = PolicyTypes.Users.Manage)]
        public IActionResult Index()
        {
            // here hardcoding the ImageSlide values instead of accessing from the DB
            var image = new List<ImageSlideModel>();
            image.Add(new ImageSlideModel { Image = "https://thumbs.dreamstime.com/b/teamwork-bees-bridge-gap-bee-swarm-making-chain-to-combine-two-parts-one-metaphor-business-community-55767925.jpg", Header = "Aman", Paragraph = "Kumar" });
            image.Add(new ImageSlideModel { Image = "https://thumbs.dreamstime.com/b/bandra-worli-sea-link-sunset-dadar-coast-51035486.jpg", Header = "Ritesh", Paragraph = "Raj" });
            image.Add(new ImageSlideModel { Image = "https://thumbs.dreamstime.com/b/amaranth-love-lies-bleeding-chain-link-fence-29603774.jpg", Header = "Prem", Paragraph = "Star" });
            
        
            return View(image);
      
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

        public ActionResult Create()
        {
            return View();
        }
    }
}

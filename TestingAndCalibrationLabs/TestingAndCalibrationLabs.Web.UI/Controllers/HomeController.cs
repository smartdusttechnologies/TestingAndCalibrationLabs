using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Web.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using LoginDTO = TestingAndCalibrationLabs.Web.UI.Models.LoginDTO;

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
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// UI Shows the Orgnizations names in dropdown list
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            List<Business.Core.Model.Organization> organizations = _orgnizationService.Get();
            List<SelectListItem> organizationNames = organizations.Select(x => new SelectListItem { Text = x.OrgName, Value = x.Id.ToString() }).ToList();
            ViewBag.Organizations = organizationNames;
            return View();
        }

        /// <summary>
        /// Method to get the Login details from UI and Process Login.
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Login(LoginDTO loginRequest)
        {   
            var loginReq = new LoginRequest { UserName = loginRequest.UserName, Password = loginRequest.Password };
            RequestResult<LoginToken> result = _authenticationService.Login(loginReq);

            if (result.IsSuccessful)
            {
                HttpContext.Session.SetString("Token", result.RequestedObject.AccessToken);

                return Json(new { status = true, message = "Login Successfull!" });
            }
            return View();
        }
        /// <summary>
        /// UI will get the information from the User
        /// </summary>
        /// <returns></returns>
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

        public IActionResult PlanPricing()
        {
            return View();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly ISurveyService _surveyService;
        /// <summary>
        /// Default Action of the Home Cotroller
        /// </summary>
        /// <returns></returns>
        /// 
        public SurveyController(ILogger<HomeController> logger, ISurveyService surveyService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _surveyService = surveyService;
        }
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            return View();
        }

        public IActionResult Survey()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Survey([Bind] SurveyModel data)
        {
            System.Threading.Thread.Sleep(1000);
            if (ModelState.IsValid)
            {
                var emailId = new List<string>();
                emailId.Add(data.Email);
                var getbusinessModel = new Business.Core.Model.SurveyModel
                {
                    Name = data.Name,
                    Address = data.Address,
                    City = data.City,
                    Mobile = data.Mobile,
                    State=data.State,
                    PinCode = data.PinCode,
                    TestingType = data.TestingType,
                    Comments = data.Comments,
                    Email = emailId
                };
                
                _surveyService.Add(getbusinessModel);
                TempData["IsTrue"] = true;
                //System.Threading.Thread.Sleep(3000);
                return RedirectToAction("Survey");
            }
            return View(data);
        }
    }
}
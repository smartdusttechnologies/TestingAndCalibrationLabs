using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestReportModel = TestingAndCalibrationLabs.Web.UI.Models.TestReportModel;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class TestReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly ITestReportService _newUIService;
        private readonly IGoogleUploadService _googleUploadService;
        
        /// <summary>
        /// Default Action of the NewUIController
        /// </summary>
        /// <returns></returns>
      
        public object ResponseBody { get; private set; }

        public TestReportController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment, IConfiguration configuration, ITestReportService newUIService,IGoogleUploadService googleUploadService)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _newUIService = newUIService;
            _googleUploadService = googleUploadService;
        }

        public object NewUIModel { get; private set; }
        public string ImageVal { get; private set; }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TestReportModel data)
        {
            if (ModelState.IsValid)
            {
                var getbusinessModel = new Business.Core.Model.TestReportModel
                {
                    Client = data.Client,
                    DataUrl = data.DataUrl,
                    FilePath = data.FilePath,
                    JobId = data.JobId,
                    Name = data.Name,
                    DateTime = DateTime.Now.Date,       //Accept the Current Date only
                    Email = data.Email
                };
                _googleUploadService.UploadFile(getbusinessModel);
                
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(data);
        }
    }
}
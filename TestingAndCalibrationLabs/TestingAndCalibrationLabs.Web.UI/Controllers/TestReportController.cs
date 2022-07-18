using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestReportModel = TestingAndCalibrationLabs.Web.UI.Models.TestReportModel;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class TestReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly ITestReportService _newUIService;
        private readonly DriveDownloadFile _googleUploadService;
        private readonly IEmailService _emailService;
        private readonly ITestReportRepository _testReportRepository;
        private readonly ITestReportService _testReportService;


        /// <summary>
        /// Default Action of the NewUIController
        /// </summary>
        /// <returns></returns>

        public object ResponseBody { get; private set; }

        public TestReportController(ILogger<HomeController> logger, ITestReportRepository testReportRepository, ITestReportService testReportService, IEmailService emailService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration, ITestReportService newUIService, DriveDownloadFile googleUploadService)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _newUIService = newUIService;
            _googleUploadService = googleUploadService;
            _emailService = emailService;
            _testReportRepository = testReportRepository;
            _testReportService = testReportService;
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
        public ActionResult Index([Bind] EmailModel emailModel, TestReportModel testReportModel, bool IsSendAndUpload)
        {
            if (ModelState.IsValid)
            {
                var emailId = new List<string>();
                emailId.Add(testReportModel.Email);
                var getbusinessModel = new Business.Core.Model.TestReportModel
                {
                    Id = testReportModel.Id,
                    Client = testReportModel.Client,
                    DataUrl = testReportModel.DataUrl,
                    FilePath = testReportModel.FilePath,
                    JobId = testReportModel.JobId,
                    Name = testReportModel.Name,
                    DateTime = DateTime.Now.Date,       //Accept the Current Date only
                    Email = testReportModel.Email
                };
                if (IsSendAndUpload == false)
                {
                    _googleUploadService.UploadFile(getbusinessModel);
                }
                else if (IsSendAndUpload == true)
                {

                   _googleUploadService.UploadFileAndSendMail(getbusinessModel);

                }
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(testReportModel);
        }

        [HttpGet]
        public ActionResult DataView(TestReportModel testReportModel)
        {
            var emailId = string.Join(",", testReportModel.Email);
            var services = _testReportRepository.Get();
            List<UI.Models.TestReportModel> data = new List<UI.Models.TestReportModel>();

            foreach (var item in services)
            {
                data.Add(new Models.TestReportModel
                {
                    Id = item.Id,
                    Client = item.Client,
                    DateTime = DateTime.Now.Date,
                    DataUrl = item.DataUrl,
                    Name = item.Name,
                    JobId = item.JobId,
                    FilePath = item.FilePath,
                    Email = item.Email 
                });
            }
            return View(data);
        }

        
        [HttpGet]
        public ActionResult TestReportDownload(int? Id)
        {
            if(Id == null)
            {
                 return NotFound();
            }
        
            var data = _testReportService.GetTestReport((int)Id);

            var getbusinessModel = new Business.Core.Model.TestReportModel
            {
                Id = data.Id,
                Client = data.Client,
                //DataUrl = data.DataUrl,
                FilePath = data.FilePath,
                JobId = data.JobId,
                Name = data.Name,
                DateTime = DateTime.Now.Date,       //Accept the Current Date only
                Email = data.Email
            };
            // Downloads File from Google Drive on fileId

            return RedirectToAction("DataView");
        }

        [HttpGet]
        public ActionResult TestReportMailSend( TestReportModel testReportModel, int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var data = _testReportService.GetTestReport((int)Id);

            if (data == null)
            {
                return NotFound();
            }

            var getbusinessModel = new Business.Core.Model.TestReportModel
            {
                Id = data.Id,
                Client = data.Client,
                FilePath = data.FilePath,
                JobId = data.JobId,
                Name = data.Name,
                DateTime = DateTime.Now.Date,       //Accept the Current Date only
                Email = data.Email
            };
            
            //Sends link
            _googleUploadService.WebLinkMail(getbusinessModel, data.Id);
            //return View(data);
            return RedirectToAction("DataView");
        }
    } 
}
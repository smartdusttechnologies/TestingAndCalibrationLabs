using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using TestingAndCalibrationLabs.Business.Common;
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
        private readonly IDriveDownloadFile _googleUploadService;
        private readonly IEmailService _emailService;
        private readonly ITestReportRepository _testReportRepository;
        private readonly ITestReportService _testReportService;
        private readonly IMapper _mapper;
        private string downloadData;

        /// <summary>
        /// Default Action of the Index
        /// </summary>
        /// <returns></returns>

        public TestReportController(ILogger<HomeController> logger, ITestReportRepository testReportRepository, IMapper mapper, ITestReportService testReportService, IEmailService emailService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration, ITestReportService newUIService, IDriveDownloadFile googleUploadService)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _newUIService = newUIService;
            _googleUploadService = googleUploadService;
            _emailService = emailService;
            _testReportRepository = testReportRepository;
            _testReportService = testReportService;
            _mapper = mapper;
        }

        /// <summary>
        /// To view the 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            return View();
        }
        /// <summary>
        /// To Upload or Upload and Send Mail 
        /// </summary>
        /// <param name="emailModel"></param>
        /// <param name="testReportModel"></param>
        /// <param name="IsSendAndUpload"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind] EmailModel emailModel, TestReportModel testReportModel, bool IsSendAndUpload)
        {
            if (ModelState.IsValid)
            {
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

        /// <summary>
        /// Action views/ shows the test report in database
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TestReportView()
        {
            List<Business.Core.Model.TestReportModel> TestReportList = _testReportService.Get();
            var testReportData = _mapper.Map<List<Business.Core.Model.TestReportModel>, List<Models.TestReportModel>>(TestReportList);
            return View(testReportData);
        }

        /// <summary>
        /// Action sends mail of the web page
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult sendEmail(TestReportModel testReportModel, int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var datafForMail = _testReportService.GetTestReport((int)Id);

            if (datafForMail == null)
            {
                return NotFound();
            }

            var getbusinessModel = new Business.Core.Model.TestReportModel
            {
                Id = datafForMail.Id,
                Client = datafForMail.Client,
                FilePath = datafForMail.FilePath,
                JobId = datafForMail.JobId,
                Name = datafForMail.Name,
                DateTime = DateTime.Now.Date,       //Accept the Current Date only
                Email = datafForMail.Email
            };

            //Sends link
            _googleUploadService.WebLinkMail(getbusinessModel, datafForMail.Id);
            //Redirect to Page "DataView"
            return RedirectToAction("TestReportView");
        }

        [HttpGet]
        public ActionResult TestReportDownload(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    return NotFound();
                }

                var testReportData = _testReportService.GetTestReport((int)Id);

                var getbusinessModel = new Business.Core.Model.TestReportModel
                {
                    Id = testReportData.Id,
                    Client = testReportData.Client,
                    FilePath = testReportData.FilePath,
                    JobId = testReportData.JobId,
                    Name = testReportData.Name,
                    DateTime = DateTime.Now.Date,       //Accept the Current Date only
                    Email = testReportData.Email
                };
                var fileid = testReportData.FilePath;
                var downloadData = _googleUploadService.DownloadGoogleFile(fileid);
                var memory = new MemoryStream();
                using (var stream = new FileStream(downloadData, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                
                return File(memory, Helpers.GetContentType(downloadData), Path.GetFileName(downloadData));
                //TempData["IsTrue"] = true;
                //return RedirectToAction("TestReport", "TestReportView");
                }
            finally
            {
               //System.IO.File.Delete((downloadData));
            }
        }
    }
}
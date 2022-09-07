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
using TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService;
using TestReportModel = TestingAndCalibrationLabs.Web.UI.Models.TestReportModel;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class TestReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly ITestReportService _testReportService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default Action of the Index
        /// </summary>
        /// <returns></returns>
        public TestReportController(ILogger<HomeController> logger, ITestReportRepository testReportRepository, IMapper mapper, ITestReportService testReportService, IEmailService emailService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration, IGoogleUploadDownloadService googleUploadDownloadService)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _emailService = emailService;
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
        public ActionResult Index([Bind] TestReportModel testReportModel, bool IsSendAndUpload)
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
                    _testReportService.UploadFile(getbusinessModel);
                }
                else if (IsSendAndUpload == true)
                {
                    _testReportService.UploadFileAndSendMail(getbusinessModel);
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
        [HttpPost]
        public ActionResult sendEmail(int? Id)
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
            var result = _mapper.Map<Business.Core.Model.TestReportModel, UI.Models.TestReportModel>(datafForMail);

            //Sends link
            var mailData = _testReportService.EmailLinkMail(datafForMail, datafForMail.Id);

            if (mailData)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// This is to download the Test Report Uploaded
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TestReportDownload(int Id)
        {
            var testReportData = _testReportService.GetTestReport((int)Id);
            List<Business.Core.Model.TestReportModel> TestReportList = _testReportService.Get();
            var fileid = testReportData.FilePath;
            return Ok(fileid);
        }

        /// <summary>
        /// This is used to download the Test Report.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public ActionResult DownloadFile(string fileId)
        {
            AttachmentModel attachment = _testReportService.DownLoadAttachment(fileId);
            var attachmentDTO = _mapper.Map<Business.Core.Model.AttachmentModel, UI.Models.AttachmentDTO>(attachment);
            if (attachmentDTO != null)
            {
                return File(attachmentDTO.FileStream, attachmentDTO.ContentType, attachmentDTO.FileName);
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
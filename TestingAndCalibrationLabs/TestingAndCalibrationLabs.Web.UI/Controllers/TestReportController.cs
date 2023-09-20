﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestReportDTO = TestingAndCalibrationLabs.Web.UI.Models.TestReportDTO;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class TestReportController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly ITestReportService _testReportService;
        private readonly IMapper _mapper;

        public TestReportController(ILogger<HomeController> logger, IMapper mapper, ITestReportService testReportService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
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
        /// <param name="testReportDTO"></param>
        /// <param name="IsSendAndUpload"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind] TestReportDTO testReportDTO, bool IsSendAndUpload)
        {
            if (ModelState.IsValid)
            {
                var testReportModel = _mapper.Map<TestReportDTO, TestReportModel>(testReportDTO);
                testReportModel.DateTime = DateTime.Now.Date;
                RequestResult<AttachmentModel> result = null;

                if (IsSendAndUpload)
                {
                    result = _testReportService.UploadFileAndSendMail(testReportModel);
                }
                else
                {
                    result =  _testReportService.UploadFile(testReportModel);
                }

                if (result.IsSuccessful)
                {
                    TempData["IsTrue"] = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Response = result.ValidationMessages.Select(x => x.Reason).ToList();
                }
            }
            return View();
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
            var testReportData = _mapper.Map<List<Business.Core.Model.TestReportModel>, List<Models.TestReportDTO>>(TestReportList);
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
            var datafForMail = _testReportService.Get((int)Id);

            if (datafForMail == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Business.Core.Model.TestReportModel, UI.Models.TestReportDTO>(datafForMail);

            //Sends link
            var isMailSendSuccessfully = _testReportService.SendTestReportEmail(datafForMail);

            if (isMailSendSuccessfully)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
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
            var testReportData = _testReportService.Get((int)Id);
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
            var attachmentDTO = _mapper.Map<AttachmentModel, Models.AttachmentDTO>(attachment);
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
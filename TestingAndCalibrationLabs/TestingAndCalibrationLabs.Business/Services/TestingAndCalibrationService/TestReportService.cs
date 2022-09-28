using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class TestReportService : ITestReportService
    {
        private readonly ITestReportRepository _testReportRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IEmailService _emailService;
        private readonly IGoogleDriveService _googleUploadDownloadService;

        public TestReportService(ITestReportRepository testReportRepository, IGoogleDriveService googleUploadDownloadService, IConfiguration configuration, IWebHostEnvironment hostingEnvironment, IEmailService emailService)
        {
            _testReportRepository = testReportRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _emailService = emailService;
            _googleUploadDownloadService = googleUploadDownloadService;
        }

        #region Public Methods
        /// <summary>
        /// Inser test report data
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public RequestResult<bool> Add(TestReportModel testReportModel)
        {
            _testReportRepository.Insert(testReportModel);
            return new RequestResult<bool>(true);
        }

        /// <summary>
        /// List the test report
        /// </summary>
        /// <returns></returns>
        public List<TestReportModel> Get()
        {
            return _testReportRepository.Get();
        }

        /// <summary>
        /// Update the test report by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public RequestResult<bool> Update(TestReportModel testReportModel)
        {
            _testReportRepository.Update(testReportModel);
            return new RequestResult<bool>(true);
        }

        /// <summary>
        /// Get test report by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TestReportModel Get(int id)
        {
            return _testReportRepository.Get(id);
        }

        /// <summary>
        /// To upload the Test Report to google Drive and send the mail
        /// </summary>
        /// <param name="testReportModel"></param>
        public RequestResult<AttachmentModel> UploadFileAndSendMail(TestReportModel testReportModel)
        {
            var isUploadedSuccessfully = UploadFile(testReportModel);
            var isReportSentSuccessfully = SendTestReportEmail(testReportModel);
            return isUploadedSuccessfully;
        }

        /// <summary>
        /// This is for upload only the Test Report Content to Google Drive.
        /// </summary>
        /// <param name="testReportModel"></param>
        public RequestResult<AttachmentModel> UploadFile(TestReportModel testReportModel)
        {
            try
            {
                var attachmentModel = new AttachmentModel
                {
                    FilePath = testReportModel.FilePath,
                    DataUrl = testReportModel.DataUrl,
                    Name = testReportModel.Name,
                    Email = testReportModel.Email,
                    Client = testReportModel.Client,
                    JobId = testReportModel.JobId,
                    DateTime = testReportModel.DateTime
                };
                AttachmentModel dataFilePath = _googleUploadDownloadService.Upload(attachmentModel);

                List<ValidationMessage> errors = new List<ValidationMessage>();
                if (dataFilePath.IsSuccess == false)
                {
                    errors.Add(new ValidationMessage { Reason = "Please Select Less Image Size", Severity = ValidationSeverity.Error });
                    return new RequestResult<AttachmentModel>(errors);
                }

                //Passing the FilePath value received after upload
                testReportModel.FilePath = dataFilePath.FilePath;

                //Saving File to the repository
                _testReportRepository.Insert(testReportModel);
                
                return null;
            }
            catch(Exception ex)
            {
                //TODO: log the error message.
                //_logger.LogException(new ExceptionLog
                // {
                //   ExceptionDate = DateTime.Now,
                //   ExceptionMsg = ex.Message,
                //  ExceptionSource = ex.Source,
                //   ExceptionType = "UserService",
                //  FullException = ex.StackTrace
                // });
                return null;
            }
        }

        /// <summary>
        /// It is to download the uploaded content in the Google Drive.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public AttachmentModel DownLoadAttachment(string fileId)
        {
            var dataDownloaded = _googleUploadDownloadService.Download(fileId);
            return dataDownloaded;
        }

        /// <summary>
        /// It is to send the uploaded conntent to the user
        /// </summary>
        /// <param name="testReportModel"></param>
        public bool SendTestReportEmail(TestReportModel testReportModel)
        {
            //Reading Data from Appsetting.Json
            var bodyImg = _configuration["TestingAndCalibrationSurvey:BodyImage"];
            var logoImg = _configuration["TestingAndCalibrationSurvey:LogoImage"];
            var mobNo = _configuration["TestingAndCalibrationSurvey:Mobile"];
            var emailContact = _configuration["TestingAndCalibrationSurvey:emailID"];

            //mail creation
            testReportModel.HtmlMsg = GetEmailTemplate();
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**name**", testReportModel.Name);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**client**", testReportModel.Client);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**data**", testReportModel.FilePath);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**jobId**", testReportModel.JobId);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**email**", testReportModel.Email);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**id**", testReportModel.Id.ToString());
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**contactMail**", emailContact);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**Mob**", mobNo);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**LogoLink**", logoImg);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**BodyImageLink**", bodyImg);
            testReportModel.Subject = "Web Page DataLink";

            //sending mail (Mapping the emailmodel and testreportmodel)
            var emailIds = new List<string>();
            emailIds.Add(testReportModel.Email);
            var getExchangeModel = new EmailModel
            {
                Email = emailIds,
                Subject = testReportModel.Subject,
                HtmlMsg = testReportModel.HtmlMsg
            };
            //Sending mail
           
            bool isSuccessful = _emailService.Sendemail(getExchangeModel);
            return isSuccessful;
        }
        
        #endregion
        #region Private Methods.

        /// <summary>
        /// This method is to send the web page link
        /// </summary>
        /// <param name="emailTemplate"></param>
        /// <returns></returns>
        private string GetEmailTemplate()
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibrationSurvey:WebPageLinkMail"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
        #endregion
    }
}
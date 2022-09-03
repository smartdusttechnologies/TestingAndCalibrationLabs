using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
        private readonly IGoogleUploadDownloadService _googleUploadDownloadService;

        public TestReportService(ITestReportRepository testReportRepository, IGoogleUploadDownloadService googleUploadDownloadService, IConfiguration configuration, IWebHostEnvironment hostingEnvironment, IEmailService emailService)
        {
            _testReportRepository = testReportRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _emailService = emailService;
            _googleUploadDownloadService = googleUploadDownloadService;
        }

        /// <summary>
        /// Inser test report data
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public RequestResult<int> Add(TestReportModel testReportModel)
        {
            _testReportRepository.Insert(testReportModel);
            return new RequestResult<int>(1);
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
        /// Updat the test report by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="testReportModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, TestReportModel testReportModel)
        {
            _testReportRepository.Update(id, testReportModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get test report by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TestReportModel GetTestReport(int id)
        {
            return _testReportRepository.GetTestReport(id);
        }

        /// <summary>
        /// It is for uploading the content to Google Drive and sending the mail to the user
        /// </summary>
        /// <param name="testReportModel"></param>
        public void WebLinkMail(TestReportModel testReportModel)
        {
            //Reading Data from Appsetting.Json
            var BodyImg = _configuration["TestingAndCalibrationSurvey:BodyImage"];
            var LogoImg = _configuration["TestingAndCalibrationSurvey:LogoImage"];
            var MobNo = _configuration["TestingAndCalibrationSurvey:Mobile"];
            var EmailContact = _configuration["TestingAndCalibrationSurvey:emailID"];

            //using method to 
            //EmailLinkMail(testReportModel, int Id);

            // <!----**Mail Creation************---->
            testReportModel.HtmlMsg = DataLinkWebMail(testReportModel.EmailTemplate);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**name**", testReportModel.Name);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**client**", testReportModel.Client);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**data**", testReportModel.FilePath);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**jobId**", testReportModel.JobId);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**email**", testReportModel.Email);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**id**", testReportModel.Id.ToString());
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**contactMail**", EmailContact);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**Mob**", MobNo);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**LogoLink**", LogoImg);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**BodyImageLink**", BodyImg);
            testReportModel.Subject = "Web Page DataLink";

            //sending mail (Mapping with the emailmodel)
            var emailId = new List<string>();
            emailId.Add(testReportModel.Email);
            var getExchangeModel = new Business.Core.Model.EmailModel
            {
                Email = emailId,
                Subject = testReportModel.Subject,
                HtmlMsg = testReportModel.HtmlMsg
            };
            //Sending mail
            _emailService.Sendemail(getExchangeModel);
        }

        /// <summary>
        /// To upload the Test Report to google Drive and send the mail
        /// </summary>
        /// <param name="testReportModel"></param>
        public void UploadFileAndSendMail(TestReportModel testReportModel)
        {
            UploadFile(testReportModel);
            WebLinkMail(testReportModel);
        }

        /// <summary>
        /// This method is to send the web page link
        /// </summary>
        /// <param name="emailTemplate"></param>
        /// <returns></returns>
        private string DataLinkWebMail(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibrationSurvey:WebPageLinkMail"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        /// <summary>
        /// This is for upload only the Test Report Content to Google Drive.
        /// </summary>
        /// <param name="testReportModel"></param>
        public void UploadFile(TestReportModel testReportModel)
        {

            var attachmentModel = new Business.Core.Model.AttachmentModel
            {
                FilePath = testReportModel.FilePath,
                DataUrl = testReportModel.DataUrl,
                Name = testReportModel.Name,
                Email = testReportModel.Email,
                Client = testReportModel.Client,
                JobId = testReportModel.JobId,
                DateTime = testReportModel.DateTime
            };
            var dataFilePath = _googleUploadDownloadService.UploadFile(attachmentModel);

            //Passing the FilePath value received after upload
            var dataSaveModel = new Business.Core.Model.TestReportModel
            {
                FilePath = dataFilePath,
                Name = testReportModel.Name,
                Client = testReportModel.Client,
                JobId = testReportModel.JobId,
                Email = testReportModel.Email,
                DateTime = testReportModel.DateTime
            };

            //Saving File to the repository
            _testReportRepository.Insert(dataSaveModel);
        }

        /// <summary>
        /// It is to download the uploaded content in the Google Drive.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public AttachmentModel DownLoadAttachment(string fileId)
        {
            var dataDownloaded = _googleUploadDownloadService.DownLoadAttachment(fileId);
            return dataDownloaded;
        }

        /// <summary>
        /// It is to send the uploaded conntent to the user
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <param name="Id"></param>
        public bool EmailLinkMail(TestReportModel testReportModel, int Id)
        {
            //Reading Data from Appsetting.Json
            var BodyImg = _configuration["TestingAndCalibrationSurvey:BodyImage"];
            var LogoImg = _configuration["TestingAndCalibrationSurvey:LogoImage"];
            var MobNo = _configuration["TestingAndCalibrationSurvey:Mobile"];
            var EmailContact = _configuration["TestingAndCalibrationSurvey:emailID"];

            //Int( value of Id to string conversion
            string myString = testReportModel.Id.ToString();

            //mail creation
            testReportModel.HtmlMsg = DataLinkWebMail(testReportModel.EmailTemplate);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**name**", testReportModel.Name);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**client**", testReportModel.Client);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**data**", testReportModel.FilePath);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**jobId**", testReportModel.JobId);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**email**", testReportModel.Email);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**id**", myString);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**contactMail**", EmailContact);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**Mob**", MobNo);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**LogoLink**", LogoImg);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**BodyImageLink**", BodyImg);
            testReportModel.Subject = "Web Page DataLink";

            //sending mail (Mapping the emailmodel and testreportmodel)
            var emailId = new List<string>();
            emailId.Add(testReportModel.Email);
            var getExchangeModel = new Business.Core.Model.EmailModel
            {
                Email = emailId,
                Subject = testReportModel.Subject,
                HtmlMsg = testReportModel.HtmlMsg
            };
            //Sending mail
            _emailService.Sendemail(getExchangeModel);
            return true;
        }
    }
}
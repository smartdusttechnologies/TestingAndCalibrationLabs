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
      //  private readonly IUserRepository _userRepository;
      //  private readonly ITestReportRepository _testReportRepository;

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

        public void WebLinkMail(TestReportModel testReportModel)
        {
            //Reading Data from Appsetting.Json
            var BodyImg = _configuration["TestingAndCalibrationSurvey:BodyImage"];
            var LogoImg = _configuration["TestingAndCalibrationSurvey:LogoImage"];
            var MobNo = _configuration["TestingAndCalibrationSurvey:Mobile"];
            var EmailContact = _configuration["TestingAndCalibrationSurvey:emailID"];
            
            //Mail Creation 
            testReportModel.HtmlMsg = DataLinkWebMail(testReportModel.EmailTemplate);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**name**", testReportModel.Name);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**client**", testReportModel.Client);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**data**", testReportModel.FilePath);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**jobId**", testReportModel.JobId);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**email**", testReportModel.Email);
            testReportModel.HtmlMsg = testReportModel.HtmlMsg.Replace("**id**", testReportModel.Id.ToString());
            testReportModel.EmailContact = testReportModel.HtmlMsg.Replace("*contactmail*", EmailContact);
            testReportModel.MobileNumber = testReportModel.HtmlMsg.Replace("*mob*", MobNo);
            testReportModel.BodyImage = testReportModel.HtmlMsg.Replace("**LogoLink**", LogoImg);
            testReportModel.BodyImage = testReportModel.HtmlMsg.Replace("**BodyImageLink**", BodyImg);

            testReportModel.Subject = "Web Page DataLink";
        
            //sending mail (Mapping with the emailmodel)
            var emailId = new List<string>();
            emailId.Add(testReportModel.Email);
            var getExchangeModel = new Business.Core.Model.EmailModel
            {

                Cc = testReportModel.Cc,
                Bcc = testReportModel.Bcc,
                Email = emailId,
                Subject = testReportModel.Subject,
                HtmlMsg = testReportModel.HtmlMsg,
                LogoImage = testReportModel.LogoImage,
                Message = testReportModel.Message,
                Name = testReportModel.Name,
                EmailTemplate = testReportModel.EmailTemplate,
                EmailContact = testReportModel.EmailContact,
                MobileNumber = testReportModel.MobileNumber
            };
            //Sending mail
            _emailService.Sendemail(getExchangeModel);
        }

        public void UploadFileAndSendMail(TestReportModel testReportModel)
        {
            UploadFile(testReportModel);

            //var exchangeModel = new Business.Core.Model.AttachmentModel
            //{
            //    Id = testReportModel.Id,
            //    Name = testReportModel.Name,
            //    JobId = testReportModel.JobId,
            //    Client = testReportModel.Client,
            //    Email = testReportModel.Email,
            //    DataUrl = testReportModel.DataUrl,
            //    FilePath = testReportModel.FilePath,
            //    DateTime = testReportModel.DateTime,
            //};
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

        public void UploadFile(TestReportModel testReportModel)
        {
            
            var attachmentModel = new Business.Core.Model.AttachmentModel
            {
                FilePath = testReportModel.FilePath,
                DataUrl = testReportModel.DataUrl,
                Name = testReportModel.Name,
                Email= testReportModel.Email,
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
                JobId  = testReportModel.JobId,
                Email = testReportModel.Email,
                DateTime = testReportModel.DateTime
            };

            //Saving File to the repository
            _testReportRepository.Insert(dataSaveModel);
        }

        public AttachmentModel DownLoadAttachment(string fileId)
        {
           var dataDownloaded = _googleUploadDownloadService.DownLoadAttachment(fileId);
            return dataDownloaded;
        }
    }
}
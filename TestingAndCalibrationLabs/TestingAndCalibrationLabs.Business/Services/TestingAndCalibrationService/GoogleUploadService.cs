using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Infrastructure;
using AutoMapper;
using Google.Apis.Download;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{

    public class GoogleUploadService : IDriveDownloadFile
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly ITestReportRepository _testReportRepository;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };
        private Google.Apis.Drive.v3.Data.File newFile;
        private object request;
        private object uploadData;


        public string ResponseBody { get; private set; }
        public object Get { get; private set; }
        public string FilePath { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="emailService"></param>
        /// <param name="mapper"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="testReportRepository"></param>
        /// <param name="configuration"></param>
        /// <param name="connectionFactory"></param>
        public GoogleUploadService(IUserRepository userRepository, IEmailService emailService, IMapper mapper, IWebHostEnvironment hostingEnvironment, ITestReportRepository testReportRepository, IConfiguration configuration, IConnectionFactory connectionFactory)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _testReportRepository = testReportRepository;
            _connectionFactory = connectionFactory;
            _emailService = emailService;
            _mapper = mapper;
        }

        public DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;

            //Root Folder of project
            var CSPath = _hostingEnvironment.WebRootPath;
            using (var stream = new FileStream(Path.Combine((string)CSPath, "client_secret_612092452145-21d21u1m196soc5t92j3vagr8rf7h8u7.apps.googleusercontent.com.json"),
                FileMode.Open, FileAccess.Read))
            {
                String FolderPath = (string)_hostingEnvironment.WebRootPath;
                String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets, Scopes, "user",
                CancellationToken.None,
                new FileDataStore(FilePath, true)).Result;
            }
            //create Drive API service.
            DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveMVCUpload",
            });
            return service;
        }

        /// <summary>
        /// This will create a Service to perform operations on Google Drive
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public string CreateFolder(string parent, string folderName)
        {
            var service = GetService();
            // File metadata
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "TnCData", //Folder name created in Google Drive
                MimeType = "application/vnd.google-apps.folder"
            };
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 100;
            listRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            bool isFolderExist = false;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    newFile = new Google.Apis.Drive.v3.Data.File();
                    newFile.Name = fileMetadata.Name;
                    if (file.Name == newFile.Name)
                    {
                        isFolderExist = true;
                        Console.WriteLine("File already existing... Skip creation");
                        return file.Id;
                    }
                }
            }

            if (!isFolderExist)
            {
                var request = service.Files.Create(fileMetadata);
                request.Fields = "id";
                var file = request.Execute();
                return file.Id;
            }
            return (string)ResponseBody;
        }

        /// <summary>
        /// This will upload the file to the Google Drive
        /// </summary>
        /// <param name="testReportModel"></param>
        public void UploadFile(TestReportModel testReportModel)
        {
            UploadFileInternal(testReportModel);
        }

        /// <summary>
        /// This will use a html format to send the mail containing the link of the data.
        /// </summary>
        /// <param name="emailTemplate"></param>
        /// <returns></returns>
        private string DataLinkMail(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibrationSurvey:SendDataMailLink"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        /// <summary>
        /// This method is used to Upload the file only 
        /// </summary>
        /// <param name="testReportModel"></param>
        private void UploadFileInternal(TestReportModel testReportModel)
        {

            //Read other values from Appsetting.Json

            string uploadsFolder = CreateFolder("Test", "new");
            var contentType = new FileExtensionContentTypeProvider();
            contentType.TryGetContentType(testReportModel.FilePath, out string fileMime);
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            var uniqueFileName = Guid.NewGuid().ToString();
            driveFile.Name = uniqueFileName + Path.GetFileName(testReportModel.FilePath);

            driveFile.Description = "";
            driveFile.Parents = new string[] { uploadsFolder };

            using (var fileUpload = testReportModel.DataUrl.OpenReadStream())
            {
                var request = service.Files.Create(driveFile, fileUpload, fileMime);
                request.Fields = "id";

                var response = request.Upload();
                if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                {
                    throw response.Exception;
                }
                //Unique Id from Google Drive after upload of file.
                testReportModel.FilePath = request.ResponseBody.Id;

                //Saving the data to the database
                _testReportRepository.Insert(testReportModel);
            }

        }

        /// <summary>
        /// This method is used to Upload the file and send mail
        /// </summary>
        /// <param name="testReportModel"></param>
        public void UploadFileAndSendMail(TestReportModel testReportModel)
        {
            UploadFileInternal(testReportModel);
            WebLinkMail(testReportModel, testReportModel.Id);
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
        /// Sends the mail by TestReport Id
        /// </summary>
        /// <param name="testReportModel"></param>
        /// <param name="Id"></param>
        public void WebLinkMail(TestReportModel testReportModel, int Id)
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
            testReportModel.EmailContact = testReportModel.HtmlMsg.Replace("*contactmail*", EmailContact);
            testReportModel.MobileNumber = testReportModel.HtmlMsg.Replace("*mob*", MobNo);
            testReportModel.BodyImage = testReportModel.HtmlMsg.Replace("**LogoLink**", LogoImg);
            testReportModel.BodyImage = testReportModel.HtmlMsg.Replace("**BodyImageLink**", BodyImg);

            testReportModel.Subject = "Web Page DataLink";

            //sending mail (Mapping the emailmodel and testreportmodel)
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

    }
}
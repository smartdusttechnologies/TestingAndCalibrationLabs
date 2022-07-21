using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using System.ComponentModel.DataAnnotations;
using System.Data;
using TestingAndCalibrationLabs.Business.Infrastructure;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Common;
using AutoMapper;
using System.Data.SqlClient;
using System.Web;
using System.Net.Http;
using System.Security.Policy;
using System.Net;
using System.Threading.Tasks;
using Google.Apis.Download;

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{

    public class GoogleUploadService : DriveDownloadFile
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

        public GoogleUploadService(IUserRepository userRepository, IEmailService emailService, IMapper mapper, IWebHostEnvironment hostingEnvironment,ITestReportRepository testReportRepository, IConfiguration configuration, IConnectionFactory connectionFactory)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _testReportRepository = testReportRepository;
            _connectionFactory = connectionFactory;
            _emailService = emailService;
            _mapper = mapper;
        }

       //Creating Services 
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

        public string CreateFolder(string parent, string folderName)
        {
            var service = GetService();
            // File metadata
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "TnCData",
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

        public void UploadFile(TestReportModel testReportModel)
        {
            UploadFileInternal(testReportModel);
        }

       
        private string DataLinkMail(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibrationSurvey:SendDataMailLink"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        private void UploadFileInternal(TestReportModel testReportModel)
        {
            //Read other values from Appsetting .Json 

            string uploadsFolder = CreateFolder("Test", "new");
            var xyz = new FileExtensionContentTypeProvider();
            xyz.TryGetContentType(testReportModel.FilePath, out string fileMime);
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            var uniqueFileName = Guid.NewGuid().ToString();
            driveFile.Name = uniqueFileName + Path.GetFileName(testReportModel.FilePath);

            driveFile.Description = "";
            driveFile.Parents = new string[] { uploadsFolder };

            using (var abc = testReportModel.DataUrl.OpenReadStream())
            {
                var request = service.Files.Create(driveFile, abc, fileMime);
                request.Fields = "id";

                var response = request.Upload();
                if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                {
                    throw response.Exception;
                }
                testReportModel.FilePath = request.ResponseBody.Id;

                //Saving the data to the database
                _testReportRepository.Insert(testReportModel);
            }

        }

        public void UploadFileAndSendMail(TestReportModel testReportModel)
        {
            UploadFileInternal(testReportModel);
            WebLinkMail(testReportModel, testReportModel.Id);
        }

        private string DataLinkWebMail(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibrationSurvey:WebPageLinkMail"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

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
            _emailService.Sendemail(getExchangeModel);
        }
    }
}
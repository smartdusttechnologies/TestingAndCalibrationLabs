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
using System.Linq;
using System.Web;

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
        //private readonly object file;
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };
        private Google.Apis.Drive.v3.Data.File newFile;
        private string uploadsFolder;

        //private object request;
        //private object uploadData;

        public string ResponseBody { get; private set; }
        public object Get { get; private set; }
        public string FilePath { get; private set; }

        /// <summary>
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

        public Google.Apis.Drive.v3.DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            var CSPath = _hostingEnvironment.WebRootPath;

            
            using (var stream = new FileStream(Path.Combine((string)CSPath, "client_secret_612092452145-21d21u1m196soc5t92j3vagr8rf7h8u7.apps.googleusercontent.com.json"),
                FileMode.Open, FileAccess.Read))
            {
                
                    String FolderPath = (string)_hostingEnvironment.WebRootPath;
                    String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(FilePath, true)).Result;
             }

            //create Drive API service.
            Google.Apis.Drive.v3.DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveRestAPI-v3",
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
            string uploadsFolder = CreateFolder("Test", "new");
            var fileName = testReportModel.DataUrl.FileName;
            
            var dataOfFile = new FileExtensionContentTypeProvider();
            
            dataOfFile.TryGetContentType(testReportModel.FilePath, out string fileMime);

            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            driveFile.Name = Path.GetFileName(fileName);
            driveFile.Description = "";
            driveFile.Parents = new string[] { uploadsFolder };

            using (var uploaddataFile = testReportModel.DataUrl.OpenReadStream())
            {
                var request = service.Files.Create(driveFile, uploaddataFile, fileMime);
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

        /// <summary>
        /// Used to download the file by fileid
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string DownloadGoogleFile(string fileId)
        {
            Google.Apis.Drive.v3.DriveService service = GetService();
            string FolderPath = (string)_hostingEnvironment.WebRootPath;
            Google.Apis.Drive.v3.FilesResource.GetRequest request = service.Files.Get(fileId);
            string FileName = request.Execute().Name;
            string dataFileName = FileName;
            string FilePath = System.IO.Path.Combine(FolderPath, dataFileName);
            MemoryStream stream = new MemoryStream();

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            SaveStream(stream, FilePath);
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            
            request.Download(stream);
            return FilePath;
        }

        private static void SaveStream(MemoryStream stream, string FilePath)
        {
            using (System.IO.FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }

    }
}
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

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{

    public class GoogleUploadService : IGoogleUploadService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUserRepository _userRepository;
        private readonly ITestReportRepository _newUIRepository;
        private readonly IConnectionFactory _connectionFactory;
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };
        private Google.Apis.Drive.v3.Data.File newFile;
        private object request;
        private object uploadData;

        public string ResponseBody { get; private set; }
        public object Get { get; private set; }
        public string FilePath { get; private set; }

        //private object listRequest;
        //private string ApplicationName;
        //private string imageVal;

        public GoogleUploadService(IUserRepository userRepository, IWebHostEnvironment hostingEnvironment,ITestReportRepository newUIRepository, IConfiguration configuration, IConnectionFactory connectionFactory)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _newUIRepository = newUIRepository;
            _connectionFactory = connectionFactory;
        }

        

       // public int Insert(NewUIModel uploadData);

        public DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;

            //Root Folder of project
            var CSPath = _hostingEnvironment.WebRootPath;
            using (var stream = new FileStream(Path.Combine((string)CSPath, "client_secret_28519194760-d787urlai0g2vp9r9t232rnjtnqql9ao.apps.googleusercontent.com.json"),
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
                //var uniqueFileName = Guid.NewGuid().ToString();
                var file = request.Execute();
                //var result = uniqueFileName + service.Files.Create(newFile).Execute();
                //Console.WriteLine("Folder ID: " + uniqueFileName + file.Id);
                return file.Id;
            }
            return (string)ResponseBody;
        }

        public void UploadFile(TestReportModel data)
        {
            string uploadsFolder = CreateFolder("Test", "new");
            var xyz = new FileExtensionContentTypeProvider();
            xyz.TryGetContentType(data.FilePath, out string fileMime);
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            var uniqueFileName = Guid.NewGuid().ToString();
            driveFile.Name = uniqueFileName + Path.GetFileName(data.FilePath);

            driveFile.Description = "";
            //driveFile.MimeType = fileMime;
            driveFile.Parents = new string[] { uploadsFolder };
            
            using (var abc = data.DataUrl.OpenReadStream())
            {
                var request = service.Files.Create(driveFile, abc, fileMime);
                request.Fields = "id";

                var response = request.Upload();
                if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                {
                    throw response.Exception;
                }
                data.FilePath = request.ResponseBody.Id;
                                   
                //Saving the data to the database
                _newUIRepository.Insert(data);
            }
        }

        public void UploadFile(IFormFile dataUrl, TestReportModel getbusinessModel)
        {
            throw new NotImplementedException();
        }

       
    }
}
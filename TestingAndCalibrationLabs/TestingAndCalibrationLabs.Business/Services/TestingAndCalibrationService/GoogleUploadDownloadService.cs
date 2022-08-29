using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Infrastructure;
using AutoMapper;
using Google.Apis.Download;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{

    public class GoogleUploadDownloadService : IGoogleUploadDownloadService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly ITestReportRepository _testReportRepository;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;
        private readonly IImageCompressService _imageCompressService;
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };
        private Google.Apis.Drive.v3.Data.File newFile;
        private string uploadsFolder;

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

        public GoogleUploadDownloadService(IImageCompressService imageCompressService, IUserRepository userRepository, IEmailService emailService, IMapper mapper, IWebHostEnvironment hostingEnvironment, ITestReportRepository testReportRepository, IConfiguration configuration, IConnectionFactory connectionFactory)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _testReportRepository = testReportRepository;
            _connectionFactory = connectionFactory;
            _emailService = emailService;
            _mapper = mapper;
            _imageCompressService = imageCompressService;
        }

        /// <summary>
        /// To initiate the Google Drive Service of Google
        /// </summary>
        /// <returns></returns>
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
        private string CreateFolder(string parent, string folderName)
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
        public AttachmentModel UploadFile(AttachmentModel attachmentModel)
        {
            var exchangeModel = new Business.Core.Model.TestReportModel
            {
                FilePath = attachmentModel.FilePath,
            };
            var xyz = UploadFileInternal(attachmentModel);
            return xyz;
        }

        /// <summary>
        /// This method is used to Upload the file only 
        /// </summary>
        /// <param name="testReportModel"></param>
        private AttachmentModel UploadFileInternal (AttachmentModel attachmentModel)
        {
            var compressedImage = _imageCompressService.ImageCompress(attachmentModel.DataUrl);
            attachmentModel.FilePath = compressedImage.FilePath;
            string uploadsFolder = CreateFolder("Test", "new");
            var fileName = compressedImage.FileName;
            string fileMime = compressedImage.ContentType;
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File(); 
            driveFile.Name = Path.GetFileName(fileName);
            driveFile.Description = "";
            driveFile.Parents = new string[] { uploadsFolder };
            try
            {
                using (var uploaddataFile = new FileStream(compressedImage.FilePath, FileMode.Open))
                {
                    
                    if (uploaddataFile.Length > 200000)
                    {
                        compressedImage.IsSuccess = false;
                        return compressedImage;
                    }
                    var request = service.Files.Create(driveFile, uploaddataFile, fileMime);
                    request.Fields = "id";
                    var response = request.Upload();
                    if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                    {
                        throw response.Exception;
                    }
                    compressedImage.FilePath = request.ResponseBody.Id;
                    compressedImage.IsSuccess = true;
                    return compressedImage;
                }
            }
            finally
            {
                File.Delete(attachmentModel.FilePath);
            }
        }

        /// <summary>
        /// Private function to download the file.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        private string DownloadGoogleFile(string fileId)
        {
            Google.Apis.Drive.v3.DriveService service = GetService();
            string FolderPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["DownloadData:FolderName"]);
            // string FolderPath = (string)_hostingEnvironment.WebRootPath;
            Google.Apis.Drive.v3.FilesResource.GetRequest request = service.Files.Get(fileId);
            string FileName = request.Execute().Name;
            string dataFileName = FileName;
            string FilePath = Path.Combine(FolderPath, dataFileName);
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

        /// <summary>
        /// To Download file from Google Drive using unique Response Body Id
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public AttachmentModel DownLoadAttachment(string fileId)
        {
            string filepath = DownloadGoogleFile(fileId);
            try
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(filepath, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                AttachmentModel attachment = new AttachmentModel();
                attachment.FileStream = memory;
                attachment.FileName = Path.GetFileName(filepath);
                attachment.ContentType = Helpers.GetContentType(filepath);
                return attachment;
            }
            finally
            {
                System.IO.File.Delete(filepath);
            }
        }

        /// <summary>
        /// Private function to save the file downloaded.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="FilePath"></param>
        private static void SaveStream(MemoryStream stream, string FilePath)
        {
            using (FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }
    }
}
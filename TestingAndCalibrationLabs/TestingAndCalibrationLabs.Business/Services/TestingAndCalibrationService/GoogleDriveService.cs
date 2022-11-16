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
using Google.Apis.Download;
using TestingAndCalibrationLabs.Business.Common;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{
    /// <summary>
    /// This service is to Upload file to Google Drive/ Download the file and get "ResponseBody" from the Google Drive.
    /// </summary>
    public class GoogleDriveService : IGoogleDriveService
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IFileCompressionService _fileCompressService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        /// <param name="fileCompressService"></param>
        public GoogleDriveService(IWebHostEnvironment hostingEnvironment, IConfiguration configuration, IFileCompressionService fileCompressService)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _fileCompressService = fileCompressService;
        }
        #region Public Methods
        /// <summary>
        /// This will upload the file to the Google Drive
        /// </summary>
        /// <param name="attachmentModel"></param>
        public RequestResult<AttachmentModel> Upload(AttachmentModel attachmentModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            try
            {
                var result = UploadFileInternal(attachmentModel);
                return result;
            }
            catch (Exception ex)
            {
                validationMessages.Add(new ValidationMessage { Reason = ex.Message, Severity = ValidationSeverity.Error });
                return new RequestResult<AttachmentModel>(validationMessages);
            }
        }
        /// <summary>
        /// To Download file from Google Drive using unique Response Body Id
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public AttachmentModel Download(string fileId)
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
                File.Delete(filepath);
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// To initiate the Google Drive Service of Google
        /// </summary>
        /// <returns></returns>
        private DriveService GetService()
        {
            string[] Scopes = { DriveService.Scope.Drive };

            //get Credentials from client_secret.json file 
            UserCredential credential;

            //TODO: need to see if the client secret file can be stored in some other place.
            var FolderPath = Directory.GetFiles(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["SecretFiles:FolderName"]), "*.json");
            using (var stream = new FileStream(Path.Combine(FolderPath.FirstOrDefault()),
                FileMode.Open, FileAccess.Read))
            {
                string FilePath = Path.Combine(_hostingEnvironment.WebRootPath, "DriveServiceCredentials");
                //TODO: What is the user string below in parameter?
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(FilePath, true)).Result;
            }
            //create Drive API service.
            DriveService service = new DriveService(new BaseClientService.Initializer()
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
        private string CreateFolder()
        {
            var service = GetService();
            // File metadata
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                //TODO: Why the folder name is hard coded.
                Name = "TnCData", //Folder name created in Google Drive
                MimeType = "application/vnd.google-apps.folder"
            };
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 100;
            listRequest.Fields = "nextPageToken, files(id, name)";
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            if (files != null && files.Any())
            {
                var folderName = files.Where(x => x.Name == fileMetadata.Name).FirstOrDefault();
                if (folderName != null)
                    return folderName.Id;
            }
            var request = service.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            return file.Id;
        }
        /// <summary>
        /// It Uploads the file only and Response BodyId is received as String.
        /// </summary>
        /// <param name="attachmentModel"></param>
        private RequestResult<AttachmentModel> UploadFileInternal(AttachmentModel attachmentModel)
        {
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            //Send File to Compress Image
            string extensionName = Path.GetExtension(attachmentModel.DataUrl.FileName);
            var fileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyymmddMMss") + extensionName;
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["DownloadData:FolderName"], fileName);
            _fileCompressService.ImageCompression(attachmentModel.DataUrl, filePath);
            attachmentModel.FilePath = filePath;
            string uploadsFolder = CreateFolder();
            //var fileName = compressedImage.FileName;
            string fileMime = attachmentModel.ContentType;
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            driveFile.Name = Path.GetFileName(fileName);
            driveFile.Description = "";
            driveFile.Parents = new string[] { uploadsFolder };
            try
            {
                using (var uploaddataFile = new FileStream(filePath, FileMode.Open))
                {
                    if (uploaddataFile.Length > 200000)
                    {
                        validationMessages.Add(new ValidationMessage { Reason = "Please Select Less Image Size", Severity = ValidationSeverity.Error });
                        return new RequestResult<AttachmentModel>(validationMessages);
                    }
                    var request = service.Files.Create(driveFile, uploaddataFile, fileMime);
                    request.Fields = "id";
                    var response = request.Upload();
                    if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                    {
                        throw response.Exception;
                    }
                    attachmentModel.FilePath = request.ResponseBody.Id;
                    return new RequestResult<AttachmentModel>(attachmentModel);
                }
            }
            finally
            {
                File.Delete(filePath);
            }
        }
        /// <summary>
        /// Private function to download the file.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        private string DownloadGoogleFile(string fileId)
        {
            DriveService service = GetService();
            string FolderPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["DownloadData:FolderName"]);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            FilesResource.GetRequest request = service.Files.Get(fileId);
            string FileName = request.Execute().Name;
            string dataFileName = FileName;
            string FilePath = Path.Combine(FolderPath, dataFileName);
            MemoryStream stream = new MemoryStream();
            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
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
        #endregion
    }
}
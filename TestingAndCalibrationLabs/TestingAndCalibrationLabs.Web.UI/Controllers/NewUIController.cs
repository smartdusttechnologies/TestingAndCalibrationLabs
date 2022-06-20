using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using NewUIModel = TestingAndCalibrationLabs.Web.UI.Models.NewUIModel;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class NewUIController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly INewUIService _newUIService;
        private readonly IGoogleUploadService _googleUploadService;
        
        /// <summary>
        /// Default Action of the NewUIController
        /// </summary>
        /// <returns></returns>
      
       

        public object ResponseBody { get; private set; }


        //public DriveService GetService()
        //{
        //     //get Credentials from client_secret.json file 
        //    UserCredential credential;

        //    //Root Folder of project
        //    var CSPath = _hostingEnvironment.WebRootPath;
        //    using (var stream = new FileStream(Path.Combine((string)CSPath, "client_secret_28519194760-d787urlai0g2vp9r9t232rnjtnqql9ao.apps.googleusercontent.com.json"),
        //        FileMode.Open, FileAccess.Read))
        //    {
        //        String FolderPath = (string)_hostingEnvironment.WebRootPath;
        //        String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");
        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //        GoogleClientSecrets.FromStream(stream).Secrets, Scopes, "user",
        //        CancellationToken.None,
        //        new FileDataStore(FilePath, true)).Result;
        //    }
        //    //create Drive API service.
        //    DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "GoogleDriveMVCUpload",
        //    });
        //    return service;
        //}

        //public string CreateFolder(string parent, string folderName)
        //{
        //    var service = GetService();
        //    // File metadata
        //    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
        //    {
        //        Name = "TnCData",
        //        MimeType = "application/vnd.google-apps.folder"
        //    };
        //    FilesResource.ListRequest listRequest = service.Files.List();
        //    listRequest.PageSize = 100;
        //    listRequest.Fields = "nextPageToken, files(id, name)";
        //    IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
        //    bool isFolderExist = false;
        //    if (files != null && files.Count > 0)
        //    {
        //        foreach (var file in files)
        //        {
        //            newFile = new Google.Apis.Drive.v3.Data.File();
        //            newFile.Name = fileMetadata.Name;
        //            if (file.Name == newFile.Name)
        //            {
        //                isFolderExist = true;
        //                Console.WriteLine("File already existing... Skip creation");
        //                return file.Id;
        //            }
        //        }
        //    }

        //    if (!isFolderExist)
        //    {
        //        var request = service.Files.Create(fileMetadata);
        //        request.Fields = "id";
        //        //var uniqueFileName = Guid.NewGuid().ToString();
        //        var file = request.Execute();
        //        //var result = uniqueFileName + service.Files.Create(newFile).Execute();
        //        //Console.WriteLine("Folder ID: " + uniqueFileName + file.Id);
        //        return file.Id;
        //    }
        //    return (string)ResponseBody;
        //}

        //public string UploadFile(IFormFile file, string fileName, string fileMime, string folder, string fileDescription)
        //{
        //    DriveService service = GetService();
        //    var driveFile = new Google.Apis.Drive.v3.Data.File();
        //    var uniqueFileName = Guid.NewGuid().ToString();
        //    driveFile.Name = uniqueFileName + fileName;

        //    driveFile.Description = fileDescription;
        //    //driveFile.MimeType = fileMime;
        //    driveFile.Parents = new string[] { folder };

        //    using (var abc = file.OpenReadStream())
        //    {
        //        var request = service.Files.Create(driveFile, abc, fileMime);
        //        request.Fields = "id";

        //        var response = request.Upload();
        //        if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
        //        {
        //            throw response.Exception;
        //        }
        //        var imageVal = request.ResponseBody.Id;
        //        //return request.ResponseBody.Id;
        //        return imageVal;
        //    }
        //}

        public NewUIController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment, IConfiguration configuration, INewUIService newUIService,IGoogleUploadService googleUploadService)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _newUIService = newUIService;
            _googleUploadService = googleUploadService;
        }

        public object NewUIModel { get; private set; }
        public string ImageVal { get; private set; }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(NewUIModel data)
        {
            if (ModelState.IsValid)
            {

                var getbusinessModel = new Business.Core.Model.NewUIModel
                {
                    Client = data.Client,
                    DataUrl = data.DataUrl,
                    FilePath = data.FilePath,
                    JobId = data.JobId,
                    Name = data.Name,
                    DateTime = DateTime.Now.Date,       //Accept the Current Date only
                    Email = data.Email
                };
                // string uniqueFileName = _googleUploadService.UploadFile(getbusinessModel);

                _googleUploadService.UploadFile(getbusinessModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(data);
        }
        
    }
}
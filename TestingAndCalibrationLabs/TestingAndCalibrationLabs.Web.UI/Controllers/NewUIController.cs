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
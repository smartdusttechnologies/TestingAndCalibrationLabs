using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{



    public class ForgotPasswordController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IForgotPasswordService _forgotPasswordService;
        public ForgotPasswordController(ILogger<HomeController> logger, IForgotPasswordService forgotPasswordService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _forgotPasswordService = forgotPasswordService;
        }


        [HttpPost]
        public string SendEmail(EmailModel Email)
        {
            

            var isemailsendsuccessfully = _forgotPasswordService.Add(Email);


            return "Email sent sucessfully.";
        }

    }

}








using AutoMapper;
using ClassLibrary1;
using Google.Apis.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrganizationService _orgnizationService;
        private readonly IMapper _mapper;
        //public readonly IForgotPasswordService _forgotPasswordService;

        public SecurityController(IAuthenticationService authenticationService, IOrganizationService orgnizationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _orgnizationService = orgnizationService;
            _mapper = mapper;
            //_forgotPasswordService = isemailsendsuccessfully1;
        }

        /// <summary>
        /// UI Shows the Orgnizations names in dropdown list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            List<Business.Core.Model.Organization> organizations = _orgnizationService.Get();
            List<SelectListItem> organizationNames = organizations.Select(x => new SelectListItem { Text = x.OrgName, Value = x.Id.ToString() }).ToList();
            ViewBag.Organizations = organizationNames;
            return View();
        }

        /// <summary>
        /// Method to get the Login details from UI and Process Login.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginDTO loginRequest)
        {
            var loginReq = new LoginRequest { UserName = loginRequest.UserName, Password = loginRequest.Password };
            RequestResult<LoginToken> result = _authenticationService.Login(loginReq);
            if (result.IsSuccessful)
            {
                HttpContext.Session.SetString("Token", result.RequestedObject.AccessToken);

                return Json(new { status = true, message = "Login Successfull!" });
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(model.Email);
        //        if (user != null && await userManager.IsEmailConfirmedAsync(user))
        //        {
        //            object userManager = null;
        //            var token = await userManager.GeneratePasswordResetTokenAsync(user);

        //            var passwordResetLink = Url.Action("ResetPassword", "Security",
        //                new { email = model.Email, token = token }, Request.Scheme);

        //            logger.Log(LogLevel.Warning, passwordResetLink);
        //            return View("ForgotPasswordConfirmation");

        //        }
        //        return View("ForgotPasswordConfirmation");
        //    }
        //    return View(model);
        //}

        public IActionResult ForgotPassword()
        {
            return View();
        }

        //[HttpPost]
        //public string SendEmail(EmailModel Email)
        //{
        //    EmailModel emailModel = new EmailModel
        //    {
        //        EmailTo = Email.EmailTo
        //    };

        //    var isemailsendsuccessfully1 = _forgotPasswordService.Add(emailModel);


        //    return "Email sent sucessfully.";
        //}
    }
}


        

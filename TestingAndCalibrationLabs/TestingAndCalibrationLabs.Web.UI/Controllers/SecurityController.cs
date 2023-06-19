using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingAndCalibrationLabs.Business.Data.Repository;
using Org.BouncyCastle.Ocsp;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Bcpg;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class SecurityController : Controller
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly IOrganizationService _orgnizationService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IAuthenticationRepository _authenticationRepository;

        public SecurityController(IAuthenticationService authenticationService, IOrganizationService orgnizationService, IEmailService emailService, IMapper mapper, IAuthenticationRepository authenticationRepository)
        {

            _authenticationService = authenticationService;
            _orgnizationService = orgnizationService;
            _emailService = emailService;
            _mapper = mapper;
            _authenticationRepository=authenticationRepository;
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
        ///<summary>
        /// Methods to Forget Password
        /// </summary>
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordDTO());
        }


        /// <summary>
        /// Method for otp and Email validation and Varification Code on Email
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordDTO model)
        {
            if (ModelState.IsValid)
            {

                var emailreq = new ForgotPasswordModel { Email = model.Email };

                var user = _authenticationService.EmailValidateForgotPassword(emailreq);
                if (user.IsSuccessful)
                {

                    _authenticationService.Create(emailreq);
                }

            }

            return View(model);
        }
        /// <summary>
        /// OTP Validation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult ValidateOTP(ForgotPasswordDTO model)
        {
        
        
            var otpreturn = new ForgotPasswordModel {OTP = model.OTP };

            var user = _authenticationService.ValidateOTP(otpreturn);

            if (ModelState.IsValid)
            {
                //var otpreturn = new ForgotPasswordModel { OTP = OTP.OTP };

                //var userid = _authenticationService.ValidateOTP(otpreturn);
                //var user = _authenticationService.OtpValidation(Otpreq);

            }
            return View() ;
        }

    }
}


using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Web.UI.Models;


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
        public IActionResult ForgotPassword(ForgotPasswordDTO forgotPasswordModel)
        {
            if (ModelState.IsValid)
            {
                var EmailResult = new ForgotPasswordModel { Email = forgotPasswordModel.Email };
                var UserVerify = _authenticationService.EmailValidateForgotPassword(EmailResult);
                if (UserVerify.IsSuccessful)
                {
                    forgotPasswordModel.UserId = UserVerify.RequestedObject;
                    _authenticationService.CreateOtp(EmailResult, forgotPasswordModel.UserId);
                }
                else
                {
                    forgotPasswordModel.Email = null;
                }
            }
            return View(forgotPasswordModel);
        }
        /// <summary>
        /// OTP Validation
        /// </summary>
        /// <param name="model"></param
        /// <returns></returns>
        [HttpPost]
        public IActionResult ValidateOTP(ForgotPasswordDTO ForgotPasswordModel)
        {
            var OTPReturn = new ForgotPasswordModel {OTP= ForgotPasswordModel.OTP,UserId= ForgotPasswordModel.UserId, CreatedDate =DateTime.Now };
            var user = _authenticationService.ValidateOTP(OTPReturn);
            if (user.IsSuccessful)
            {
                
                return View(new ForgotPasswordDTO { UserId = ForgotPasswordModel.UserId });
            }
            else
            {
                return BadRequest(user.ValidationMessages);
            }
        }
        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="forgotpassswordmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ResetPassword(ForgotPasswordDTO ForgotPasswordModel)
        {
            var PasswordRequest = _mapper.Map<ForgotPasswordDTO, ForgotPasswordModel>(ForgotPasswordModel);
            var Result = _authenticationService.UpdatePassword(PasswordRequest);
            if (Result.IsSuccessful)
            {
                return Ok(Result.RequestedObject);
            }
            return BadRequest(Result.ValidationMessages);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="forgotpassword"></param>
        /// <returns></returns>
        public IActionResult ResendOTP(ForgotPasswordDTO ForgotPasswordModel)
        {
          return Ok(ForgotPassword(ForgotPasswordModel));
        }
    }
}
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
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordDTO forgotPasswordModel)
        {
            if (ModelState.IsValid)
            {
                var emailResult = new ForgotPasswordModel { Email = forgotPasswordModel.Email };
                var userVerify = _authenticationService.EmailValidateForgotPassword(emailResult);
                if (userVerify.IsSuccessful)
                {
                    forgotPasswordModel.UserId = userVerify.RequestedObject;
                    _authenticationService.CreateOtp(emailResult, forgotPasswordModel.UserId);
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
        [HttpPost]
        public IActionResult ValidateOTP(ForgotPasswordDTO forgotPasswordDto)
        {
            var OTPReturn = new ForgotPasswordModel {OTP= forgotPasswordDto.OTP,UserId= forgotPasswordDto.UserId, CreatedDate =DateTime.Now };
            var user = _authenticationService.ValidateOTP(OTPReturn);
            if (user.IsSuccessful)
            {
                return View(new ForgotPasswordDTO { UserId = forgotPasswordDto.UserId });
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
        [HttpPost]
        public IActionResult ResetPassword(ForgotPasswordDTO forgotPasswordDto)
        {
            var passwordRequest = _mapper.Map<ForgotPasswordDTO, ForgotPasswordModel>(forgotPasswordDto);
            var Result = _authenticationService.UpdatePassword(passwordRequest);
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
        public IActionResult ResendOTP(ForgotPasswordDTO forgotPasswordDto)
        {
          return Ok(ForgotPassword(forgotPasswordDto));
        }
    }
}
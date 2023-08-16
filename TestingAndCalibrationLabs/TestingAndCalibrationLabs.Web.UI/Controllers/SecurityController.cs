using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return View(new OtpDTO());
        }
        /// <summary>
        /// Method for otp and Email validation and Varification Code on Email
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public IActionResult ForgotPassword(OtpDTO OtpDTO)
        {
                var emailResult = _mapper.Map<OtpDTO, OtpModel>(OtpDTO);
                var userVerify = _authenticationService.EmailValidateForgotPassword(emailResult);
                if (userVerify.IsSuccessful)
                {
                    OtpDTO.UserId = userVerify.RequestedObject;
                    _authenticationService.CreateOtp(emailResult, OtpDTO.UserId);
                    return Ok(OtpDTO);
                }
            return BadRequest(userVerify.ValidationMessages);
        }
        /// <summary>
        /// OTP Validation
        /// </summary>
        /// <param name="model"></param
        [HttpPost]
        public IActionResult ValidateOTP(OtpDTO OtpDTO)
         {
            var otpReturn = _mapper.Map<OtpDTO, OtpModel>(OtpDTO);
            var user = _authenticationService.ValidateOTP(otpReturn);
            if (user.IsSuccessful)
            {
               return Ok(user.RequestedObject);
            }
             return BadRequest(user.ValidationMessages);
        }
        /// <summary>
        /// Reset Password
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }
        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="forgotpassswordmodel"></param>
        [HttpPost]
        public IActionResult ResetPassword(OtpDTO OtpDTO)
        {
            var passwordRequest = _mapper.Map<OtpDTO, OtpModel>(OtpDTO);
            var result = _authenticationService.UpdatePassword(passwordRequest);
            if (result.IsSuccessful)
            {
                return Ok(result.RequestedObject);
            }
            return BadRequest(result.ValidationMessages);
        }
        /// <summary>
        /// Method to Resend OTP
        /// </summary>
        /// <param name="forgotpassword"></param>
        public IActionResult ResendOTP(OtpDTO OtpDTO)
        {
          return Ok(ForgotPassword(OtpDTO));
        }
    }
}
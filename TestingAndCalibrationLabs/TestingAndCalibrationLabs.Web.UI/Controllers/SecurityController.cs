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
using crypto;
using Google.Apis.Drive.v3.Data;

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

                var user1 = _authenticationService.EmailValidateForgotPassword(emailreq);

                if (user1.IsSuccessful)
                {
                   model.UserId = user1.RequestedObject;
                    _authenticationService.Create(emailreq,model.UserId);
                }
                else
                {
                    model.Email = null;
                }

            }

            return View(model);
        }
        /// <summary>
        /// OTP Validation
        /// </summary>
        /// <param name="model"></param
        /// <returns></returns>

        [HttpPost]
        public IActionResult ValidateOTP(ForgotPasswordDTO model)
        {

            var otpreturn = new ForgotPasswordModel {OTP= model.OTP,UserId=model.UserId, CreatedDate =DateTime.Now };
            var user = _authenticationService.ValidateOTP(otpreturn);

            if (user.IsSuccessful)
            {
                
                return View(new ForgotPasswordDTO { UserId = model.UserId });
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
        public IActionResult ResetPassword(ForgotPasswordDTO forgotpassswordmodel)
        {

            var psswReq = _mapper.Map<ForgotPasswordDTO, ForgotPasswordModel>(forgotpassswordmodel);
            var result = _authenticationService.UpdatePaasword(psswReq);

            if (result.IsSuccessful)
            {

                return Ok(result.RequestedObject);


            }
            return BadRequest(result.ValidationMessages);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="forgotpassword"></param>
        /// <returns></returns>
        public IActionResult ResendOTP(ForgotPasswordDTO forgotpassword)
        {
            return Ok(ValidateOTP(forgotpassword));
        }
    }
    
}


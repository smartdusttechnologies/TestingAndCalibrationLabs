using AutoMapper;
using CloudinaryDotNet.Actions;
using Google.Apis.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;
using static System.Net.WebRequestMethods;
using ForgotPasswordModel = TestingAndCalibrationLabs.Web.UI.Models.ForgotPasswordModel;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrganizationService _orgnizationService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        

        public SecurityController(IAuthenticationService authenticationService, IOrganizationService orgnizationService, IEmailService emailService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _orgnizationService = orgnizationService;
            _emailService = emailService;
            _mapper = mapper;
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
            return View();
        }

        //[HttpPost]
        //public IActionResult ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var user = _authenticationService.GenerateTokens(forgotPasswordModel.Email);
        //        if (user != null)
        //        {

        //        }
        //        ModelState.Clear();
        //        forgotPasswordModel.EmailSent=true;
        //    }

        //    return View();
        //}


    }
}

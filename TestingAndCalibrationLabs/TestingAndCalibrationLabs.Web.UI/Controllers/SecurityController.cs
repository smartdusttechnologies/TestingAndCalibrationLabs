using AutoMapper;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public SecurityController(IAuthenticationService authenticationService, IOrganizationService orgnizationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _orgnizationService = orgnizationService;
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
        /// <summary>
        /// Method to get the Change Password.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordDTO changePasswordDto)
        {
            var passwordRequest = _mapper.Map<ChangePasswordDTO, ChangePasswordModel>(changePasswordDto);
            var result = _authenticationService.UpdatePassword(passwordRequest);
            if (result.IsSuccessful)
            {
                return Ok(result.RequestedObject);
            }
            return BadRequest(result.ValidationMessages);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
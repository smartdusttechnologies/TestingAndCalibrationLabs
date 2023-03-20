using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
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
        public IActionResult ChangePassword(ChangePasswordDTO changepasswordRequest)
        {

            var psswReq = new ChangePasswordModel { OldPassword= changepasswordRequest.OldPassword, NewPassword=changepasswordRequest.NewPassword, ConfirmPassword=changepasswordRequest.ConfirmPassword, UserId = 2 };
            //string authorization = HttpContext.Session.GetString("Token").ToString() ;

            //var Token = authorization.Substring(authorization.IndexOf(' ') + 1);

            //JwtSecurityToken jwt = (JwtSecurityToken)new JwtSecurityTokenHandler().ReadToken(refreshToken);

            var result = _authenticationService.UpdatePaasword(psswReq);
            
            if (result.IsSuccessful)
            {

                return Ok(result.RequestedObject);


            }
            return BadRequest(result.ValidationMessages);
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}

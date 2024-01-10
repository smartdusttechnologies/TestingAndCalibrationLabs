using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecurityController(IAuthenticationService authenticationService, IOrganizationService orgnizationService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _authenticationService = authenticationService;
            _orgnizationService = orgnizationService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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


                return Json(new { status = true, message = "Login Successfull!", userName= result.RequestedObject.UserName });
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UserInfo()
        {

           
                var context = _httpContextAccessor.HttpContext;
            if(context != null)
            {
                var user = context.User.Identity.Name;
                return Json(new { status = true, user = context.User.Identities } );

            }
            return Json(new {status = false});
            
           
        }
    }
}

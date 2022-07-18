using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;
using LoginDTO = TestingAndCalibrationLabs.Web.UI.Models.LoginDTO;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    
    public class HomeController : Controller
    {
        
        private readonly IAuthenticationService _authenticationService;
        private readonly IOrganizationService _orgnizationService;
        private readonly IMapper _mapper;

        public HomeController(IAuthenticationService authenticationService, IOrganizationService orgnizationService,IMapper mapper)
        {
            _authenticationService = authenticationService;
            _orgnizationService = orgnizationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            
            return View();
        }
      
        public IActionResult Login()
        {
            List<Business.Core.Model.Organization> organizations = _orgnizationService.Get();
            List<SelectListItem> organizationNames = organizations.Select(x => new SelectListItem { Text = x.OrgName, Value = x.Id.ToString() }).ToList();
            ViewBag.Organizations = organizationNames;
            return View();
        }

       

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

        public IActionResult TestDetails()
        {
            return View();
        }
        public IActionResult PlanPricing()
        {
            return View();
        }

    }
}

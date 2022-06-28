using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public UserController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegistration(UserDTO userRequest)
        {
            //Business.DTO.User user = new Business.DTO.User();
            //user.UserName = "HSrinidhi";
            //user.FirstName = "Srinidhi";
            //user.LastName = "Kumar";
            //user.Password = "Srinidhi@2022";
            //user.Email = "krsauravgit@gmail.com";
            //user.Mobile = "99887654321";
            //user.Country = "India";
            //user.ISDCode = "91";
            //user.TwoFactor = true;
            //user.Locked = false;
            //user.IsActive = true;
            //user.EmailValidationStatus = 1;
            //user.MobileValidationStatus = 2;
            //user.OrgId = 0;
            //user.AdminLevel = 124;

            var userModel = _mapper.Map<UserDTO,User>(userRequest);
            var result = _authenticationService.Add(userModel, userRequest.Password);
            if (result.IsSuccessful)
                return Ok(result.RequestedObject);
            return Ok(result.ValidationMessages);

        }

    }
}

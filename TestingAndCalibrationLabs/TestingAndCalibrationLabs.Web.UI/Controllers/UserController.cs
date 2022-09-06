using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    // User controller for User registration
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Default Action of the USer Controller
        /// </summary>
        /// <returns></returns>
        /// 
        public UserController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Method for User Registration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UserRegistration(UserDTO userRequest)
        {
            var userModel = _mapper.Map<UserDTO,User>(userRequest);
            var result = _authenticationService.Add(userModel, userRequest.Password);
            if (result.IsSuccessful)
                return Ok(result.RequestedObject);
            return Ok(result.ValidationMessages);

        }

    }
}

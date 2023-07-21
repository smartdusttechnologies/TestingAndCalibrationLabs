using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    // User controller for User registration
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public UserController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Default Action of the User Controller
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Method for User Registration
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(UserDTO userRequest)
        {
            var userModel = _mapper.Map<UserDTO, UserModel>(userRequest);

            var result = _authenticationService.Add(userModel);
            if (result.IsSuccessful && result.RequestedObject)
            {
                return Ok(result.RequestedObject);
            }
            return BadRequest(result.ValidationMessages);

        }

    }
}

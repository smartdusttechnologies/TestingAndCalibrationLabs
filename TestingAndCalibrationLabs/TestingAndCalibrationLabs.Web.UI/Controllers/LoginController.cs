using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// a base class for login using external applications 
    /// </summary>
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;
        private readonly Business.Core.Interfaces.IAuthenticationService _authenticationService;
        public LoginController(Business.Core.Interfaces.IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Method to get the user details from google.
        /// </summary>
        public async Task Login()
        {
            await HttpContext.ChallengeAsync("Google",
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse")
                });
        }

        /// <summary>
        /// Method to process login using google details.
        /// </summary>
        public async Task<IActionResult> GoogleResponse()
        {
            
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
 
            var user = result.Principal;
            var email = user.FindFirstValue(ClaimTypes.Email);
            var firstName = user.FindFirstValue(ClaimTypes.GivenName);
            var lastName = user.FindFirstValue(ClaimTypes.Surname);
            var orgid = 0;


            var externalLogin = new ExternalLogin
            {

                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Organizations="0",
                OrgId=orgid,


            };
            var userModel = _mapper.Map<ExternalLogin, UserModel>(externalLogin);
            var resultt = _authenticationService.ExternalAdd(userModel);
            if (resultt.IsSuccessful)
            {
                HttpContext.Session.SetString("Token", resultt.RequestedObject.AccessToken);
                return RedirectToAction("Index", "TestReport");
            }
            return BadRequest(resultt.ValidationMessages);

        }

        /// <summary>
        /// Method to get the user details from Microsoft.
        /// </summary>

        public async Task LoginWithMicrosoft()
        {
            await HttpContext.ChallengeAsync("Microsoft",
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("MicrosoftResponse")
                });
        }


        /// <summary>
        /// Method to process login using microsoft details.
        /// </summary>
        public async Task<IActionResult> MicrosoftResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var user = result.Principal;
            var email = user.FindFirstValue(ClaimTypes.Email);
            var firstName = user.FindFirstValue(ClaimTypes.GivenName);
            var lastName = user.FindFirstValue(ClaimTypes.Surname);
            var orgid = 0;


            var externalLogin = new ExternalLogin
            {

                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Organizations = "0",
                OrgId = orgid,

            };
            var userModel = _mapper.Map<ExternalLogin, UserModel>(externalLogin);
            var resultt = _authenticationService.ExternalAdd(userModel);
            if (resultt.IsSuccessful)
            {
                HttpContext.Session.SetString("Token", resultt.RequestedObject.AccessToken);
                return RedirectToAction("Index", "TestReport");
            }
            return BadRequest(resultt.ValidationMessages);

        }


    }
}

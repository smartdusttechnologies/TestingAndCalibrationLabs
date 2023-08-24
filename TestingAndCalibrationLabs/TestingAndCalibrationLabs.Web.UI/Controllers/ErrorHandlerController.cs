using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// Error Handler Page
    /// </summary>
    public class ErrorPageController : Controller
    {
        public IActionResult Index(string message)
        {
            var statuscode = HttpContext.Response.StatusCode;
            switch (statuscode)
            {
                case 401:
                    return View("401");
                case 404:
                    return View("404");
            }
            return View("Index",message);
        }
        
    }
}

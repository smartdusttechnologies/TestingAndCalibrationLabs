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
            return View("Index",message);
        }
    }
}

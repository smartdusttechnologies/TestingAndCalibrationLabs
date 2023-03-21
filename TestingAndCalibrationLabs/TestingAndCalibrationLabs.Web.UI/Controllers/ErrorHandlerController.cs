using Microsoft.AspNetCore.Mvc;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    //[Route("/ErrorPage/{statuscode}")]
    public class ErrorPageController : Controller
    {
        
        public IActionResult Index(string statuscode)
        {
            //HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            //switch (statuscode)
            //{
            //    case "401":
            //        return View("401");
            //    case "404":
            //        return View("404");
            //}
            return View("Index",statuscode);
        }
        
    }
}

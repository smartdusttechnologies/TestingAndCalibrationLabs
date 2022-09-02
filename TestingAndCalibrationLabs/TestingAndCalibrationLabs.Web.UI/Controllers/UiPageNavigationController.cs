using Microsoft.AspNetCore.Mvc;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageNavigationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

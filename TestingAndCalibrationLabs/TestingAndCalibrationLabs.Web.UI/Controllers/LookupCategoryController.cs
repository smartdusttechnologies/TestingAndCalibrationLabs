using Microsoft.AspNetCore.Mvc;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class LookupCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

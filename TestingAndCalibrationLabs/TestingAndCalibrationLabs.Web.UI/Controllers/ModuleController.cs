using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class ModuleController : Controller
    {
        private IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetRecord(int moduleId)
        {
            var sd = _moduleService.GetValues(3);
            return View();

        }
    }
}

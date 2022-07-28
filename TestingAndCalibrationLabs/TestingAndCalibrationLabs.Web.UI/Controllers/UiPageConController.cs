using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageConController : Controller
    {
        public readonly IUiPageControlService _uiPageControlService;
        public UiPageConController(IUiPageControlService uiPageControlService)
        {
            _uiPageControlService = uiPageControlService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [HttpGet]
        public IActionResult Index()
        {
            var pageCon = _uiPageControlService.GetAll();
            //List<Models.UiPageControl.UiPageControlModel>
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

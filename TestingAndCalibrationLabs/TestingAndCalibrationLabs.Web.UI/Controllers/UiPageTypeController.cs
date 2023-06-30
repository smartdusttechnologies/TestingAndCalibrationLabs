using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageTypeController : Controller
    {
        public readonly IUiPageTypeService _uiPageTypeService;
        public readonly IMapper _mapper;
        private readonly IUiPageNavigationService _uiNavigationCategoryService;
        public readonly Microsoft.Extensions.Logging.ILogger _logger;


        public UiPageTypeController(IUiPageTypeService uiPageTypeService, IMapper mapper, IUiPageNavigationService uiNavigationCategoryService, ILogger<UiPageTypeController> logger)
        {
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;
            _uiNavigationCategoryService = uiNavigationCategoryService;
            _logger = logger;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index page has been accessed");
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UiPageTypeModel> page = _uiPageTypeService.Get();
            var pageData = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(page);
            return View(pageData.AsEnumerable());
        }
        
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NavigationCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            _logger.LogInformation("Edit get page has been accessed");
            if (id == null)
            {

                _logger.LogError("id is null");
                return NotFound();
            }
            var getByIdPageModel = _uiPageTypeService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            var pageData = _mapper.Map<UiPageTypeModel, UiPageTypeDTO>(getByIdPageModel);

            return View(pageData);
        }

        /// <summary>
        /// To Edit Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( [Bind] UiPageTypeDTO uiPageTypeDTO)
        {
            _logger.LogInformation("Edit post page has been accessed");
            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<UiPageTypeDTO, UiPageTypeModel>(uiPageTypeDTO);
                _uiPageTypeService.Update( pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageTypeDTO);
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            _logger.LogInformation("Create get page has been accessed");
            return base.View(new Models.UiPageTypeDTO { Id = id });
        }

        /// <summary>
        /// To Create Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiPageTypeDTO uiPageTypeDTO)
        {
            _logger.LogInformation("Create Post page has been accessed");
            if (ModelState.IsValid)
            {
               
                var pageModel = _mapper.Map<UiPageTypeDTO, UiPageTypeModel>(uiPageTypeDTO);
                _uiPageTypeService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageTypeDTO);
        }

        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("Delete page has been accessed");
            if (id == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            UiPageTypeModel getByIdPageModel = _uiPageTypeService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            var pageModel = _mapper.Map<UiPageTypeModel, UiPageTypeDTO>(getByIdPageModel);
            return View(pageModel);
        }

        /// <summary>
        /// To Delete Record From Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _logger.LogInformation("Edit Post page has been accessed");
            if (id == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            _uiPageTypeService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}

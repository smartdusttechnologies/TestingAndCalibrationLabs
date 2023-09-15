using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageMetadataModuleBridgeController : Controller
    {
        public readonly IUiPageMetadataModuleBridgeService _uiPageMetadataModuleBridgeService;
        public readonly IMapper _mapper;
        private readonly IUiPageNavigationService _uiNavigationCategoryService;
        private readonly IUiPageMetadataService _uiPageMetadataService;
        private readonly IUiPageTypeService _uiPageTypeService;
        private readonly IModuleService _moduleService;

        public UiPageMetadataModuleBridgeController(IUiPageMetadataModuleBridgeService uiPageMetadataModuleBridgeService, IMapper mapper, IUiPageNavigationService uiNavigationCategoryService, IUiPageMetadataService uiPageMetadataService, IUiPageTypeService uiPageTypeService, IModuleService moduleService)
        {
            _uiPageMetadataModuleBridgeService = uiPageMetadataModuleBridgeService;
            _mapper = mapper;
            _uiNavigationCategoryService = uiNavigationCategoryService;
            _uiPageMetadataService = uiPageMetadataService;
            _uiPageTypeService = uiPageTypeService;
            _moduleService = moduleService;

        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UiPageMetadataModuleBridgeModel> page = _uiPageMetadataModuleBridgeService.Get();
            var pageData = _mapper.Map<List<UiPageMetadataModuleBridgeModel>, List<UiPageMetadataModuleBridgeDTO>>(page);
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
            if (id == null)
            {
                return NotFound();
            }
            var pageMetadata = _uiPageMetadataService.GetDisplayName();
            var pageList = _uiPageTypeService.Get();
            var Module = _moduleService.Get();
            ViewBag.PageMetadata = pageMetadata;
            ViewBag.PageList = pageList;
            ViewBag.ModuleName = Module;
            var getByIdPageModel = _uiPageMetadataModuleBridgeService.GetBy((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<UiPageMetadataModuleBridgeModel, UiPageMetadataModuleBridgeDTO>(getByIdPageModel);

            return View(pageData);
        }
        /// <summary>
        /// To Edit Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageMetadataModuleBridgeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] UiPageMetadataModuleBridgeDTO uiPageMetadataModuleBridgeDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<UiPageMetadataModuleBridgeDTO, UiPageMetadataModuleBridgeModel>(uiPageMetadataModuleBridgeDTO);
                _uiPageMetadataModuleBridgeService.Update(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageMetadataModuleBridgeDTO);
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var pageMetadata = _uiPageMetadataService.GetDisplayName();
            var pageList = _uiPageTypeService.Get();
            var Module = _moduleService.Get();
            ViewBag.PageMetadata = pageMetadata;
            ViewBag.PageList = pageList;
            ViewBag.ModuleName = Module;

            return base.View(new Models.UiPageMetadataModuleBridgeDTO { Id = id });
        }

        /// <summary>
        /// To Create Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageMetadataModuleBridgeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiPageMetadataModuleBridgeDTO uiPageMetadataModuleBridgeDTO)
        {
            if (ModelState.IsValid)
            {

                var pageModel = _mapper.Map<UiPageMetadataModuleBridgeDTO, UiPageMetadataModuleBridgeModel>(uiPageMetadataModuleBridgeDTO);
                _uiPageMetadataModuleBridgeService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageMetadataModuleBridgeDTO);
        }

        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UiPageMetadataModuleBridgeModel getByIdPageModel = _uiPageMetadataModuleBridgeService.GetBy((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<UiPageMetadataModuleBridgeModel, UiPageMetadataModuleBridgeDTO>(getByIdPageModel);
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
            if (id == null)
            {
                return NotFound();
            }
            _uiPageMetadataModuleBridgeService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}

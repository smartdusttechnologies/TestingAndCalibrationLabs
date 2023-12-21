using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageNavigationController : Controller
    {
        private readonly IUiPageNavigationService _uiPageNavigationService;
        private readonly IModuleService _uiModuleService;
        private readonly IMapper _mapper;
        private readonly IUiNavigationCategoryServices _uiPageNavigationCategoryServics;

        public UiPageNavigationController(IUiPageNavigationService uiPageNavigationService, IModuleService uiModuleService, IUiNavigationCategoryServices uiPageNavigationCategoryServics, IMapper mapper)
        {
            _uiPageNavigationService = uiPageNavigationService;
            _uiModuleService = uiModuleService;
            _mapper = mapper;
            _uiPageNavigationCategoryServics = uiPageNavigationCategoryServics;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From Ui Page Type With Navigation Category And Pass It TO Ajax Call
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithNavigationCategoryList = _uiPageNavigationService.Get();
            var pageNavigationList = _mapper.Map<List<UiPageNavigationModel>, List<UiPageNavigationDTO>>(pageWithNavigationCategoryList);

            if (pageNavigationList != null && pageNavigationList.Count > 0)
            {
                var dataAfterSorting = pageNavigationList.GroupBy(x => new { x.UiNavigationCategoryId, x.UiNavigationCategoryName, x.Orders , x.UiPageNavigationCategoryIcon, x.NavigationType}).Select(x => new { Id = x.Key.UiNavigationCategoryId, Name = x.Key.UiNavigationCategoryName, Orders = x.Key.Orders, IconName = x.Key.UiPageNavigationCategoryIcon, NavigationTypes = x.Key.NavigationType, Childrens = x.ToList() });
               
                return Ok(dataAfterSorting);
            }
            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UiPageNavigationModel> pageNavigationList = _uiPageNavigationService.Get();
            var pageNavigationModel = _mapper.Map<List<UiPageNavigationModel>, List<UiPageNavigationDTO>>(pageNavigationList);
            return View(pageNavigationModel.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            List<ModuleModel> moduleType = _uiModuleService.Get();
            moduleType = moduleType.Where(x => x.Id != (int)Helpers.None.Id).ToList();
            List<UiNavigationCategoryModel> navigationCategoryType = _uiPageNavigationCategoryServics.Get();
            var metaDataList = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(moduleType);
            var validationList = _mapper.Map<List<UiNavigationCategoryModel>, List<UiNavigationCategoryDTO>>(navigationCategoryType);
            ViewBag.Module = metaDataList;
            ViewBag.UiNavigationCategory = validationList;
            return base.View(new UiPageNavigationDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Ui Page Navigation
        /// </summary>
        /// <param name="uiPageNavigationDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiPageNavigationDTO uiPageNavigationDto)
        {
            if (ModelState.IsValid)
            {
                var createPageNavigation = _mapper.Map<UiPageNavigationDTO, UiPageNavigationModel>(uiPageNavigationDto);
                _uiPageNavigationService.Create(createPageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageNavigationDto);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeId"></param>
        /// <param name="uiPageMetadataId"></param>
        /// <param name="uiPageValidationTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id, string uiPageNavigationUrl, int uiModuleId, int uiPageNavigationCategoryId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Module = uiModuleId;
            ViewBag.UiNavigationCategory = uiPageNavigationCategoryId;
            List<ModuleModel> module = _uiModuleService.Get();
            List<UiNavigationCategoryModel> categoryType = _uiPageNavigationCategoryServics.Get();
            var moduleList = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(module);
            var categoryList = _mapper.Map<List<UiNavigationCategoryModel>, List<UiNavigationCategoryDTO>>(categoryType);
            ViewBag.Module = moduleList;
            ViewBag.UiNavigationCategory = categoryList;
            var getByIdPageNavigationType = _uiPageNavigationService.GetById((int)id);
            if (getByIdPageNavigationType == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<UiPageNavigationModel, UiPageNavigationDTO>(getByIdPageNavigationType);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In Ui Page Navigation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageNavigationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UiPageNavigationDTO uiPageNavigationDto)
        {
            if (ModelState.IsValid)
            {
                var pageNavigation = _mapper.Map<UiPageNavigationDTO, UiPageNavigationModel>(uiPageNavigationDto);
                _uiPageNavigationService.Update(id, pageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageNavigationDto);
        }
        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var getByIdPageNavigation = _uiPageNavigationService.GetById(id);
            var pageNavigation = _mapper.Map<UiPageNavigationModel, UiPageNavigationDTO>(getByIdPageNavigation);
            return View(pageNavigation);
        }
        /// <summary>
        /// To Delete Record From Ui Page Navigation
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
            _uiPageNavigationService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}
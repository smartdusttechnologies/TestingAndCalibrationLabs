using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageMetadataCharacteristicsController : Controller
    {
        private readonly IUiPageMetadataCharacteristicsService _uiPageMetadataCharacteristicsService;
        public readonly IMapper _mapper;
        public readonly ILookupCategoryService _lookupCategoryService;
        private readonly IUiPageMetadataService _uiPageMetadataService;
        public UiPageMetadataCharacteristicsController(IUiPageMetadataCharacteristicsService uiPageMetadataCharacteristicsService, IMapper mapper, ILookupCategoryService lookupCategoryService, IUiPageMetadataService uiPageMetadataService)
        {
            _uiPageMetadataCharacteristicsService = uiPageMetadataCharacteristicsService;
            _mapper = mapper;
            _lookupCategoryService = lookupCategoryService;
            _uiPageMetadataService = uiPageMetadataService;

        }
        /// <summary>
        /// To List All Record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UiPageMetadataCharacteristicsModel> controlTypeListModel = _uiPageMetadataCharacteristicsService.Get();
            var controlTypeList = _mapper.Map<List<UiPageMetadataCharacteristicsModel>, List<UiPageMetadataCharacteristicsDTO>>(controlTypeListModel);
            return View(controlTypeList.AsEnumerable());
        }
        /// <summary>
        /// To Get All PageMetadataCharacteristics By PageMetadataId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get(int id)
        {
            var list = _uiPageMetadataCharacteristicsService.GetByPageMetadataId(id);
            return Ok(list);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UiPageMetadataCharacteristicsModel uiPageMetadataCharacteristicsModel = _uiPageMetadataCharacteristicsService.GetById((int)id);
            var controlCategoryType = _lookupCategoryService.Get();
            var pageMetadata = _uiPageMetadataService.GetDisplayName();

            if (uiPageMetadataCharacteristicsModel == null)
            {
                return NotFound();
            }
            ViewBag.ControlCategoryName = controlCategoryType;
            ViewBag.DisplayName = pageMetadata;

            var controlTypeEditModel = _mapper.Map<UiPageMetadataCharacteristicsModel, UiPageMetadataCharacteristicsDTO>(uiPageMetadataCharacteristicsModel);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Edit Record In Ui Page Type
        /// </summary>
        /// <param name="uiControlTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] UiPageMetadataCharacteristicsDTO uiPageMetadataCharacteristicsModel)
        {
            if (ModelState.IsValid)
            {
                var controlTypeEditModel = _mapper.Map<UiPageMetadataCharacteristicsDTO, UiPageMetadataCharacteristicsModel>(uiPageMetadataCharacteristicsModel);
                _uiPageMetadataCharacteristicsService.Update(controlTypeEditModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageMetadataCharacteristicsModel);
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

            var controlCategoryType = _lookupCategoryService.Get();
            var controlCategoryTypeList = _mapper.Map<List<LookupCategoryModel>, List<LookupCategoryDTO>>(controlCategoryType);
            ViewBag.ControlCategoryName = controlCategoryTypeList;
            ViewBag.DisplayName = pageMetadata;

            return base.View(new UiPageMetadataCharacteristicsDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In UiPageMetadataCharacteristics
        /// </summary>
        /// <param name="uiControlTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiPageMetadataCharacteristicsDTO uiPageMetadataCharacteristicsModel)
        {
            if (ModelState.IsValid)
            {
                var controlTypeCreateModel = _mapper.Map<UiPageMetadataCharacteristicsDTO, UiPageMetadataCharacteristicsModel>(uiPageMetadataCharacteristicsModel);
                _uiPageMetadataCharacteristicsService.Create(controlTypeCreateModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageMetadataCharacteristicsModel);
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
            UiPageMetadataCharacteristicsModel getByIdControlType = _uiPageMetadataCharacteristicsService.GetById((int)id);
            if (getByIdControlType == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<UiPageMetadataCharacteristicsModel, UiPageMetadataCharacteristicsDTO>(getByIdControlType);
            return View(controlTypeEditModel);
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
            _uiPageMetadataCharacteristicsService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}

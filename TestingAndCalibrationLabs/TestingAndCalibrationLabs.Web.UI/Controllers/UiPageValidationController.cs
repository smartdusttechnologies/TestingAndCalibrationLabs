using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageValidationController : Controller
    {
        public readonly IUiPageValidationService _uiPageValidationTypeService;
        public readonly IUiPageTypeService _uiPageTypeService;
        public readonly IMapper _mapper;
        public readonly IUiPageMetadataService _uiPageMetadataService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiPageMetadataTypeService"></param>
        /// <param name="uiPageValidationTypeService"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="mapper"></param>
        public UiPageValidationController(IUiPageMetadataService uiPageMetadataService, IUiPageValidationService uiPageValidationTypeService, IUiPageTypeService uiPageTypeService,IMapper mapper)
        {
            _uiPageValidationTypeService = uiPageValidationTypeService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper; 
            _uiPageMetadataService = uiPageMetadataService;
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiPageValidationModel> pageValidationList = _uiPageValidationTypeService.GetAll();
            var pageValidationModel = _mapper.Map<List<Business.Core.Model.UiPageValidationModel>, List<Models.UiPageValidationModel>>(pageValidationList);
            return View(pageValidationModel.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            List<Business.Core.Model.UiPageTypeModel> pageType = _uiPageTypeService.GetAll();
            List<Business.Core.Model.UiPageMetadataModel> pageMetadataType = _uiPageMetadataService.GetAll();
            List<Business.Core.Model.UiPageValidationTypeModel> pageValidationType = _uiPageTypeService.GetUiPageValidationType();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(pageType);
            var metadataList = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(pageMetadataType);
            var validationList = _mapper.Map<List<Business.Core.Model.UiPageValidationTypeModel>, List<Models.UiPageValidationType>>(pageValidationType);
            ViewBag.UiPageTypes = pageList;
            ViewBag.UiPageMetadataTypes = metadataList;
            ViewBag.UiPageValidationTypes = validationList;

            return base.View(new Models.UiPageValidationModel { Id = id });
        }
        /// <summary>
        /// To Create Record In Ui Page Validation
        /// </summary>
        /// <param name="uiPageValidationModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageValidationModel uiPageValidationModel)
        {
            if (ModelState.IsValid)
            {
                var createPageValidation = _mapper.Map<Models.UiPageValidationModel, Business.Core.Model.UiPageValidationModel>(uiPageValidationModel);
                _uiPageValidationTypeService.Create(createPageValidation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageValidationModel);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeId"></param>
        /// <param name="uiPageMetadataTypeId"></param>
        /// <param name="uiPageValidationTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id, int uiPageTypeId, int uiPageValidationTypeId, int uiPageMetadataTypeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.UiPageTypeId = uiPageTypeId;
            ViewBag.UiPageValidaitonTypeId = uiPageValidationTypeId;
            ViewBag.UiPageMetadataTypeId=uiPageMetadataTypeId;
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.GetAll();
            List<Business.Core.Model.UiPageMetadataModel> metadata = _uiPageMetadataService.GetAll();
            List<Business.Core.Model.UiPageValidationTypeModel> val = _uiPageTypeService.GetUiPageValidationType();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var metadataList = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(metadata);
            var valList = _mapper.Map<List<Business.Core.Model.UiPageValidationTypeModel>, List<Models.UiPageValidationType>>(val);
            ViewBag.UiPageTypes=pageList;
            ViewBag.UiPageValidationTypes=valList;
            ViewBag.UiPageMetadataTypes=metadataList;

            var getByIdPageValidationType = _uiPageValidationTypeService.GetById((int)id);
            if (getByIdPageValidationType == null)
            {
                return NotFound();
            }
            var pageValidationModel = _mapper.Map<Business.Core.Model.UiPageValidationModel, Models.UiPageValidationModel>(getByIdPageValidationType);
            return View(pageValidationModel);
        }
        /// <summary>
        /// To Edit Record In Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageVal"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPageValidationModel uiPageValidationModel)
        {
            if (id != uiPageValidationModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var pageValidationEdit = _mapper.Map<Models.UiPageValidationModel, Business.Core.Model.UiPageValidationModel>(uiPageValidationModel);
                _uiPageValidationTypeService.Update(id ,pageValidationEdit);
                return RedirectToAction("Index");
            }
            return View(uiPageValidationModel);
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
            var getByIdPageValidationType = _uiPageValidationTypeService.GetById(id);
            var pageValidationModel = _mapper.Map<Business.Core.Model.UiPageValidationModel, Models.UiPageValidationModel>(getByIdPageValidationType);
            return View(pageValidationModel);
        }
        /// <summary>
        /// To Delete Record From Ui Page Validation
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
            _uiPageValidationTypeService.Delete((int)id);
            return RedirectToAction("Index");
        }
    }
}

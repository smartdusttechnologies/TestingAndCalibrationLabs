using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageValidationController : Controller
    {
        private readonly IUiPageValidationService _uiPageValidationService;
        private readonly IUiPageTypeService _uiPageTypeService;
        private readonly IMapper _mapper;
        private readonly IUiPageMetadataService _uiPageMetadataService;
        private readonly IUiPageValidationTypeService _uiPageValidationTypeService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiPageMetadataService"></param>
        /// <param name="uiPageValidationTypeService"></param>
        /// <param name="uiPageValidationService"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="mapper"></param>
        public UiPageValidationController(IUiPageValidationTypeService uiPageValidationTypeService, IUiPageMetadataService uiPageMetadataService, IUiPageValidationService uiPageValidationService, IUiPageTypeService uiPageTypeService,IMapper mapper)
        {
            _uiPageValidationService = uiPageValidationService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper; 
            _uiPageMetadataService = uiPageMetadataService;
            _uiPageValidationTypeService = uiPageValidationTypeService;
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiPageValidationModel> pageValidationList = _uiPageValidationService.Get();
            var pageValidationModel = _mapper.Map<List<Business.Core.Model.UiPageValidationModel>, List<Models.UiPageValidationDTO>>(pageValidationList);
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
            List<Business.Core.Model.UiPageTypeModel> pageType = _uiPageTypeService.Get();
            List<Business.Core.Model.UiPageMetadataModel> pageMetadataType = _uiPageMetadataService.Get();
            List<Business.Core.Model.UiPageValidationTypeModel> pageValidationType = _uiPageValidationTypeService.Get();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeDTO>>(pageType);
            var metadataList = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(pageMetadataType);
            var validationList = _mapper.Map<List<Business.Core.Model.UiPageValidationTypeModel>, List<Models.UiPageValidationTypeDTO>>(pageValidationType);
            ViewBag.UiPageTypes = pageList;
            ViewBag.UiPageMetadata = metadataList;
            ViewBag.UiPageValidationTypes = validationList;

            return base.View(new Models.UiPageValidationDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Ui Page Validation
        /// </summary>
        /// <param name="uiPageValidationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageValidationDTO uiPageValidationDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageValidation = _mapper.Map<Models.UiPageValidationDTO, Business.Core.Model.UiPageValidationModel>(uiPageValidationDTO);
                _uiPageValidationService.Create(createPageValidation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageValidationDTO);
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
        public IActionResult Edit(int? id, int uiPageTypeId, int uiPageValidationTypeId, int uiPageMetadataId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.UiPageTypeId = uiPageTypeId;
            ViewBag.UiPageValidaitonTypeId = uiPageValidationTypeId;
            ViewBag.UiPageMetadataId=uiPageMetadataId;
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.Get();
            List<Business.Core.Model.UiPageMetadataModel> metadata = _uiPageMetadataService.Get();
            List<Business.Core.Model.UiPageValidationTypeModel> uiPagevalidationType = _uiPageValidationTypeService.Get();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeDTO>>(page);
            var metadataList = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(metadata);
            var valList = _mapper.Map<List<Business.Core.Model.UiPageValidationTypeModel>, List<Models.UiPageValidationTypeDTO>>(uiPagevalidationType);
            ViewBag.UiPageTypes=pageList;
            ViewBag.UiPageValidationTypes=valList;
            ViewBag.UiPageMetadata=metadataList;

            var getByIdPageValidationType = _uiPageValidationService.GetById((int)id);
            if (getByIdPageValidationType == null)
            {
                return NotFound();
            }
            var pageValidationModel = _mapper.Map<Business.Core.Model.UiPageValidationModel, Models.UiPageValidationDTO>(getByIdPageValidationType);
            return View(pageValidationModel);
        }
        /// <summary>
        /// To Edit Record In Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageValidationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPageValidationDTO uiPageValidationDTO)
        {
            if (id != uiPageValidationDTO.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var pageValidationEdit = _mapper.Map<Models.UiPageValidationDTO, Business.Core.Model.UiPageValidationModel>(uiPageValidationDTO);
                _uiPageValidationService.Update(id ,pageValidationEdit);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageValidationDTO);
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
            var getByIdPageValidationType = _uiPageValidationService.GetById(id);
            var pageValidationModel = _mapper.Map<Business.Core.Model.UiPageValidationModel, Models.UiPageValidationDTO>(getByIdPageValidationType);
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
            _uiPageValidationService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}

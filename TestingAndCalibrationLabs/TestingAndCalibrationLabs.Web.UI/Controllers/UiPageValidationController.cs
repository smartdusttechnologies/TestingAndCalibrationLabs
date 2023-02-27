using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Web.UI.Models.Common;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageValidationController : Controller
    {
        private readonly IUiPageValidationService _uiPageValidationService;
        private readonly IUiPageTypeService _uiPageTypeService;
        private readonly IMapper _mapper;
        private readonly IUiPageMetadataService _uiPageMetadataService;
        private readonly IUiPageValidationTypeService _uiPageValidationTypeService;
        
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
            var gridDto = new GridDTO();
            gridDto.Columns = typeof(UiPageValidationDTO).GetProperties().Select(x => x.Name).ToList();
            gridDto.Values = new List<GridRow>();

            foreach (var row in pageValidationModel)
            {
                var rowValue = new GridRow();
                rowValue.Id = row.Id;

                rowValue.Values = new List<string>();
                rowValue.Values.Add(row.Id.ToString());
                rowValue.Values.Add(row.UiPageTypeId.ToString());
                rowValue.Values.Add(row.UiPageTypeName);
                rowValue.Values.Add(row.UiPageMetadataId.ToString());
                rowValue.Values.Add(row.UiPageMetadataName);
                rowValue.Values.Add(row.UiPageValidationTypeId.ToString());
                rowValue.Values.Add(row.UiPageValidationTypeName);

                gridDto.Values.Add(rowValue);
            }
                 var uiData = new IndexPageDTO();
                 uiData.PageTitle = "UI Page Validation";
                 uiData.GridData = gridDto;
                 return View(uiData);
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            List<UiPageTypeModel> pageType = _uiPageTypeService.Get();
            List<UiPageMetadataModel> pageMetadataType = _uiPageMetadataService.Get();
            List<UiPageValidationTypeModel> pageValidationType = _uiPageValidationTypeService.Get();
            var pageList = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pageType);
            var metadataList = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(pageMetadataType);
            var validationList = _mapper.Map<List<UiPageValidationTypeModel>, List<UiPageValidationType>>(pageValidationType);
            ViewBag.UiPageTypes = pageList;
            ViewBag.UiPageMetadata = metadataList;
            ViewBag.UiPageValidationTypes = validationList;

            return base.View(new UiPageValidationDTO { Id = id });
        }

        /// <summary>
        /// To Create Record In Ui Page Validation
        /// </summary>
        /// <param name="uiPageValidationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiPageValidationDTO uiPageValidationDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageValidation = _mapper.Map<UiPageValidationDTO, UiPageValidationModel>(uiPageValidationDTO);
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
        public IActionResult Edit(int? id  )
        {
            if (id == null)
            {
                return NotFound();
            }
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
            var pageValidationModel = _mapper.Map<UiPageValidationModel, UiPageValidationDTO>(getByIdPageValidationType);
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
        public IActionResult Edit(int id, [Bind] UiPageValidationDTO uiPageValidationDTO)
        {
            if (id != uiPageValidationDTO.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var pageValidationEdit = _mapper.Map<UiPageValidationDTO, UiPageValidationModel>(uiPageValidationDTO);
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
            var pageValidationModel = _mapper.Map<UiPageValidationModel, UiPageValidationDTO>(getByIdPageValidationType);
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

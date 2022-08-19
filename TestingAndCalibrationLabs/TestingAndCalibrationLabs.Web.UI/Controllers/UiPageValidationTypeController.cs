using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageValidationTypeController : Controller
    {
        public readonly IUiPageValidationTypeService _uiPageValidationTypeService;
        public readonly IUiPageTypeService _uiPageTypeService;
        public readonly IMapper _mapper;

        public UiPageValidationTypeController(IUiPageValidationTypeService uiPageValidationTypeService, IUiPageTypeService uiPageTypeService,IMapper mapper)
        {
            _uiPageValidationTypeService = uiPageValidationTypeService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;   
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiPageValidationModel> pageReq = _uiPageValidationTypeService.GetAll();
            var pvList = _mapper.Map<List<Business.Core.Model.UiPageValidationModel>, List<Models.UiPageValidationModel>>(pageReq);
            return View(pvList.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.GetAll();
            List<Business.Core.Model.UiPageMetadataModel> metadata = _uiPageTypeService.GetUiPageMetadataType();
            List<Business.Core.Model.UiPageValidationTypeModel> val = _uiPageTypeService.GetUiPageValType();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var metadataList = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(metadata);
            var valList = _mapper.Map<List<Business.Core.Model.UiPageValidationTypeModel>, List<Models.UiPageValidationType>>(val);
            ViewBag.Page = pageList.ToList();
            ViewBag.Metadata = metadataList.ToList();
            ViewBag.Val = valList.ToList();

            return base.View(new Models.UiPageValidationModel { Id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageValidationModel pagVal)
        {
            if (ModelState.IsValid)
            {
                var createPV = _mapper.Map<Models.UiPageValidationModel, Business.Core.Model.UiPageValidationModel>(pagVal);
                _uiPageValidationTypeService.Create(createPV);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(pagVal);
        }
        [HttpGet]
        public IActionResult Edit(int? id, int pId, int vId, int mId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.pid = pId;
            ViewBag.vid = vId;
            ViewBag.mid=mId;
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.GetAll();
            List<Business.Core.Model.UiPageMetadataModel> metadata = _uiPageTypeService.GetUiPageMetadataType();
            List<Business.Core.Model.UiPageValidationTypeModel> val = _uiPageTypeService.GetUiPageValType();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var metadataList = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(metadata);
            var valList = _mapper.Map<List<Business.Core.Model.UiPageValidationTypeModel>, List<Models.UiPageValidationType>>(val);
            ViewBag.Page=pageList;
            ViewBag.Val=valList;
            ViewBag.Meta=metadataList;

            var gbiValidation = _uiPageValidationTypeService.GetById((int)id);
            if (gbiValidation == null)
            {
                return NotFound();
            }
            var pvList = _mapper.Map<Business.Core.Model.UiPageValidationModel, Models.UiPageValidationModel>(gbiValidation);
            return View(pvList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPageValidationModel pageVal)
        {
            if (id != pageVal.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var editPV = _mapper.Map<Models.UiPageValidationModel, Business.Core.Model.UiPageValidationModel>(pageVal);
                _uiPageValidationTypeService.Update(id ,editPV);
                return RedirectToAction("Index");
            }
            return View(pageVal);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gbiValidation = _uiPageValidationTypeService.GetById(id);
            var pvList = _mapper.Map<Business.Core.Model.UiPageValidationModel, Models.UiPageValidationModel>(gbiValidation);
            return View(pvList);
        }
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

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
        public readonly IUiPageMetadataTypeService _uiPageMetadataTypeService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiPageMetadataTypeService"></param>
        /// <param name="uiPageValidationTypeService"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="mapper"></param>
        public UiPageValidationController(IUiPageMetadataTypeService uiPageMetadataTypeService, IUiPageValidationService uiPageValidationTypeService, IUiPageTypeService uiPageTypeService,IMapper mapper)
        {
            _uiPageValidationTypeService = uiPageValidationTypeService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper; 
            _uiPageMetadataTypeService = uiPageMetadataTypeService;
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiPageValidationModel> pageReq = _uiPageValidationTypeService.GetAll();
            var pvList = _mapper.Map<List<Business.Core.Model.UiPageValidationModel>, List<Models.UiPageValidationModel>>(pageReq);
            return View(pvList.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.GetAll();
            List<Business.Core.Model.UiPageMetadataModel> metadata = _uiPageMetadataTypeService.GetAll();
            List<Business.Core.Model.UiPageValidationTypeModel> val = _uiPageTypeService.GetUiPageValidationType();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var metadataList = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(metadata);
            var valList = _mapper.Map<List<Business.Core.Model.UiPageValidationTypeModel>, List<Models.UiPageValidationType>>(val);
            ViewBag.Page = pageList.ToList();
            ViewBag.Metadata = metadataList.ToList();
            ViewBag.Val = valList.ToList();

            return base.View(new Models.UiPageValidationModel { Id = id });
        }
        /// <summary>
        /// To Create Record In Ui Page Validation
        /// </summary>
        /// <param name="pagVal"></param>
        /// <returns></returns>
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
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pId"></param>
        /// <param name="vId"></param>
        /// <param name="mId"></param>
        /// <returns></returns>
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
            List<Business.Core.Model.UiPageMetadataModel> metadata = _uiPageMetadataTypeService.GetAll();
            List<Business.Core.Model.UiPageValidationTypeModel> val = _uiPageTypeService.GetUiPageValidationType();
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
        /// <summary>
        /// To Edit Record In Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageVal"></param>
        /// <returns></returns>
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
            var gbiValidation = _uiPageValidationTypeService.GetById(id);
            var pvList = _mapper.Map<Business.Core.Model.UiPageValidationModel, Models.UiPageValidationModel>(gbiValidation);
            return View(pvList);
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

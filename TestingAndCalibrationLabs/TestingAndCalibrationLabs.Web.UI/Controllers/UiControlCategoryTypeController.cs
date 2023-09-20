using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiControlCategoryTypeController : Controller
    {
        public readonly IUiControlCategoryTypeService _uiControlCategoryTypeServices;
        public readonly IMapper _mapper;
        public readonly IUiControlTypeService _uiControlTypeServices;

        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeServices"></param>
        /// <param name="mapper"></param>
        public UiControlCategoryTypeController(IUiControlCategoryTypeService uiControlCategoryTypeServices, IMapper mapper, IUiControlTypeService uiControlTypeServices)
        {
            _uiControlCategoryTypeServices = uiControlCategoryTypeServices;
            _mapper = mapper;
            _uiControlTypeServices= uiControlTypeServices;   
        }
        /// <summary>
        /// For Showing All Records Of Ui Control Category Type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UiControlCategoryTypeModel> controlTypeListModel = _uiControlCategoryTypeServices.Get();
            var controlTypeList = _mapper.Map<List<UiControlCategoryTypeModel>, List<UiControlCategoryTypeDTO>>(controlTypeListModel);
            return View(controlTypeList.AsEnumerable());
        }
        /// <summary>
        /// For Showing Choosen Record For Edit
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
            List<UiControlTypeModel> categoryType = _uiControlTypeServices.Get();
            var categoryList = _mapper.Map<List<UiControlTypeModel>, List<UiControlTypeDTO>>(categoryType);
            ViewBag.UiControlTypeName = categoryList;
            UiControlCategoryTypeModel controlTypeModel = _uiControlCategoryTypeServices.GetById((int)id);
            if (controlTypeModel == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<UiControlCategoryTypeModel, UiControlCategoryTypeDTO>(controlTypeModel);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Edit Record From Ui Control Category Type
        /// </summary>
        /// <param name="uiControlTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] UiControlCategoryTypeDTO uiControlCategoryTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var controlTypeEditModel = _mapper.Map<UiControlCategoryTypeDTO, UiControlCategoryTypeModel>(uiControlCategoryTypeDTO);
                _uiControlCategoryTypeServices.Update(controlTypeEditModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiControlCategoryTypeDTO);
        }
        /// <summary>
        /// For Create View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            List<UiControlTypeModel> navigationCategoryType = _uiControlTypeServices.Get();
            var validationList = _mapper.Map<List<UiControlTypeModel>, List<UiControlTypeDTO>>(navigationCategoryType);
            ViewBag.UiControlTypeName = validationList;
            return base.View(new UiControlCategoryTypeDTO { Id = id });
        }
        /// <summary>
        /// To Insert Record
        /// </summary>
        /// <param name="uiControlTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiControlCategoryTypeDTO uiControlCategoryTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var controlTypeCreateModel = _mapper.Map<UiControlCategoryTypeDTO, UiControlCategoryTypeModel>(uiControlCategoryTypeDTO);
                _uiControlCategoryTypeServices.Create(controlTypeCreateModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiControlCategoryTypeDTO);
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
            UiControlCategoryTypeModel getByIdControlType = _uiControlCategoryTypeServices.GetById((int)id);
            if (getByIdControlType == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<UiControlCategoryTypeModel, UiControlCategoryTypeDTO>(getByIdControlType);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Delete Record From Ui Control Category Type
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
            _uiControlCategoryTypeServices.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}
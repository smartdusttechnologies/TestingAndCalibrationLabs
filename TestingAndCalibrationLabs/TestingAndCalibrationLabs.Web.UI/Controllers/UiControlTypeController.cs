﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiControlTypeController : Controller
    {
        public readonly IUiControlTypeService _uiControlTypeServices;
        public readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeServices"></param>
        /// <param name="mapper"></param>
        public UiControlTypeController(IUiControlTypeService uiControlTypeServices,IMapper mapper)
        {
            _uiControlTypeServices = uiControlTypeServices;
            _mapper = mapper;
        }
        /// <summary>
        /// For Showing All Records Of Ui Control Type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiControlTypeModel> controlTypeListModel = _uiControlTypeServices.Get();
            var controlTypeList = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeModel>>(controlTypeListModel);
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
            Business.Core.Model.UiControlTypeModel controlTypeModel = _uiControlTypeServices.GetById((int)id);
            if (controlTypeModel == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<Business.Core.Model.UiControlTypeModel, Models.UiControlTypeModel>(controlTypeModel);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Edit Record From Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] Models.UiControlTypeModel uiControlTypeModel)
        {
            
            if (ModelState.IsValid)
            {
                var controlTypeEditModel = _mapper.Map<Models.UiControlTypeModel, Business.Core.Model.UiControlTypeModel>(uiControlTypeModel);
                _uiControlTypeServices.Update(controlTypeEditModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiControlTypeModel);
        }
        /// <summary>
        /// For Create View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {

            return base.View(new Models.UiControlTypeModel { Id = id });
        }
        /// <summary>
        /// To Insert Record
        /// </summary>
        /// <param name="conModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiControlTypeModel uiControlTypeModel)
        {
            if (ModelState.IsValid)
            {
                var controlTypeCreateModel = _mapper.Map<Models.UiControlTypeModel, Business.Core.Model.UiControlTypeModel>(uiControlTypeModel);
                _uiControlTypeServices.Create(controlTypeCreateModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiControlTypeModel);
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
            Business.Core.Model.UiControlTypeModel getByIdControlType = _uiControlTypeServices.GetById((int)id);
            if (getByIdControlType == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<Business.Core.Model.UiControlTypeModel, Models.UiControlTypeModel>(getByIdControlType);
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
            _uiControlTypeServices.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }


    }
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class LookupController : Controller
    {
        private readonly ILookupService _lookupService;
        private readonly ILookupCategoryService _lookupCategoryService;
        private readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="lookupService"></param>
        /// <param name="mapper"></param>
        /// <param name="lookupCategoryService"></param>
       
        public LookupController(IMapper mapper, ILookupService lookupService, ILookupCategoryService lookupCategoryService)
        {
            _lookupService = lookupService;
            _mapper = mapper;
            _lookupCategoryService = lookupCategoryService;

        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<LookupModel> page = _lookupService.Get();
            var pageData = _mapper.Map<List<LookupModel>, List<LookupDTO>>(page);
            return View(pageData.AsEnumerable());
        }

        /// <summary>
        /// For Edit Records View
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
            var lookupCategoryList = _lookupCategoryService.Get();
            var lookupCategoryDatas = _mapper.Map<List<LookupCategoryModel>, List<LookupCategoryDTO>>(lookupCategoryList);
            ViewBag.LookupCategory = lookupCategoryDatas;

            var getByIdPageModel = _lookupService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<LookupModel, LookupDTO>(getByIdPageModel);

            return View(pageData);
        }
        /// <summary>
        /// To Edit Record In Module
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] LookupDTO lookupDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<LookupDTO, LookupModel>(lookupDTO);
                _lookupService.Update(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(lookupDTO);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var applicationList = _lookupCategoryService.Get();
            var applicationDatas = _mapper.Map<List<LookupCategoryModel>, List<LookupCategoryDTO>>(applicationList);
            ViewBag.LookupCategory = applicationDatas;


            return base.View(new LookupDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Module
        /// </summary>
        /// <param name="lookupDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] LookupDTO lookupDTO)
        {
            if (ModelState.IsValid)
            {

                var pageModel = _mapper.Map<LookupDTO, LookupModel>(lookupDTO);
                _lookupService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(lookupDTO);
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
            LookupModel getByIdPageModel = _lookupService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<LookupModel, LookupDTO>(getByIdPageModel);
            return View(pageModel);
        }
        /// <summary>
        /// To Delete Record In Module
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
            _lookupService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

    }
}

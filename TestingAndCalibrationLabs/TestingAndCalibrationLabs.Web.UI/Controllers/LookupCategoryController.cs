using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class LookupCategoryController : Controller
    {
        public readonly ILookupCategoryService _LookupCategoryService;
        public readonly IMapper _mapper;
        private readonly IUiPageNavigationService _uiNavigationCategoryService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="LookupCategoryService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiNavigationCategoryService"></param>

        public LookupCategoryController(ILookupCategoryService LookupCategoryService, IMapper mapper, IUiPageNavigationService uiNavigationCategoryService)
        {
            _LookupCategoryService = LookupCategoryService;
            _mapper = mapper;
            _uiNavigationCategoryService = uiNavigationCategoryService;
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<LookupCategoryModel> page = _LookupCategoryService.Get();
            var pageData = _mapper.Map<List<LookupCategoryModel>, List<LookupCategoryDTO>>(page);
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
            var getByIdPageModel = _LookupCategoryService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<LookupCategoryModel, LookupCategoryDTO>(getByIdPageModel);

            return View(pageData);
        }
        /// <summary>
        /// To Edit Record In LookupCategory
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] LookupCategoryDTO LookupCategoryDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<LookupCategoryDTO, LookupCategoryModel>(LookupCategoryDTO);
                _LookupCategoryService.Update(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(LookupCategoryDTO);
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.LookupCategoryDTO { Id = id });
        }

        /// <summary>
        /// To Create Record In LookupCategory
        /// </summary>
        /// <param name="LookupCategoryDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] LookupCategoryDTO LookupCategoryDTO)
        {
            if (ModelState.IsValid)
            {

                var pageModel = _mapper.Map<LookupCategoryDTO, LookupCategoryModel>(LookupCategoryDTO);
                _LookupCategoryService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(LookupCategoryDTO);
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
            LookupCategoryModel getByIdPageModel = _LookupCategoryService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<LookupCategoryModel, LookupCategoryDTO>(getByIdPageModel);
            return View(pageModel);
        }

        /// <summary>
        /// To Delete Record In LookupCategory
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
            _LookupCategoryService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

    }
}

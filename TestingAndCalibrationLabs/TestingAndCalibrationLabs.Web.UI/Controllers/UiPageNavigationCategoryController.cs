using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageNavigationCategoryController : Controller
    {
        public readonly IUiNavigationCategoryServices _uiPageNavigationCategoryServics;
        public readonly IMapper _mapper;
       private readonly IUiPageNavigationService _uiNavigationCategoryService;

        public UiPageNavigationCategoryController(IUiNavigationCategoryServices uiPageNavigationCategoryServics, IMapper mapper)
        {
            _uiPageNavigationCategoryServics = uiPageNavigationCategoryServics;
            _mapper = mapper;
           
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UiNavigationCategoryModel> page = _uiPageNavigationCategoryServics.Get();
            var pageData = _mapper.Map<List<UiNavigationCategoryModel>, List<UiNavigationCategoryDTO>>(page);
            return View(pageData.AsEnumerable());
        }

        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NavigationCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var getByIdPageModel = _uiPageNavigationCategoryServics.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<UiNavigationCategoryModel,UiNavigationCategoryDTO>(getByIdPageModel);

            return View(pageData);
        }

        /// <summary>
        /// To Edit Record In Ui Page Navigation Category
        /// </summary>
        /// <param name="uiNavigationCategoryDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UiNavigationCategoryDTO UiNavigationCategoryDto)
        {

            if (ModelState.IsValid)
            {
                var pageNavigation = _mapper.Map<UiNavigationCategoryDTO, UiNavigationCategoryModel>(UiNavigationCategoryDto);
                _uiPageNavigationCategoryServics.Update(id, pageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(UiNavigationCategoryDto);
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.UiNavigationCategoryDTO { Id = id });
        }

        /// <summary>
        /// To Create Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiNavigationCategoryDTO UiNavigationCategoryDto)
        {
            if (ModelState.IsValid)
            {
                var NavigationPageModel = _mapper.Map<UiNavigationCategoryDTO, UiNavigationCategoryModel>(UiNavigationCategoryDto);
                _uiPageNavigationCategoryServics.Create(NavigationPageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(UiNavigationCategoryDto);
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
            UiNavigationCategoryModel getByIdPageModel = _uiPageNavigationCategoryServics.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<UiNavigationCategoryModel, UiNavigationCategoryDTO>(getByIdPageModel);
            return View(pageModel);
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
            _uiPageNavigationCategoryServics.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}


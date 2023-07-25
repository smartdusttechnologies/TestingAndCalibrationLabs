using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageTypeController : Controller
    {
        public readonly IUiPageTypeService _uiPageTypeService;
        public readonly IMapper _mapper;
        private readonly IUiNavigationCategoryService _uiNavigationCategoryService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiPageTypeService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiNavigationCategoryService"></param>
        public UiPageTypeController(IUiPageTypeService uiPageTypeService, IMapper mapper, IUiNavigationCategoryService uiNavigationCategoryService)
        {
            _uiPageTypeService = uiPageTypeService;
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
            List<UiPageTypeModel> page = _uiPageTypeService.Get();
            var pageData = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeDTO>>(page);
            return View(pageData.AsEnumerable());
        }
        
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NavigationCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id,int NavigationCategoryId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var navigationCategory = _uiNavigationCategoryService.Get();
            var navigationCategoryList = _mapper.Map<List<Business.Core.Model.UiNavigationCategoryModel>, List<Models.UiNavigationCategoryDTO>>(navigationCategory);
            ViewBag.NavigationCategoryId = NavigationCategoryId;
            ViewBag.UiNavigationCategory = navigationCategoryList;
            var getByIdPageModel = _uiPageTypeService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<Business.Core.Model.UiPageTypeModel, Models.UiPageTypeDTO>(getByIdPageModel);

            return View(pageData);
        }
        /// <summary>
        /// To Edit Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( [Bind] Models.UiPageTypeDTO uiPageTypeDTO)
        {
            
            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<Models.UiPageTypeDTO, Business.Core.Model.UiPageTypeModel>(uiPageTypeDTO);
                _uiPageTypeService.Update( pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageTypeDTO);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var navigationCategory = _uiNavigationCategoryService.Get();
            var navigationCategoryList = _mapper.Map<List<Business.Core.Model.UiNavigationCategoryModel>,List<Models.UiNavigationCategoryDTO>>(navigationCategory);
            ViewBag.UiNavigationCategory = navigationCategoryList;

            return base.View(new Models.UiPageTypeDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageTypeDTO uiPageTypeDTO)
        {
            if (ModelState.IsValid)
            {
               
                var pageModel = _mapper.Map<Models.UiPageTypeDTO, Business.Core.Model.UiPageTypeModel>(uiPageTypeDTO);
                _uiPageTypeService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageTypeDTO);
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
            Business.Core.Model.UiPageTypeModel getByIdPageModel = _uiPageTypeService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<Business.Core.Model.UiPageTypeModel, Models.UiPageTypeDTO>(getByIdPageModel);
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
            _uiPageTypeService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }


    }
}

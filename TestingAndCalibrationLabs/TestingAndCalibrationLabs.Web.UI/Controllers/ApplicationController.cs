using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class ApplicationController : Controller
    {
        public readonly IApplicationService _applicationService;
        public readonly IMapper _mapper;
        private readonly IUiPageNavigationService _uiNavigationCategoryService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="applicationService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiNavigationCategoryService"></param>
       
        public ApplicationController(IApplicationService applicationService, IMapper mapper, IUiPageNavigationService uiNavigationCategoryService)
        {
            _applicationService = applicationService;
            _mapper = mapper;
            _uiNavigationCategoryService = uiNavigationCategoryService;
            _uiNavigationCategoryService = uiNavigationCategoryService;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<ApplicationModel> page = _applicationService.Get();
            var pageData = _mapper.Map<List<ApplicationModel>, List<ApplicationDTO>>(page);
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
            var getByIdPageModel = _applicationService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<ApplicationModel, ApplicationDTO>(getByIdPageModel);

            return View(pageData);
        }

        /// <summary>
        /// To Edit Record In Application
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,[Bind] ApplicationDTO applicationDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<ApplicationDTO, ApplicationModel>(applicationDTO);
                _applicationService.Update(pageModel);
            //    TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(applicationDTO);
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.ApplicationDTO { Id = id });
        }

        /// <summary>
        /// To Create Record In Application
        /// </summary>
        /// <param name="applicationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ApplicationDTO applicationDTO)
        {
            if (ModelState.IsValid)
            {

                var pageModel = _mapper.Map<ApplicationDTO, ApplicationModel>(applicationDTO);
                _applicationService.Create(pageModel);
              //  TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(applicationDTO);
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
            ApplicationModel getByIdPageModel = _applicationService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<ApplicationModel, ApplicationDTO>(getByIdPageModel);
            return View(pageModel);
        }

        /// <summary>
        /// To Delete Record In Application
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
            _applicationService.Delete((int)id);
           // TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}
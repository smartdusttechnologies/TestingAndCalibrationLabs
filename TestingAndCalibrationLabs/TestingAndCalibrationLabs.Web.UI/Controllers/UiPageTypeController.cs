using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
   
    public class UiPageTypeController : Controller
    {
        public readonly IUiPageTypeService _uiPageTypeService;
        public readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiPageTypeService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiNavigationCategoryService"></param>
        public UiPageTypeController(IHttpContextAccessor httpContextAccessor, IUiPageTypeService uiPageTypeService, IMapper mapper, ILogger<UiPageTypeController> logger)
        {
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var context = _httpContextAccessor.HttpContext;
                ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
                List<UiPageTypeModel> page = _uiPageTypeService.Get();
                var pageData = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(page);
                _logger.LogInformation("uipage type index accessed");
                return View(pageData.AsEnumerable());
            }
           catch
            {
                _logger.LogError("You are unauthorized");
            }
            return View();
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
            try
            {
                if (id == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                var getByIdPageModel = _uiPageTypeService.GetById((int)id);
                if (getByIdPageModel == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                var pageData = _mapper.Map<UiPageTypeModel, UiPageTypeDTO>(getByIdPageModel);
                _logger.LogInformation("uipagetype edit  accessed");
                return View(pageData);
            }
          catch
            {
                _logger.LogError("you are unauthorized");
            }
            return View();
        }
          
        /// <summary>
        /// To Edit Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( [Bind] UiPageTypeDTO uiPageTypeDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pageModel = _mapper.Map<UiPageTypeDTO, UiPageTypeModel>(uiPageTypeDTO);
                    _uiPageTypeService.Update(pageModel);
                    TempData["IsTrue"] = true;
                    return RedirectToAction("Index");
                }
                _logger.LogError("you are unauthorized");
                return View(uiPageTypeDTO);
            }
            catch
            {
                _logger.LogError("you are unauthorized");
            }
            return View();
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            try
            {
                return base.View(new Models.UiPageTypeDTO { Id = id });
            }
            catch
            {
                _logger.LogError("you are unauthorized");
            }
            return View();

        }

        /// <summary>
        /// To Create Record In Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiPageTypeDTO uiPageTypeDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var pageModel = _mapper.Map<UiPageTypeDTO, UiPageTypeModel>(uiPageTypeDTO);
                    _uiPageTypeService.Create(pageModel);
                    TempData["IsTrue"] = true;
                    _logger.LogInformation("uipage type create accessed");
                    return RedirectToAction("Index");
                }
                _logger.LogError("you are unauthorized");
                return View(uiPageTypeDTO);
            }
            catch
            {
                _logger.LogError("you are unauthorized");
            }
            return View();

        }

        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                UiPageTypeModel getByIdPageModel = _uiPageTypeService.GetById((int)id);
                if (getByIdPageModel == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                var pageModel = _mapper.Map<UiPageTypeModel, UiPageTypeDTO>(getByIdPageModel);
                _logger.LogInformation("uipage type delete accessed");
                return View(pageModel);
            }
            catch
            {
                _logger.LogError("you are unauthorized");
            }
            return View();

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
            try
            {
                if (id == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                _uiPageTypeService.Delete((int)id);
                TempData["IsTrue"] = true;
                _logger.LogInformation("uipage type delete accessed");
                return RedirectToAction("Index");
            }
            catch
            {
                _logger.LogError("you are unauthorized");
            }
            return View();
        }
    }
}

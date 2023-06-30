using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;
using NLog;


namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiControlTypeController : Controller
    {
        public readonly IUiControlTypeService _uiControlTypeServices;
        public readonly IListSorterService _listSorterService;
        public readonly IMapper _mapper;
        public readonly Microsoft.Extensions.Logging.ILogger _logger;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeServices"></param>
        /// <param name="mapper"></param>
        /// 

        public UiControlTypeController(IUiControlTypeService uiControlTypeServices,IMapper mapper, IListSorterService listSorterService, ILogger<UiControlTypeController> logger)
        {
            _uiControlTypeServices = uiControlTypeServices;
            _mapper = mapper;
            _listSorterService = listSorterService;
            _logger = logger;
        }

        /// <summary>
        /// For Showing All Records Of Ui Control Type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index page has been accessed");
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UiControlTypeModel> controlTypeListModel = _uiControlTypeServices.Get();
            var controlTypeList = _mapper.Map<List<UiControlTypeModel>, List<UiControlTypeDTO>>(controlTypeListModel);
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
            _logger.LogInformation("The Edit get page has been accessed");
            if (id == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            UiControlTypeModel controlTypeModel = _uiControlTypeServices.GetById((int)id);
            if (controlTypeModel == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<UiControlTypeModel, UiControlTypeDTO>(controlTypeModel);
            return View(controlTypeEditModel);
        }

        /// <summary>
        /// To Edit Record From Ui Control Type
        /// </summary>
        /// <param name="uiControlTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] UiControlTypeDTO uiControlTypeDTO)
        {
            _logger.LogInformation("The Edit post page has been accessed");
            if (ModelState.IsValid)
            {
                var controlTypeEditModel = _mapper.Map<UiControlTypeDTO, UiControlTypeModel>(uiControlTypeDTO);
                _uiControlTypeServices.Update(controlTypeEditModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiControlTypeDTO);
        }

        /// <summary>
        /// For Create View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            _logger.LogInformation("The Create get page has been accessed");
            return base.View(new UiControlTypeDTO { Id = id });
        }

        /// <summary>
        /// To Insert Record
        /// </summary>
        /// <param name="uiControlTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiControlTypeDTO uiControlTypeDTO)
        {
            _logger.LogInformation("The Create post page has been accessed");
            if (ModelState.IsValid)
            {
                var controlTypeCreateModel = _mapper.Map<UiControlTypeDTO, UiControlTypeModel>(uiControlTypeDTO);
                _uiControlTypeServices.Create(controlTypeCreateModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiControlTypeDTO);
        }

        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("The Delete get page has been accessed");
            if (id == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            UiControlTypeModel getByIdControlType = _uiControlTypeServices.GetById((int)id);
            if (getByIdControlType == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<UiControlTypeModel, UiControlTypeDTO>(getByIdControlType);
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
            _logger.LogInformation("The Delete post page has been accessed");
            if (id == null)
            {
                _logger.LogError("id is null");
                return NotFound();
            }
            _uiControlTypeServices.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}

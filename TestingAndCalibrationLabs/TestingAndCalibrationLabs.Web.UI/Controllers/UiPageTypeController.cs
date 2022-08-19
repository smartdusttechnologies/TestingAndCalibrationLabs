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
        public UiPageTypeController(IUiPageTypeService uiPageTypeService, IMapper mapper)
        {
            _uiPageTypeService = uiPageTypeService;
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
            List<UiPageTypeModel> page = _uiPageTypeService.GetAll();
            var pageData = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            return View(pageData.AsEnumerable());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pageModel = _uiPageTypeService.GetById((int)id);
            if (pageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<Business.Core.Model.UiPageTypeModel, Models.UiPageTypeModel>(pageModel);

            return View(pageData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPageTypeModel pageModel)
        {
            if (id != pageModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var pageData = _mapper.Map<Models.UiPageTypeModel, Business.Core.Model.UiPageTypeModel>(pageModel);
                _uiPageTypeService.Edit(id, pageData);
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.UiPageTypeModel { Id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageTypeModel pageModel)
        {
            if (ModelState.IsValid)
            {
               
                var pageCreate = _mapper.Map<Models.UiPageTypeModel, Business.Core.Model.UiPageTypeModel>(pageModel);
                _uiPageTypeService.Create(pageCreate);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Business.Core.Model.UiPageTypeModel con = _uiPageTypeService.GetById((int)id);
            if (con == null)
            {
                return NotFound();
            }
            var pageDel = _mapper.Map<Business.Core.Model.UiPageTypeModel, Models.UiPageTypeModel>(con);
            return View(pageDel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _uiPageTypeService.Delete((int)id);
            return RedirectToAction("Index");
        }


    }
}

using AutoMapper;
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
        public UiControlTypeController(IUiControlTypeService uiControlTypeServices,IMapper mapper)
        {
            _uiControlTypeServices = uiControlTypeServices;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiControlTypeModel> controlTypeListModel = _uiControlTypeServices.GetAll();
            var controlTypeList = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeModel>>(controlTypeListModel);
            return View(controlTypeList.AsEnumerable());

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Business.Core.Model.UiControlTypeModel conModel = _uiControlTypeServices.Get((int)id);
            if (conModel == null)
            {
                return NotFound();
            }
            var conEdit = _mapper.Map<Business.Core.Model.UiControlTypeModel, Models.UiControlTypeModel>(conModel);
            return View(conEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiControlTypeModel conModel)
        {
            if (id != conModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var conEdit = _mapper.Map<Models.UiControlTypeModel, Business.Core.Model.UiControlTypeModel>(conModel);
                _uiControlTypeServices.Edit(id, conEdit);
                return RedirectToAction("Index");
            }
            return View(conModel);
        }


        [HttpGet]
        public ActionResult Create(int id)
        {

            return base.View(new Models.UiControlTypeModel { Id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiControlTypeModel conModel)
        {
            if (ModelState.IsValid)
            {
                var conCreate = _mapper.Map<Models.UiControlTypeModel, Business.Core.Model.UiControlTypeModel>(conModel);
                _uiControlTypeServices.Create(conCreate);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(conModel);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Business.Core.Model.UiControlTypeModel con = _uiControlTypeServices.Get((int)id);
            if (con == null)
            {
                return NotFound();
            }
            var conEdit = _mapper.Map<Business.Core.Model.UiControlTypeModel, Models.UiControlTypeModel>(con);
            return View(conEdit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _uiControlTypeServices.Delete((int)id);
            return RedirectToAction("Index");
        }


    }
}

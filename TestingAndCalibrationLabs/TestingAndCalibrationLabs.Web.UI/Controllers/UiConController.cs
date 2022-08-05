using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiConController : Controller
    {
        public readonly IUiControlService _uiControlServices;
        public UiConController(IUiControlService uiControlServices)
        {
            _uiControlServices = uiControlServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var control = _uiControlServices.GetAll();
            List<Models.UiControl.UiControlModel> sampless = new List<Models.UiControl.UiControlModel>();
           
            foreach (var item in control)
            {
                sampless.Add(new Models.UiControl.UiControlModel { id = item.Id, Name = item.Name, DisplayName = item.DisplayName });
            }
            return View(sampless.AsEnumerable());

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var conModel = _uiControlServices.Get((int)id);
            if (conModel == null)
            {
                return NotFound();
            }
            var UIModel = new Models.UiControl.UiControlModel
            {
                id = conModel.Id,
                Name = conModel.Name,
                DisplayName = conModel.DisplayName,
            };
            return View(UIModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiControl.UiControlModel conModel)
        {
            if (id != conModel.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var conBackModel = new Business.Core.Model.UiControl.UiControlModel
                {
                    Id = conModel.id,
                    Name = conModel.Name,
                    DisplayName = conModel.DisplayName,
                    
                };
                _uiControlServices.Edit(id, conBackModel);
                return RedirectToAction("Index");
            }
            return View(conModel);
        }


        [HttpGet]
        public ActionResult Create(int id)
        {

            return base.View(new Models.UiControl.UiControlModel { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiControl.UiControlModel conModel)
        {
            if (ModelState.IsValid)
            {
                var userbackModel = new TestingAndCalibrationLabs.Business.Core.Model.UiControl.UiControlModel
                {
                    Id = conModel.id,
                    Name = conModel.Name,
                    DisplayName = conModel.DisplayName,
                    
                };
                _uiControlServices.Create(userbackModel);
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
            var con = _uiControlServices.Get((int)id);
            if (con == null)
            {
                return NotFound();
            }
            var UIModel = new Models.UiControl.UiControlModel
            {
                id = con.Id,
                Name = con.Name,
                DisplayName = con.DisplayName,
               
            };
            return View(UIModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _uiControlServices.Delete((int)id);
            return RedirectToAction("Index");
        }


    }
}

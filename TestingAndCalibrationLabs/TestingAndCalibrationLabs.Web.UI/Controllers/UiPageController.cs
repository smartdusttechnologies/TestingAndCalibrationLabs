using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageController : Controller
    {
        public readonly IUiPageService _uiPageService;
        public UiPageController(IUiPageService uiPageService)
        {
            _uiPageService = uiPageService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var page = _uiPageService.GetAll();
            List<Models.UiPage.UiPageModel> Pages = new List<Models.UiPage.UiPageModel>();
            foreach (var item in page)
            {
                Pages.Add(new Models.UiPage.UiPageModel{ id = item.Id, Name = item.Name});
            }
            return View(Pages.AsEnumerable());
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pageModel = _uiPageService.GetById((int)id);
            if (pageModel == null)
            {
                return NotFound();
            }
            var UIModel = new Models.UiPage.UiPageModel
            {
                id = pageModel.Id,
                Name = pageModel.Name,
            };
            return View(UIModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPage.UiPageModel pageModel)
        {
            if (id != pageModel.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var conBackModel = new Business.Core.Model.UiPage.UiPageModel
                {
                    Id = pageModel.id,
                    Name = pageModel.Name,

                };
                _uiPageService.Edit(id, conBackModel);
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var page = _uiPageService.GetAll();
            List<Models.UiPage.UiPageModel> Pages = new List<Models.UiPage.UiPageModel>();
            foreach (var item in page)
            {
                Pages.Add(new Models.UiPage.UiPageModel { id = item.Id, Name = item.Name });
            }
            ViewBag.page = Pages.ToList();
            return base.View(new Models.UiPage.UiPageModel { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPage.UiPageModel pageModel)
        {
            if (ModelState.IsValid)
            {
                var userbackModel = new TestingAndCalibrationLabs.Business.Core.Model.UiPage.UiPageModel
                {
                    Id = pageModel.id,
                    Name = pageModel.Name,

                };
                _uiPageService.Create(userbackModel);
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
            var con = _uiPageService.GetById((int)id);
            if (con == null)
            {
                return NotFound();
            }
            var UIModel = new Models.UiPage.UiPageModel
            {
                id = con.Id,
                Name = con.Name,

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
            _uiPageService.Delete((int)id);
            return RedirectToAction("Index");
        }


    }
}

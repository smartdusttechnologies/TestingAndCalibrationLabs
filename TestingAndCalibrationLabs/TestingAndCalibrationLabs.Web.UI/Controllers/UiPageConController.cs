using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageConController : Controller
    {
        public readonly IUiPageControlService _uiPageControlService;
        public readonly IUiPageService _uiPageService;
        public UiPageConController(IUiPageService uiPageService ,IUiPageControlService uiPageControlService)
        {
            _uiPageControlService = uiPageControlService;
            _uiPageService = uiPageService;
        }

        

        [HttpGet]
        public IActionResult Index()
        {
            var pageCon = _uiPageControlService.GetAll();
            List<Models.UiPageControl.UiPageControlModel> pageCons = new List<Models.UiPageControl.UiPageControlModel>();
            foreach (var item in pageCon)
            {
                pageCons.Add(new Models.UiPageControl.UiPageControlModel { id = item.Id, UiPageTypeId = item.UiPageTypeId , UiPageName = item.UiPageName, UiControlTypeId = item.UiControlTypeId , UiControlType = item.UiControlType,
                    UiControlDisplayName = item.UiControlDisplayName ,IsRequired =item.IsRequired, UiDataTypeId = item.UiDataTypeId, UiDataTypeName =item.UiDataTypeName});

            }
            return View(pageCons.AsEnumerable());
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            
            var page = _uiPageService.GetPage();
            var control = _uiPageService.GetControl();
            var data = _uiPageService.GetData();
            
            List<Models.Helper.PageModel> pagess = new List<Models.Helper.PageModel>();
            List<Models.Helper.ControlModel> controless = new List<Models.Helper.ControlModel>();
            List<Models.Helper.DataModel> datass = new List<Models.Helper.DataModel>();
            foreach (var item in page)
            {
                pagess.Add(new Models.Helper.PageModel { PageId = item.PageId, PageName = item.PageName });
            }
            foreach(var item in control)
            {
                controless.Add(new Models.Helper.ControlModel { ControlId = item.ControlId, ControlName = item.ControlName});
            }
            foreach(var item in data)
            {
                datass.Add(new Models.Helper.DataModel { DataId = item.DataId, DataName = item.DataName});
            }
            ViewBag.Control = controless.ToList();
            ViewBag.Data= datass.ToList();
            ViewBag.page = pagess.ToList();
            
            return base.View(new Models.UiPageControl.UiPageControlModel { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageControl.UiPageControlModel pageModel)
        {
            if (ModelState.IsValid)
            {
                var userbackModel = new TestingAndCalibrationLabs.Business.Core.Model.UiPageControl.UiPageControlModel
                {
                    Id = pageModel.id,
                    UiPageTypeId = pageModel.UiPageTypeId,
                    UiControlTypeId = pageModel.UiControlTypeId,
                    UiDataTypeId = pageModel.UiDataTypeId,
                    UiControlDisplayName= pageModel.UiControlDisplayName,
                    IsRequired = pageModel.IsRequired,

                };
                _uiPageControlService.Create(userbackModel);
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var con = _uiPageControlService.GetById((int)id);
            if (con == null)
            {
                return NotFound();
            }
            var UIModel = new Models.UiPageControl.UiPageControlModel
            {
                id = con.Id,
                UiControlTypeId = con.UiControlTypeId,
                UiControlType = con.UiControlType,
                UiPageTypeId = con.UiPageTypeId,
                UiPageName =con.UiPageName,
                IsRequired = con.IsRequired,
                UiControlDisplayName = con.UiControlDisplayName,
                UiDataTypeId=con.UiDataTypeId,
                UiDataTypeName=con.UiDataTypeName,
                

            };
            return View(UIModel);
        }
        [HttpGet]
        public IActionResult Edit(int? id,int pId,int cId,int dId)
        {
            if(id == null && pId == null && cId == null && dId== null)
            {
                return NotFound();
            }
            
            ViewBag.cid = cId;
            ViewBag.did = dId;
            ViewBag.pid = pId;
            var page = _uiPageService.GetPage();
            var control = _uiPageService.GetControl();
            var Data = _uiPageService.GetData();
            List<Models.Helper.ControlModel> controlee = new List<Models.Helper.ControlModel>();
            List<Models.Helper.DataModel> dataee = new List<Models.Helper.DataModel>();
            List<Models.Helper.PageModel> pageee = new List<Models.Helper.PageModel>();
            foreach (var item in page)
            {
                pageee.Add(new Models.Helper.PageModel { PageId = item.PageId, PageName = item.PageName });
            }
            foreach (var item in control)
            {
                controlee.Add(new Models.Helper.ControlModel { ControlId = item.ControlId, ControlName = item.ControlName });
            }
            foreach (var item in Data)
            {
                dataee.Add(new Models.Helper.DataModel { DataId = item.DataId, DataName = item.DataName });
            }
            ViewBag.Control = controlee.ToList();
            ViewBag.Data = dataee.ToList();
            ViewBag.page = pageee.ToList();
            var pcon = _uiPageControlService.GetById((int)id);
            var pageCon = new Models.UiPageControl.UiPageControlModel()
            {
                id = pcon.Id,
                UiControlType = pcon.UiControlType,
                UiPageName = pcon.UiPageName,
                IsRequired = pcon.IsRequired,
                UiControlDisplayName = pcon.UiControlDisplayName,
                UiDataTypeName = pcon.UiDataTypeName,
            };
            return View(pageCon);
        }
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var pcon = _uiPageControlService.GetById((int)id);
            var pageCon = new Models.UiPageControl.UiPageControlModel()
            {
                id = pcon.Id,
                UiControlTypeId = pcon.UiControlTypeId,
                UiControlType = pcon.UiControlType,
                UiPageTypeId = pcon.UiPageTypeId,
                UiPageName = pcon.UiPageName,
                IsRequired = pcon.IsRequired,
                UiControlDisplayName = pcon.UiControlDisplayName,
                UiDataTypeId = pcon.UiDataTypeId,
                UiDataTypeName = pcon.UiDataTypeName,
            };
            return View(pageCon);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            _uiPageControlService.Delete((int)id);
            return RedirectToAction("Index");
        }

    }
}

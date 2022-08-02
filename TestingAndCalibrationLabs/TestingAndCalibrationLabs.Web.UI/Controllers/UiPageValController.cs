using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageValController : Controller
    {
        public readonly IUiPageValidationService _uiPageValidationService;
        public readonly IUiPageService _uiPageService;

        public UiPageValController(IUiPageValidationService uiPageValidationService, IUiPageService uiPageService)
        {
            _uiPageValidationService = uiPageValidationService;
            _uiPageService = uiPageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pageReq = _uiPageValidationService.GetAll();
            List<Models.UiPageValidation.UiPageValidationModel> pageMod = new List<Models.UiPageValidation.UiPageValidationModel>();
            foreach (var item in pageReq)
            {
                pageMod.Add(new Models.UiPageValidation.UiPageValidationModel { id = item.Id, UiPageId = item.UiPageId,
                    UiPageMetadataId = item.UiPageMetadataId, UiPageMetadataName = item.UiPageMetadataName, UiPageName = item.UiPageName,
                    UiPageValidationName = item.UiPageValidationName, UiPageValidationId = item.UiPageValidationId });
            }
            return View(pageMod.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var page = _uiPageService.GetPage();
            var metadata = _uiPageService.GetMetadata();
            var val = _uiPageService.GetVal();
            List<Models.Helper.PageModel> pages = new List<Models.Helper.PageModel>();
            List<Models.Helper.MetadataModel> metadatas = new List<Models.Helper.MetadataModel>();
            List<Models.Helper.ValModel> vals = new List<Models.Helper.ValModel>();
            foreach (var item in page)
            {
                pages.Add(new Models.Helper.PageModel{ PageId = item.PageId,PageName =item.PageName});

            }
            foreach(var item in metadata)
            {
                metadatas.Add(new Models.Helper.MetadataModel { MetadataId = item.MetadataId, MetadataName = item.MetadataName });
            }
            foreach (var item in val)
            {
                vals.Add(new Models.Helper.ValModel { ValId = item.ValId, ValName = item.ValName });
            }
            ViewBag.Page = pages.ToList();
            ViewBag.Metadata = metadatas.ToList();
            ViewBag.Val = vals.ToList();

            return base.View(new Models.UiPageValidation.UiPageValidationModel { id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageValidation.UiPageValidationModel pagVal)
        {
            if (ModelState.IsValid)
            {
                var backVal = new Business.Core.Model.UiPageValidation.UiPageValidationModel
                {
                    Id=pagVal.id,
                    UiPageId = pagVal.UiPageId,
                    UiPageMetadataId = pagVal.UiPageMetadataId,
                    UiPageValidationId = pagVal.UiPageValidationId,

                };
                _uiPageValidationService.Create(backVal);
                return RedirectToAction("Index");
            }
            return View(pagVal);
        }
        [HttpGet]
        public IActionResult Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var edt = _uiPageValidationService.GetById((int)id);
            if(edt == null)
            {
                return NotFound();
            }
            var pagVal = new Models.UiPageValidation.UiPageValidationModel
            {
                id =edt.Id,
                UiPageId = edt.UiPageId, 
                UiPageName = edt.UiPageName,
                UiPageMetadataId = edt.UiPageMetadataId,
                UiPageMetadataName = edt.UiPageMetadataName,
                UiPageValidationId=edt.UiPageValidationId,
                UiPageValidationName=edt.UiPageValidationName,
            };
            return View(pagVal);
        }
        [HttpGet]
        public IActionResult Edit(int? id, int pId, int vId, int mId)
        {
            if (id == null && pId == null && vId == null && mId==null )
            {
                return NotFound();
            }
            ViewBag.pid = pId;
            ViewBag.vid = vId;
            ViewBag.mid=mId;
            var page = _uiPageService.GetPage();
            var validation = _uiPageService.GetVal();
            var metadata = _uiPageService.GetMetadata();
            List<Models.Helper.PageModel> pageee = new List<Models.Helper.PageModel>();
            List<Models.Helper.ValModel> validationee = new List<Models.Helper.ValModel>();
            List<Models.Helper.MetadataModel> metadataee = new List<Models.Helper.MetadataModel>();
            foreach(var item in page)
            {
                pageee.Add(new Models.Helper.PageModel { PageId = item.PageId, PageName = item.PageName });
            }
            foreach(var item in validation)
            {
                validationee.Add(new Models.Helper.ValModel { ValId=item.ValId,ValName=item.ValName });
            }
            foreach(var item in metadata)
            {
                metadataee.Add(new Models.Helper.MetadataModel { MetadataId=item.MetadataId, MetadataName=item.MetadataName });
            }
           ViewBag.Page=pageee;
            ViewBag.Val=validationee;
            ViewBag.Meta=metadataee;

            var gbi = _uiPageValidationService.GetById((int)id);
            if (gbi == null)
            {
                return NotFound();
            }
            var pagVal = new Models.UiPageValidation.UiPageValidationModel
            {
                id = gbi.Id,
                UiPageId = gbi.UiPageId,
                UiPageName = gbi.UiPageName,
                UiPageMetadataId = gbi.UiPageMetadataId,
                UiPageMetadataName = gbi.UiPageMetadataName,
                UiPageValidationId = gbi.UiPageValidationId,
                UiPageValidationName = gbi.UiPageValidationName,
            };
            return View(pagVal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPageValidation.UiPageValidationModel pageVal)
        {
            if (id != pageVal.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var backVal = new Business.Core.Model.UiPageValidation.UiPageValidationModel
                {
                    Id= pageVal.id,
                    UiPageName = pageVal.UiPageName,
                    UiPageMetadataName = pageVal.UiPageMetadataName,
                    UiPageValidationName=pageVal.UiPageValidationName,
                    UiPageId =pageVal.UiPageId,
                    UiPageMetadataId=pageVal.UiPageMetadataId,
                    UiPageValidationId=pageVal.UiPageValidationId,

                };
                _uiPageValidationService.Update(id ,backVal);
                return RedirectToAction("Index");
            }
            return View(pageVal);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gbi = _uiPageValidationService.GetById(id);
            var valModel = new Models.UiPageValidation.UiPageValidationModel() { 
            UiPageName=gbi.UiPageName,
            UiPageMetadataName=gbi.UiPageMetadataName,
            UiPageValidationName=gbi.UiPageValidationName
            };
            return View(valModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _uiPageValidationService.Delete((int)id);
            return RedirectToAction("Index");
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class WorkflowStageController : Controller
    {
        
        private readonly IWorkflowStageService _workflowStageService;
        private readonly IWorkflowService _workflowService;
        private readonly IUiPageTypeService _uiPageTypeService;
        private readonly IMapper _mapper;
        public WorkflowStageController(IWorkflowStageService workflowStageService,IMapper mapper, IUiPageTypeService uiPageTypeService, IWorkflowService workflowService)
        {
            _workflowStageService = workflowStageService;
            _mapper = mapper;
            _uiPageTypeService = uiPageTypeService;
            _workflowService = workflowService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult GetByModuleId(int moduleId)
        //{
        //    var stages = _workflowStageService.GetByWorkflowId(moduleId);
        //    var stagesDTO = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(stages);
        //    var orderdStage = stagesDTO.OrderBy(x => x.Orders);
        //    if(orderdStage != null)
        //    {
        //        return Ok(orderdStage);
        //    }
        //    return BadRequest();
        //}


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var pageworkflowstage = _workflowStageService.Get();
            var pageworkflowstages = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(pageworkflowstage);
            return View(pageworkflowstages.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var pageList = _uiPageTypeService.Get();
            var workflowList = _workflowService.Get();
            var pages = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pageList);
            var workflowLists = _mapper.Map<List<WorkflowModel>, List<WorkflowDTO>>(workflowList);
           
            // var dropdownssss =    categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.UiPageTypes = pages;
            ViewBag.Uiworkflow = workflowLists;
            
            return base.View(new Models.WorkflowStageDTO { Id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] WorkflowStageDTO workflowStageDTO)
        {
            if (ModelState.IsValid)
            {

                var createworkflowStageModel = _mapper.Map<Models.WorkflowStageDTO, Business.Core.Model.WorkflowStageModel>(workflowStageDTO);

                _workflowStageService.Create(createworkflowStageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowStageDTO);
        }
        [HttpGet]
        public IActionResult Edit(int? id, int uiPageTypeId, int workflowId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.WorkflowId = workflowId;
           
            ViewBag.UiPageTypeId = uiPageTypeId;
          
            var pages = _uiPageTypeService.Get();
            var flow = _workflowService.Get();
    
            var pageList = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pages);
            var flowList = _mapper.Map<List<WorkflowModel>, List<WorkflowDTO>>(flow);
         
           
            ViewBag.UiPageTypes = pageList;
            ViewBag.Uiworkflow = flowList;

            WorkflowStageModel flowStageModel = _workflowStageService.GetById((int)id);
            var flowstage = _mapper.Map<WorkflowStageModel, WorkflowStageDTO>(flowStageModel);
            return View(flowstage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] WorkflowStageDTO workflowStageDTO)
        {
            if (id != workflowStageDTO.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                var editworkflowStage = _mapper.Map<Models.WorkflowStageDTO, Business.Core.Model.WorkflowStageModel>(workflowStageDTO);
                _workflowStageService.Update(id, editworkflowStage);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowStageDTO);
        }
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            WorkflowStageModel workflowStageModel = _workflowStageService.GetById((int)id);
            var deleteMetadata = _mapper.Map<WorkflowStageModel, WorkflowStageDTO>(workflowStageModel);
            return View(deleteMetadata);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _workflowStageService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }



    }
}

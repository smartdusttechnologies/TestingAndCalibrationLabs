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
        [HttpPost]
        public IActionResult GetByModuleId(int moduleId)
        {
            var stages = _workflowStageService.GetByWorkflowId(moduleId);
            var stagesDTO = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(stages);
            var orderdStage = stagesDTO.OrderBy(x => x.Orders);
            if (orderdStage != null)
            {
                return Ok(orderdStage);
            }
            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var pageWorkflowStage = _workflowStageService.Get();
            var pageWorkflowStages = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(pageWorkflowStage);
            return View(pageWorkflowStages.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            var pageList = _uiPageTypeService.Get();
            var workflowList = _workflowService.Get();
            var pages = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pageList);
            var workflowLists = _mapper.Map<List<WorkflowModel>, List<WorkflowDTO>>(workflowList);         
            //var dropdownssss =    categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.UiPageTypes = pages;
            ViewBag.Workflow = workflowLists;        
            return base.View(new Models.WorkflowStageDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In WorkflowActivity
        /// </summary>
        /// <param name="workflowStageDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] WorkflowStageDTO workflowStageDTO)
        {
            if (ModelState.IsValid)
            {
                var createWorkflowStageModel = _mapper.Map<Models.WorkflowStageDTO, Business.Core.Model.WorkflowStageModel>(workflowStageDTO);
                _workflowStageService.Create(createWorkflowStageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowStageDTO);
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
            var pages = _uiPageTypeService.Get();
            var flow = _workflowService.Get();  
            var pageList = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pages);
            var flowList = _mapper.Map<List<WorkflowModel>, List<WorkflowDTO>>(flow);                 
            ViewBag.UiPageTypes = pageList;
            ViewBag.Workflow = flowList;
            WorkflowStageModel flowStageModel = _workflowStageService.GetById((int)id);
            var flowStage = _mapper.Map<WorkflowStageModel, WorkflowStageDTO>(flowStageModel);
            return View(flowStage);
        }
        /// <summary>
        /// To Edit Record In WorkflowStage
        /// </summary>
        /// <returns></returns>
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
                var editWorkflowStage = _mapper.Map<Models.WorkflowStageDTO, Business.Core.Model.WorkflowStageModel>(workflowStageDTO);
                _workflowStageService.Update(id, editWorkflowStage);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowStageDTO);
        }
        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            WorkflowStageModel workflowStageModel = _workflowStageService.GetById((int)id);
            var deleteStage = _mapper.Map<WorkflowStageModel, WorkflowStageDTO>(workflowStageModel);
            return View(deleteStage);
        }
        /// <summary>
        /// To Delete Record In WorkflowStage
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
            _workflowStageService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}

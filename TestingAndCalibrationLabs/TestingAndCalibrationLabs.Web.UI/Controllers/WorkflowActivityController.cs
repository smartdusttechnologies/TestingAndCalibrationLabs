using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class WorkflowActivityController : Controller
    {
       
        private readonly IActivityService _activityService;
        private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IMapper _mapper;
        //private readonly IWorkflowActivityRepository _workflowActivityRepository;
        private readonly IWorkflowStageService _workflowStageService;

        public WorkflowActivityController(IMapper mapper,  IWorkflowStageService workflowStageService,IActivityService activityService, IWorkflowActivityService workflowActivityService)
        {
            //_workflowActivityRepository = workflowActivityRepository;
            _activityService = activityService;
            _mapper = mapper;
            _workflowStageService = workflowStageService;
            _workflowActivityService = workflowActivityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var workflowActivitypage = _workflowActivityService.Get();
            var workflowActivitypages = _mapper.Map<List<WorkflowActivityModel>, List<WorkflowActivityDTO>>(workflowActivitypage);
            return View(workflowActivitypages.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var activityList = _activityService.Get();
            var StageList = _workflowStageService.Get();
            var activitypages = _mapper.Map<List<ActivityModel>, List<ActivityDTO>>(activityList);
            var Stagepages = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(StageList);
            ViewBag.Activity = activitypages;
            ViewBag.WorkflowStage = Stagepages;

            return base.View(new WorkflowActivityDTO { Id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] WorkflowActivityDTO workflowActivityDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageValidation = _mapper.Map<WorkflowActivityDTO, WorkflowActivityModel>(workflowActivityDTO);
                _workflowActivityService.Create(createPageValidation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowActivityDTO);
        }

        [HttpGet]
        public IActionResult Edit(int id, int ActivityId, int WorkflowStageId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ModuleId = ActivityId;
            ViewBag.ModuleId = WorkflowStageId;

            var pages = _activityService.Get();
            var pagess = _workflowStageService.Get();
            var pageList = _mapper.Map<List<ActivityModel>, List<ActivityDTO>>(pages);
            var pageLists = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(pagess);
            ViewBag.Activity = pageList;
            ViewBag.WorkflowStage = pageLists;

            WorkflowActivityModel WorkflowActivity = _workflowActivityService.GetById((int)id);
            var WorkflowActivitydata = _mapper.Map<WorkflowActivityModel, WorkflowActivityDTO>(WorkflowActivity);
            return View(WorkflowActivitydata);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] WorkflowActivityDTO workflowActivityDTO)
        {
            if (id != workflowActivityDTO.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var editWorkflowActivityDTO = _mapper.Map<Models.WorkflowActivityDTO, Business.Core.Model.WorkflowActivityModel>(workflowActivityDTO);
                _workflowActivityService.Update(id, editWorkflowActivityDTO);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowActivityDTO);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WorkflowActivityModel workflowActivityModel = _workflowActivityService.GetById((int)id);
            var deleteWorkflowActivity = _mapper.Map<WorkflowActivityModel, WorkflowActivityDTO>(workflowActivityModel);
            return View(deleteWorkflowActivity);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _workflowActivityService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}
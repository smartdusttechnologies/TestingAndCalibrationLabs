using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class WorkflowActivityController : Controller
    {
       
        private readonly IActivityService _activityService;
        private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IMapper _mapper;
        private readonly IWorkflowStageService _workflowStageService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="activityService"></param>
        /// <param name="workflowStageService"></param>
        /// <param name="workflowActivityService"></param>
        public WorkflowActivityController(IMapper mapper,  IWorkflowStageService workflowStageService,IActivityService activityService, IWorkflowActivityService workflowActivityService)
        {
            _activityService = activityService;
            _mapper = mapper;
            _workflowStageService = workflowStageService;
            _workflowActivityService = workflowActivityService;
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var workflowActivityPage = _workflowActivityService.Get();
            var workflowActivitypages = _mapper.Map<List<WorkflowActivityModel>, List<WorkflowActivityDTO>>(workflowActivityPage);
            return View(workflowActivitypages.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            var activityList = _activityService.Get();
            var stageList = _workflowStageService.Get();
            var activityPages = _mapper.Map<List<ActivityModel>, List<ActivityDTO>>(activityList);
            var stagePages = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(stageList);
            ViewBag.Activity = activityPages;
            ViewBag.WorkflowStage = stagePages;

            return base.View(new WorkflowActivityDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In WorkflowActivity
        /// </summary>
        /// <param name="workflowActivityDTO"></param>
        /// <returns></returns>
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
        /// <summary>
        /// For Edit Records View
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var pages = _activityService.Get();
            var pagess = _workflowStageService.Get();
            var pageList = _mapper.Map<List<ActivityModel>, List<ActivityDTO>>(pages);
            var pageLists = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(pagess);
            ViewBag.Activity = pageList;
            ViewBag.WorkflowStage = pageLists;

            WorkflowActivityModel workflowActivity = _workflowActivityService.GetById((int)id);
            var workflowActivityData = _mapper.Map<WorkflowActivityModel, WorkflowActivityDTO>(workflowActivity);
            return View(workflowActivityData);
        }
        /// <summary>
        /// To Edit Record In WorkflowActivity
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WorkflowActivityModel workflowActivityModel = _workflowActivityService.GetById(id);
            var deleteWorkflowActivity = _mapper.Map<WorkflowActivityModel, WorkflowActivityDTO>(workflowActivityModel);
            return View(deleteWorkflowActivity);
        }
        /// <summary>
        /// To Delete Record In workflowActivity
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
            _workflowActivityService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}
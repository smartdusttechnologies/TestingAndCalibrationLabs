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
    public class WorkFlowController : Controller
    {
        private readonly IWorkflowService _WorkflowService;
        private readonly IMapper _mapper;
        private readonly IModuleService _ModuleService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="WorkflowService"></param>
        /// <param name="mapper"></param>
        /// <param name="moduleService"></param>
        public WorkFlowController(IWorkflowService WorkflowService, IMapper mapper, IModuleService moduleService)
        {
            _WorkflowService = WorkflowService;
            _ModuleService= moduleService;
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
            var workflowpage = _WorkflowService.Get();
            var workflowpages = _mapper.Map<List<WorkflowModel>, List<WorkflowDTO>>(workflowpage);
            return View(workflowpages.AsEnumerable());


        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            var pageList = _ModuleService.Get();
            var pages = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(pageList);
            ViewBag.module= pages;

            return base.View(new WorkflowDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Workflow
        /// </summary>
        /// <param name="workflowDTO"></param>
        /// <returns></returns>
        [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] WorkflowDTO workflowDTO)
        {
            if (ModelState.IsValid)
            {
               var createPageValidation = _mapper.Map<WorkflowDTO, WorkflowModel>(workflowDTO);
                _WorkflowService.Create(createPageValidation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowDTO);
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
         
            var pages = _ModuleService.Get();
           var pageList = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(pages);
           ViewBag.Module = pageList;

           WorkflowModel Module = _WorkflowService.GetById((int)id);
           var Workflowdata = _mapper.Map<WorkflowModel, WorkflowDTO>(Module);
           return View(Workflowdata);
       }
        /// <summary>
        /// To Edit Record In Workflow
        /// </summary>
        /// <returns></returns>
        [HttpPost]
       [ValidateAntiForgeryToken]
       public IActionResult Edit(int id, [Bind] WorkflowDTO workflowDTO)
       {
            if (id != workflowDTO.Id)
            {
               return NotFound();
            }
            if (ModelState.IsValid)
            {
                var editWorkflowDTO = _mapper.Map<Models.WorkflowDTO, Business.Core.Model.WorkflowModel>(workflowDTO);
                _WorkflowService.Update(id, editWorkflowDTO);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(workflowDTO);
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
            WorkflowModel workflowModel = _WorkflowService.GetById((int)id);
            var deleteWorkflow = _mapper.Map<WorkflowModel, WorkflowDTO>(workflowModel);
            return View(deleteWorkflow);
        }
        /// <summary>
        /// To Delete Record In workflow
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
            _WorkflowService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
       }
   }
}
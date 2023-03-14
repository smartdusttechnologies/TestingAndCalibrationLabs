using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class WorkflowStageController : Controller
    {
        private readonly IWorkflowStageService _workflowStageService;
        private readonly IMapper _mapper;
        public WorkflowStageController(IWorkflowStageService workflowStageService,IMapper mapper)
        {
            _workflowStageService = workflowStageService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetByModuleId(int moduleId)
        {
            var stages = _workflowStageService.GetByWorkflowId(moduleId);
            var stagesDTO = _mapper.Map<List<WorkflowStageModel>, List<WorkflowStageDTO>>(stages);
            var orderdStage = stagesDTO.OrderBy(x => x.Orders);
            if(orderdStage != null)
            {
                return Ok(orderdStage);
            }
            return BadRequest();
        }
    }
}

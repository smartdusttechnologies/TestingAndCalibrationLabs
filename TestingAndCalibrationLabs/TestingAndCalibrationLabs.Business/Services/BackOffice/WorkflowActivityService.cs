using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class WorkflowActivityService: IWorkflowActivityService
    {
        private readonly IWorkflowActivityRepository _workflowActivityRepository;

        public WorkflowActivityService(IWorkflowActivityRepository workflowActivityRepository)
        {
            _workflowActivityRepository = workflowActivityRepository;
        }
        public bool WorkflowActivityByPageId(int pageTypeId)
        {
            var worklfowList = _workflowActivityRepository.GetByWorkflowStageId(pageTypeId);
            foreach (var activity in worklfowList)
            {
                if (activity.ActivityId == (int)ActivityType.EmailServices)
                {
                    //uiPageId = _commonRepository.GetPageIdBasedOnOrder(moduleId);
                    //EmailModel emailModel = new EmailModel();
                    //_emailService.Sendemail(emailModel);
                }
            }
            return true;

        }
    }
}

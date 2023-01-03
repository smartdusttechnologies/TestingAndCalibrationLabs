using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class WorkflowActivityModel:Entity
    {
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int WorkflowStageId { get; set; }
        public string WorkflowStageName { get; set; }
    }
}

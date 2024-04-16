using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains Properties Of Workflow
    /// </summary>
    [DbTable("Workflow")]  
    public class WorkflowModel : Entity
    {
        /// <summary>
        /// It Contains Name Of Workflow
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains Id Of Module
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// It Contains Name Of Module
        /// </summary>
        public string Module { get; set; }
    }
}

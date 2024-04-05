using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    /// <summary>
    /// It Conatains The Properties for Ui Page Type
    /// </summary>
    [DbTable("UiPageType")]
    public class UiPageTypeModel : Entity
    {
        /// <summary>
        /// It Contains The Name For The Ui Page Type
        /// </summary>
        [DbColumn]
        
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Name From Module
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// It Contains The Id From Module
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// It Contains The Name From WorkflowStage
        /// </summary>
        public string WorkflowStageName { get; set; }
        /// <summary>
        /// It Contains The Id From WorkflowStage
        /// </summary>
        public int WorkflowStageId { get; set; }

    }

}

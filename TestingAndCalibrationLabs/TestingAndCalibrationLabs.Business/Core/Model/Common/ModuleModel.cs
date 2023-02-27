using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{   /// <summary>
    /// It Contains Properties Of Module
    /// </summary>
    [DbTable("Module")]
    public class ModuleModel : Entity
    {    /// <summary>
         /// It Contains Name Of Module
         /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains Id Of Application
        /// </summary
        public int ApplicationId { get; set; }
        /// <summary>
        /// It Contains Name Of Application
        /// </summary>
        public string ApplicationName { get; set; }
    }
}

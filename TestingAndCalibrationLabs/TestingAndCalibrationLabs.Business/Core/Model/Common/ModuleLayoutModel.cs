using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains The Properties For ModuleLayout
    /// </summary>
    public class ModuleLayoutModel
    {
        /// <summary>
        /// It Contains The Id Of The ModuleLayout
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name Of The ModuleLayout 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Id Of The Module 
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// It Contains The Name Of The Module 
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// It Contains The Id Of The Layout 
        /// </summary>
        public int LayoutId { get; set; }
        /// <summary>
        /// It Contains The Name Of The Layout 
        /// </summary>
        public string LayoutName { get; set; }
    }
}

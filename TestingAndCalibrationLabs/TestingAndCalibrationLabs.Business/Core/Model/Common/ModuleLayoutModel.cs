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
        /// It Contains The ModuleId Of The ModuleLayout 
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// It Contains The ModuleName Of The ModuleLayout 
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// It Contains The LayoutId Of The ModuleLayout 
        /// </summary>
        public int LayoutId { get; set; }
        /// <summary>
        /// It Contains The LayoutName Of The ModuleLayout 
        /// </summary>
        public string LayoutName { get; set; }
    }
}

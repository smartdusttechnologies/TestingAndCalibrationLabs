using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DbTable("LookupCategory")]
    public class LookupCategoryModel : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}

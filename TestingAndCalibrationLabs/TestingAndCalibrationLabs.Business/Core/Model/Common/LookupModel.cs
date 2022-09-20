using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DbTable("Lookup")]
    public class LookupModel : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LookupCategoryId { get; set; }
    }
}

using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Lookup Category
    /// </summary>
    [DbTable("LookupCategory")]
    public class LookupCategoryModel : Entity
    {
        /// <summary>
        /// It Contains The Name Of The Lookup Category
        /// </summary>
        public string Name { get; set; }
    }
}

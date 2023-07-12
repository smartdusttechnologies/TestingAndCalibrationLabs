using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains The Properties Of Lookup
    /// </summary>
    [DbTable("Lookup")]
    public class LookupModel : Entity
    {
        /// <summary>
        /// It Contains Name Of The Lookup
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Id Of The Lookup
        /// </summary>
        public int LookupCategoryId { get; set; }

        public int LookupId { get; set; }

        public int  ParentId { get; set; }
       // public string Category { get; set; }

    }
}

using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Activity
    /// </summary>
    [DbTable("Activity")]
    public class ActivityModel : Entity
    {
        /// <summary>
        /// It Contains Name Of Activity
        /// </summary>
        public string Name { get; set; }       
    }
}

using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Application
    /// </summary>
    [DbTable("Application")]
    public class ApplicationModel : Entity
    {
        /// <summary>
        /// It Contains Name Of Application
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// It Contains Description Of Application
        /// </summary>
        public string Description { get; set; }
    }

}

using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    [DbTable("Application")]
    public class ApplicationModel : Entity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
    }

}

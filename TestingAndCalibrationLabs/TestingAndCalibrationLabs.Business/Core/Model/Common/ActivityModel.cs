using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    [DbTable("Activity")]
    public class ActivityModel : Entity
    {
      
        public string Name { get; set; }
        
    }

}

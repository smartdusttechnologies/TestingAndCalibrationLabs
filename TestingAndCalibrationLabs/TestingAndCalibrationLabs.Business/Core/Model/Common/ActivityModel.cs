using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    [DbTable("Activity")]
    public class ActivityModel : Entity
    {
       // public int Id { get; set; }
        public string Name { get; set; }
        
    }

}

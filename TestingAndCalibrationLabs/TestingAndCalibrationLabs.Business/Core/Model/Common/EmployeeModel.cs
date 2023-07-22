using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Module")]
    public class EmployeeModel : Entity
    {
        public string Name { get; set; }
        public string department_name { get; set; }
    }
}

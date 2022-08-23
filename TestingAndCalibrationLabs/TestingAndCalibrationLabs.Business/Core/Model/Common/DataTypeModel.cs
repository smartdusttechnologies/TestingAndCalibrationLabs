using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("DataType")]
    public class DataTypeModel : Entity
    {
        /// <summary>
        /// Declaring properties for operations
        /// </summary>
        public string Name { get; set; }
    }
}

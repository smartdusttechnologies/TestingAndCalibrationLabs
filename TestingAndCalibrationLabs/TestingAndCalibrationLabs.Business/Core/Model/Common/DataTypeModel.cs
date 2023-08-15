using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Data Type
    /// </summary>
    [DbTable("DataType")]
    public class DataTypeModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Data Type
        /// </summary>
        [DbColumn]
        public string Name { get; set; }
    }
}

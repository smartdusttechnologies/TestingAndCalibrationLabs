using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Declaring properties for operations
    /// </summary>
    [DbTable("UiPageMetadata")]
    public class UiPageMetadataModel : Entity
    {
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
        public int UiControlTypeId { get; set; }
        public string UiControlTypeName { get; set; }
        public bool IsRequired { get; set; }
        public string UiControlDisplayName { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }

    }
}
